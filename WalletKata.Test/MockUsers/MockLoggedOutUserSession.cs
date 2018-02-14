using System;
using WalletKata.Users;

namespace WalletKata.Test.MockUsers
{
    public class MockLoggedOutUserSession : IUserSession
    {
        public MockLoggedOutUserSession()
        {
        }

        public User GetLoggedUser() {
            return null;
        }
    }
}
