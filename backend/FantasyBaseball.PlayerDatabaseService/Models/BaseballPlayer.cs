using System;
using System.Collections.Generic;
using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Models
{
    /// <summary>All of the information that makes up a baseball player.</summary>
    public class BaseballPlayer
    {
        /// <summary>Max value for draft pick attributes.</summary>
        private const int MaxDraftPick = 9999;

        /// <summary>The player's ID.</summary>
        public Guid Id { get; set; }

        /// <summary>The player's BHQ ID.</summary>
        public int BhqId { get; set; }

        /// <summary>The player's type (B for Batter or P for Pitcher).</summary>
        public PlayerType Type { get; set; }

        /// <summary>The player's first name.</summary>
        public string FirstName { get; set; }

        /// <summary>The player's last name.</summary>
        public string LastName { get; set; }

        /// <summary>The player's age.</summary>
        public int Age { get; set; }

        /// <summary>The player's team.</summary>
        public string Team { get; set; }

        /// <summary>The player's status.</summary>
        public PlayerStatus Status { get; set; }
        
        /// <summary>The position(s) this player plays.</summary>
        public string Positions { get; set; }

        /// <summary>The rank of this player in the draft.</summary>
        public int DraftRank { get; set; } = MaxDraftPick;

        /// <summary>The average draft position (ADP) for this player.</summary>
        public int AverageDraftPick { get; set; } = MaxDraftPick;

        /// <summary>The highest pick that was used on this player.</summary>
        public int HighestPick { get; set; } = MaxDraftPick;

        /// <summary>The percentage of time that this player was drafted.</summary>
        public double DraftedPercentage { get; set; }

        /// <summary>The player's projected reliability.</summary>
        public double Reliability { get; set; }

        /// <summary>The player's Mayberry Method score.</summary>
         public int MayberryMethod { get; set; }

        /// <summary>The player's status for League #1.</summary>
        public LeagueStatus League1 { get; set; }

        /// <summary>The player's status for League #2.</summary>
        public LeagueStatus League2 { get; set; }

        /// <summary>Batting Stats (Year to Date, Projected and Combined) for a given player.</summary>
        public List<BattingStats> BattingStats { get; set; } = new List<BattingStats>();

        /// <summary>Pitching Stats (Year to Date, Projected and Combined) for a given player.</summary>
        public List<PitchingStats> PitchingStats { get; set; } = new List<PitchingStats>();
    }
}