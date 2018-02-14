using NUnit.Framework;
using WalletKata.Wallets;
using WalletKata.Exceptions;
using WalletKata.Users;
using System.Collections.Generic;
using Moq;

namespace WalletKata.Test
{
    public class WalletServiceTest
    {
        [Test]
        public void WhenLoggedOutUser_ThenUserNotLoggedInException()
        {
            var mockLoggedOutUserSession = new Mock<IUserSession>();
            mockLoggedOutUserSession
                .Setup(userSession => userSession.GetLoggedUser())
                .Returns(() => null);

            var walletService = new WalletService(
                mockLoggedOutUserSession.Object, 
                new Mock<IWalletDAO>().Object
            );
            Assert.Throws<UserNotLoggedInException>(() => walletService.GetWalletsByUser(new User()));
        }

        [Test]
        public void WhenLoggedNoFriendsUser_ThenReturnsEmptyListOfWallets()
        {
            var mockLoggedNoFriendsUserSession = new Mock<IUserSession>();
            mockLoggedNoFriendsUserSession
                .Setup(userSession => userSession.GetLoggedUser())
                .Returns(() => new User());

            var walletService = new WalletService(
                mockLoggedNoFriendsUserSession.Object, 
                new Mock<IWalletDAO>().Object
            );
            var walletsResult = walletService.GetWalletsByUser(new User());

            Assert.IsEmpty(walletsResult);
            Assert.IsInstanceOf<List<Wallet>>(walletsResult);
        }

        [Test]
        public void WhenLoggedUserHasFriend_ThenReturnsListOfWalletsFromDB()
        {
            var friend = new User();
            var loggedUser = new User();
            friend.AddFriend(loggedUser);

            var mockWalletsFromDB = new List<Wallet>() { new Wallet() };

            var mockLoggedUserWithFriend = new Mock<IUserSession>();
            mockLoggedUserWithFriend
                .Setup(userSession => userSession.GetLoggedUser())
                .Returns(loggedUser);

            var mockWalletsDAO = new Mock<IWalletDAO>();
            mockWalletsDAO
                .Setup(walletDAO => walletDAO.FindWalletsByUser(friend))
                .Returns(mockWalletsFromDB);

            var walletService = new WalletService(
                mockLoggedUserWithFriend.Object,
                mockWalletsDAO.Object
            );
            var walletsResult = walletService.GetWalletsByUser(friend);
            Assert.AreEqual(mockWalletsFromDB, walletsResult);
        }
    }
}
