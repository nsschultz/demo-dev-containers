using System.ComponentModel;

namespace FantasyBaseball.PlayerDatabaseService.Enums
{
    /// <summary>
    /// The type of stats.
    /// 0/UNKN: Unknown (stats exist but the type is unknown)
    /// 1/YTD: Year to Date (actual stats to the current point in the season)
    /// 2/PROJ: Projected (expected stats for the remainder of the season)
    /// 3/CMBD: Combined (Year to Date + Projected)
    ///</summary>
    public enum StatsType
    {
        /// <summary>Unknown Stats</summary>
        [Description("Unknown")] UNKN = 0,
        /// <summary>Year To Date Stats</summary>
        [Description("Year to Date")] YTD = 1,
        /// <summary>Projected Stats</summary>
        [Description("Projected")] PROJ = 2,
        /// <summary>Combined Stats</summary>
        [Description("Combined")] CMBD = 3
    }
}