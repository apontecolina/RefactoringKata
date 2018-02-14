using System;
using WalletKata.Users;
using System.Collections.Generic;

namespace WalletKata.Wallets
{
    public interface IWalletDAO
    {
        List<Wallet> FindWalletsByUser(User user);
    }
}
