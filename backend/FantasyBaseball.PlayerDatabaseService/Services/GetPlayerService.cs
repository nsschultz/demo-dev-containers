using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerDatabaseService.Database;
using FantasyBaseball.PlayerDatabaseService.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for getting players.</summary>
    public class GetPlayersService : IGetPlayersService
    {        
        private readonly IPlayerContext _context;

        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="context">The player context.</param>
        public GetPlayersService(IPlayerContext context) => _context = context;
        
        /// <summary>Gets the players from the underlying source.</summary>
        /// <returns>A list of the players.</returns>
        public async Task<List<PlayerEntity>> GetPlayers() => 
            await _context.Players
                .Include(p => p.LeagueStatuses)
                .Include(p => p.MlbTeam)
                .Include(p => p.Positions).ThenInclude(p => p.Position)
                .Include(p => p.BattingStats)
                .Include(p => p.PitchingStats)
                .ToListAsync();
    }
}