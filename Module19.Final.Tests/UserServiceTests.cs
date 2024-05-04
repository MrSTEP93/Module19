using System;
using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.BLL.Services;
using NUnit.Framework;

namespace Module19.Final.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test] 
        public static void FindUserById_MustReturnNotNull()
        {
            UserService userService = new UserService();
            Assert.IsNotNull(userService.FindById(1));
        }

        [Test]
        public static void FindUserById_MustThrowException()
        {
            UserService userService = new UserService();
            Assert.Throws<UserNotFoundException>(() => userService.FindById(-1));
        }
        
        [Test]
        public static void FindUserByEmail_MustThrowException()
        {
            UserService userService = new UserService();
            Assert.Throws<UserNotFoundException>(() => userService.FindByEmail("nomail@nohost.no"));
        }
        
        [Test]
        public static void Authenticate_MustThrowException()
        {
            UserService userService = new UserService();
            var userAuthData = new UserAuthenticationData()
            {
                Email = "nomail@nohost.no1",
                Password = "1"
            };
            Assert.Throws<UserNotFoundException>(() => userService.Authenticate(userAuthData));

            userAuthData.Email = "lexa@mail.ru";
            Assert.Throws<WrongPasswordException>(() => userService.Authenticate(userAuthData));
        }

        [Test]
        public static void Register_MustThrowException()
        {
            UserService userService = new UserService();
            var userRegData = new UserRegistrationData()
            {
                Email = "nomail@nohost.no2",
                Password = "999",
            };
            Assert.Throws<ArgumentNullException>(() => userService.Register(userRegData));

            userRegData.FirstName = "test";
            userRegData.LastName = "test";
            Assert.Throws<ArgumentOutOfRangeException>(() => userService.Register(userRegData));

            /// А вы знали, что если заполнить UserRegistrationData валидными данными, то пользователь будет создан? ))
            /// Я догадывался об этом, но этого не произошло (как мне показалось) - в рабочей базе (в выходном каталоге проекта) пользователь не создался
            /// Однако, когда после этого тест аутентификации перестал проходить - "WrongPasswordException" вместо "UserNotFound", я перестал понимать, что происходит
            /// И только минут через 7 до меня дошло, что была создана копия базы в выходном каталоге тестового проекта.. мать его шлёп!!!
            /// Ну, буду знать теперь.
            /// 
            /// Зачем я это тут пишу? Да просто так, не обращайте внимания. Это как блог xD 

        }
    }
}
