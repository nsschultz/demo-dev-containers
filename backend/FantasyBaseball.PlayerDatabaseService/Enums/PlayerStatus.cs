using System.ComponentModel;

namespace FantasyBaseball.PlayerDatabaseService.Enums
{
    /// <summary>
    /// The status of the player.
    /// 0/XX: Normal (has/had projected stats and is not injured)
    /// 1/DL: Disabled List (has/had projected stats and can be placed on the disabled list)
    /// 2/NA: Not Available (has/had projected stats but missing from the player pool)
    /// 3/NE: New Entry (has/had projected stats and status is unknown)
    ///</summary>
    public enum PlayerStatus
    {
        /// <summary>Normal</summary>
        [Description("")] XX = 0,
        /// <summary>Disabled List</summary>
        [Description("Disabled List")] DL = 1,
        /// <summary>Not Available</summary>
        [Description("Not Available")] NA = 2,
        /// <summary>New Entry</summary>
        [Description("New Entry")] NE = 3
    }
}