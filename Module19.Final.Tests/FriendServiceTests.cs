using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.BLL.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {
        [Test]
        public static void AddFriend_MustThrowException()
        {
            var friendService = new FriendService();
            var friendAddData = new FriendAddData()
            {
                userId = 1,
                friendEmail = "nomail"
            };
            Assert.Throws<ArgumentNullException>(() => friendService.AddFriend(friendAddData));

            friendAddData.friendEmail = "nomail@nohost.no3";
            Assert.Throws<UserNotFoundException>(() => friendService.AddFriend(friendAddData));
        }

        [Test]
        public static void GetFriendsIds_MustReturnNotNull()
        {
            var friendService = new FriendService();
            Assert.NotNull(friendService.GetFriendsIds(1));
        }

        [Test]
        public static void GetFriendsIds_MustReturnZero()
        {
            var friendService = new FriendService();

            var result = friendService.GetFriendsIds(-1);
            Assert.Zero(result.Count);
        }
    }
}
