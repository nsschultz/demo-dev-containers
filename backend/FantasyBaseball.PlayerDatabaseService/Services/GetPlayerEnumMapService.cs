using System.Collections.Generic;
using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for getting the enums as a dictionary.</summary>
    public class GetPlayerEnumMapService : IGetPlayerEnumMapService
    {
        /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
        /// <param name="enumType">The type of enum to return.</param>
        /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
        public Dictionary<int, string> GetPlayerEnumMap(string enumType) => 
            enumType?.ToUpperInvariant() switch 
            {
                "LEAGUESTATUS" => EnumUtility.GetValuesAsDictionary<LeagueStatus>(),
                "PLAYERSTATUS" => EnumUtility.GetValuesAsDictionary<PlayerStatus>(),
                "PLAYERTYPE" => EnumUtility.GetValuesAsDictionary<PlayerType>(),
                "STATSTYPE" => EnumUtility.GetValuesAsDictionary<StatsType>(),
                _ => new Dictionary<int, string>()
            };
    }
}