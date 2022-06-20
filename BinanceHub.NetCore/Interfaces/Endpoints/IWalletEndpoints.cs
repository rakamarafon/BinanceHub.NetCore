using BinanceHub.NetCore.Models.WalletEndpointsModels;

namespace BinanceHub.NetCore.Interfaces.Endpoints
{
    public interface IWalletEndpoints
    {
        Task<SystemStatus> GetSystemStatusAsync();
    }
}
