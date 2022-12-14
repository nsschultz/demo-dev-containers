using FantasyBaseball.PlayerDatabaseService.Models;
using FantasyBaseball.PlayerDatabaseService.Entities;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for converting a PlayerEntity to a BaseballPlayer.</summary>
    public interface IBaseballPlayerBuilderService
    {
        /// <summary>Converts a PlayerEntity to a BaseballPlayer.</summary>
        /// <param name="player">The database values.</param>
        /// <returns>A BaseballPlayer based off the database values.</returns>
        BaseballPlayer BuildBaseballPlayer(PlayerEntity player);
    }
}