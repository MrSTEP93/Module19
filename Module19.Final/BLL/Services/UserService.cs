using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.DAL.Entities;
using Module19.Final.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module19.Final.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        MessageService messageService;

        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
        }

        public void Register(UserRegistrationData userRegData)
        {
            Type resultType = userRegData.GetType();
            foreach (var prop in resultType.GetProperties())
            {
                if (string.IsNullOrEmpty(prop.GetValue(userRegData, null).ToString()))
                    throw new ArgumentNullException(prop.Name, "Parameter must contains non-empty value!");
            }
            
            if (userRegData.Password.Length < 8)
                throw new ArgumentNullException("Password", "Password must be longer than 7 characters");

            if (!new EmailAddressAttribute().IsValid(userRegData.Email))
                throw new ArgumentNullException("Email", "Email address must contains a correct value!");

            if (userRepository.FindByEmail(userRegData.Email) != null)
                throw new ArgumentException($"User with this email already registered!");

            var userEntity = new UserEntity()
            {
                firstname = userRegData.FirstName,
                lastname = userRegData.LastName,
                email = userRegData.Email,
                password = userRegData.Password
            };

            if (userRepository.Create(userEntity) == 0)
                throw new Exception("There are some errors while creating user. No details");
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id) ?? throw new UserNotFoundException();
            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);

            var outgoingMessages = messageService.GetOutgoingMessagesByUserId(userEntity.id);

            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages);
        }
    }
}
