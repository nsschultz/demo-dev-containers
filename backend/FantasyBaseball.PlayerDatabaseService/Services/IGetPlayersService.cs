using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerDatabaseService.Entities;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for getting players.</summary>
    public interface IGetPlayersService
    {        
        /// <summary>Gets the players from the underlying source.</summary>
        /// <returns>A list of the players.</returns>
        Task<List<PlayerEntity>> GetPlayers();
    }
}