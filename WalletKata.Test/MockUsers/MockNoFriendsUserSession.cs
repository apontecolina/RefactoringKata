using WalletKata.Users;

namespace WalletKata.Test.MockUsers
{
    public class MockNoFriendsUserSession : IUserSession
    {
        public User GetLoggedUser()
        {
            return new User();
        }
    }
}