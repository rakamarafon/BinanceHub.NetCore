using BinanceHub.NetCore.Models.WalletEndpointsModels;

namespace BinanceHub.NetCore.Interfaces
{
    public interface IWalletEndpoints
    {
        Task<SystemStatus> GetSystemStatusAsync();
    }
}
