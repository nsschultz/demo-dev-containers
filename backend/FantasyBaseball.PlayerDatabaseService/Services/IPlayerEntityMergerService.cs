using System.Collections.Generic;
using FantasyBaseball.PlayerDatabaseService.Models;
using FantasyBaseball.PlayerDatabaseService.Entities;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for converting a BaseballPlayer to a PlayerEntity.</summary>
    public interface IPlayerEntityMergerService
    {        
        /// <summary>Merges a BaseballPlayer into a PlayerEntity.</summary>
        /// <param name="incoming">The incoming player values.</param>
        /// <param name="existing">The existing player values.</param>
        /// <param name="positions">The collection of all of the available positions.</param>
        /// <param name="teams">The collection of all of the teams.</param>
        /// <returns>An object that can be saved to the database.</returns>
        PlayerEntity MergePlayerEntity(BaseballPlayer incoming, PlayerEntity existing, List<PositionEntity> positions, List<MlbTeamEntity> teams);
    }
}