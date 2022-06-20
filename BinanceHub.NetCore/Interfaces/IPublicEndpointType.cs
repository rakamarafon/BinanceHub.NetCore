using BinanceHub.NetCore.Models;

namespace BinanceHub.NetCore.Interfaces
{
    public interface IPublicEndpointType
    {
        /// <summary>
        /// Fetch system status
        /// </summary>
        /// <returns>
        /// <para>System status object</para>
        /// <para>Status - 0: normal, 1：system maintenance</para>
        /// <para>Message - "normal", "system_maintenance"</para>
        /// </returns>
        Task<SystemStatus> GetSystemStatus();
    }
}
