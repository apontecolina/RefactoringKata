using System.Collections;
using System.Collections.Generic;

namespace WalletKata.Users
{
    public class User
    {
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        }

        public void AddFriend(User friend)
        {
            friends.Add(friend);
        }

        public bool IsFriendOf(User user)
        {
            return friends.Exists(x => x.Equals(user));
        }
    }

}