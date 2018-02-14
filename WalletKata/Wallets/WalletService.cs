using System.Collections.Generic;
using WalletKata.Users;
using WalletKata.Exceptions;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        private readonly IUserSession userSession;

        private readonly IWalletDAO walletDAO;

        public WalletService(IUserSession userSession, IWalletDAO walletDAO)
        {
            this.userSession = userSession;
            this.walletDAO = walletDAO;
        }

        public List<Wallet> GetWalletsByUser(User user)
        {
            User loggedUser = userSession.GetLoggedUser();
            if (loggedUser == null) throw new UserNotLoggedInException();

            List<Wallet> walletList = new List<Wallet>();
            if (IsFirstUserPartOfSecondUserFriends(loggedUser, user))
            {
                walletList = walletDAO.FindWalletsByUser(user);
            }
            return walletList;
        }

        private bool IsFirstUserPartOfSecondUserFriends(User firstUser, User secondUser)
        {
            return secondUser.GetFriends().Exists(x => x.Equals(firstUser));
        }
    }
}