using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBaseball.PlayerDatabaseService.Exceptions;
using FantasyBaseball.PlayerDatabaseService.Models;
using FantasyBaseball.PlayerDatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBaseball.PlayerDatabaseService.Controllers.V1
{
    /// <summary>Endpoint for retrieving player data.</summary>
    [Route("api/v1/player")] [ApiController] public class PlayerController : ControllerBase
    {
        private readonly IBaseballPlayerBuilderService _playerBuilder;
        private readonly IGetPlayerEnumMapService _getEnumMapService;
        private readonly IGetPlayersService _getService;
        private readonly IPlayerUpdateService _updateService;
        private readonly ISortService _sortService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="playerBuilder">Service for converting a PlayerEntity to a BaseballPlayer.</param>
        /// <param name="getEnumMapService">Service for getting the enums as a dictionary.</param>
        /// <param name="getService">Service for getting players.</param>
        /// <param name="updateService">Service for updating a player.</param>
        /// <param name="sortService">The service for sorting the players.</param>
        public PlayerController(IBaseballPlayerBuilderService playerBuilder,
                                IGetPlayerEnumMapService getEnumMapService,
                                IGetPlayersService getService,
                                IPlayerUpdateService updateService,
                                ISortService sortService) 
        { 
            _playerBuilder = playerBuilder;
            _getEnumMapService = getEnumMapService;
            _getService = getService;
            _updateService = updateService;
            _sortService = sortService;
        }
        
        /// <summary>Gets all of the players from the source.</summary>
        /// <returns>All of the players from the source.</returns>
        [HttpGet] public async Task<List<BaseballPlayer>> GetPlayers()
        {
            var players = await _getService.GetPlayers();
            var baseballPlayers = players.Select(player => _playerBuilder.BuildBaseballPlayer(player)).ToList();
            return _sortService.SortPlayers(baseballPlayers);
        }

        /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
        /// <param name="enumType">The type of enum to return.</param>
        /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
        [HttpGet("enum-map")] public Dictionary<int, string> GetPlayersEnumMap(string enumType) => _getEnumMapService.GetPlayerEnumMap(enumType);

        /// <summary>Gets all of the players from the source.</summary>
        /// <param name="id">The id of the player to change.</param>
        /// <param name="player">The object containing all of the player's data (non-changed data must be included as well).</param>
        [HttpPut("{id}")] public async Task UpdatePlayer([FromRoute] Guid id, [FromBody] BaseballPlayer player) 
        {
            if (player == null) throw new BadRequestException("Player not set");
            if (id == default) throw new BadRequestException("Invalid player id used");
            if (id != player.Id) throw new BadRequestException("The ids must match");
            await _updateService.UpdatePlayer(player);
        }
    }
}