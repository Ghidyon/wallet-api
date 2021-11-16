using System.Threading.Tasks;
using WalletApi.Models.Entities;

namespace WalletApi.Services.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(Wallet wallet);
    }
}
