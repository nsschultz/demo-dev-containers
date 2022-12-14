using System.Threading.Tasks;
using FantasyBaseball.PlayerDatabaseService.Models;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for updaing a player.</summary>
    public interface IPlayerUpdateService
    {
        /// <summary>Updates the given player.</summary>
        /// <param name="player">The player to update.</param>
        Task UpdatePlayer(BaseballPlayer player);
    }
}