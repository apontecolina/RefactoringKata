using WalletKata.Users;

namespace WalletKata.Test.MockUsers
{
    public class MockFriendUserSession : IUserSession
    {
        private User user = new User();

        public MockFriendUserSession(User friend)
        {
            user.AddFriend(friend);
        }

        public User GetLoggedUser()
        {
            return user;
        }
    }
}