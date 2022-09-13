using System.Collections.Generic;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
  /// <summary>Service for getting the enums as a dictionary.</summary>
  public interface IGetPlayerEnumMapService
  {
    /// <summary>Returns the given enum as a dictionary of the value and description.</summary>
    /// <param name="enumType">The type of enum to return.</param>
    /// <returns>A dictionary of the values and descriptions for the given enum.</returns>
    Dictionary<int, string> GetPlayerEnumMap(string enumType);
  }
}