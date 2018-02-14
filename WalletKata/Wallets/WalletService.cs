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
            if (user.IsFriendOf(loggedUser))
            {
                walletList = walletDAO.FindWalletsByUser(user);
            }
            return walletList;
        }
    }
}