using Module19.Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }
        public IEnumerable<FriendEntity> FindMeInFriendlistsOthers(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where friend_id = :friend_id", new { friend_id = userId });
        }

        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }
    }

    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);

        /// <summary>
        /// Ищем людей, кто в друзьях у нас (у меня) (у того пользователя, кто работает)
        /// Тех, кого добавили мы
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<FriendEntity> FindAllByUserId(int userId);

        /// <summary>
        /// Ищем тех, у кого мы в друзьях
        /// Тех, кто добавил нас
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<FriendEntity> FindMeInFriendlistsOthers(int userId);

        int Delete(int id);
    }
}
