using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.DAL.Entities;
using Module19.Final.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
        }

        public void AddFriend(FriendAddData friendAddData)
        {
            Validator.ValidateAddress(friendAddData.friendEmail);
            
            UserService userService = new UserService();
            var foundedUser = userService.FindByEmail(friendAddData.friendEmail) ?? throw new UserNotFoundException();

            if (GetFriendsIds(friendAddData.userId).Contains(foundedUser.Id))               // if user is your friend
                throw new UserAlreadyExistsException($"User already is your friend");
/*
            if (GetFriendsIds(foundedUser.Id).Contains(friendAddData.userId))               // if you are friend of the user
                    throw new UserAlreadyExistsException($"User already is your friend");
*/
            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.userId,
                friend_id = foundedUser.Id
            };

            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public List<int> GetFriendsIds(int userId)
        {
            var list = friendRepository.FindMeInFriendlistsOthers(userId).Select(f => f.user_id);       // ищем, у кого мы в друзьях
            return list.Concat(friendRepository.FindAllByUserId(userId).Select(f => f.friend_id)).ToList();  // ищем, кто в друзьях у нас
        }
    }
}
