using System.ComponentModel;

namespace FantasyBaseball.PlayerDatabaseService.Enums
{
    /// <summary>
    /// The type of player.
    /// 0/U: Unknown
    /// 1/B: Batter
    /// 2/P: Pitcher
    ///</summary>
    public enum PlayerType
    {
        /// <summary>Unknown</summary>
        [Description("Unknown")] U = 0,
        /// <summary>Batter</summary>
        [Description("Batter")] B = 1,
        /// <summary>Pitcher</summary>
        [Description("Pitcher")] P = 2
    }
}