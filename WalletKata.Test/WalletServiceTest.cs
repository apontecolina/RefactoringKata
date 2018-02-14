using NUnit.Framework;
using WalletKata.Wallets;
using WalletKata.Exceptions;
using WalletKata.Users;
using WalletKata.Test.MockUsers;

namespace WalletKata.Test
{
    public class WalletServiceTest
    {
        [Test]
        public void WhenLoggedOutUser_ThenUserNotLoggedInException()
        {
            var userSession = new MockLoggedOutUserSession();
            var walletService = new WalletService(userSession);
            Assert.Throws<UserNotLoggedInException>(() => walletService.GetWalletsByUser(new User()));
        }


        //The Wallet service (WalletKata/Wallets/WalletService.cs) allows an user to consult the wallets of a friend.

        //If the user is not logged, the service throws a UserNotLoggedInException.
        //If the logged user is not friend with the user passed in argument, the service returns an empty list.
       //If the logged user is friend with the user passed in argument, the service returns the list of wallets fetched from the database.
        //Info : the database and the session is a stub which throws an exception.


        //If the instructions are not clear, please create a github issue.

    }
}
