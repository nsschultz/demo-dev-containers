using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Models
{
    /// <summary>A single type of pitching stats.</summary>
    public class PitchingStats
    {
        /// <summary>The type of stats.</summary>
        public StatsType StatsType { get; set; }

        /// <summary>Wins (W)</summary>
        public int Wins { get; set; }

        /// <summary>Losses (L)</summary>
        public int Losses { get; set; }

        /// <summary>Quality Starts (QS)</summary>
        public int QualityStarts { get; set; }

        /// <summary>Saves (SV)</summary>
        public int Saves { get; set; }

        /// <summary>Blown Saves (BS)</summary>
        public int BlownSaves { get; set; }

        /// <summary>Holds (HLD)</summary>
        public int Holds { get; set; }

        /// <summary>Innings Pitched (IP)</summary>
        public double InningsPitched { get; set; }

        /// <summary>Hits Allowed (H)</summary>
        public int HitsAllowed { get; set; }

        /// <summary>Earned Runs (ER)</summary>
        public int EarnedRuns { get; set; }

        /// <summary>Home Runs Allowed (HR)</summary>
        public int HomeRunsAllowed { get; set; }

        /// <summary>Base on Balls Allowed (BB)</summary>
        public int BaseOnBallsAllowed { get; set; }

        /// <summary>Strike Outs (K)</summary>
        public int StrikeOuts { get; set; }

        /// <summary>Fly Ball Rate (F%)</summary>
        public double FlyBallRate { get; set; }

        /// <summary>Ground Ball Rate (G%)</summary>
        public double GroundBallRate { get; set; }

        /// <summary>Earned Run Average (ERA)</summary>
        public double EarnedRunAverage { get; set; }

        /// <summary>Walks And Hits Per Inning Pitched (WHIP)</summary>
        public double WalksAndHitsPerInningPitched { get; set; }

        /// <summary>Batting Average On Balls In Play (BABIP)</summary>
        public double BattingAverageOnBallsInPlay { get; set; }

        /// <summary>Strand Rate (S%)</summary>
        public double StrandRate { get; set; }

        /// <summary>Command (CMD)</summary>
        public double Command { get; set; }

        /// <summary>Dominance (DOM)</summary>
        public double Dominance { get; set; }

        /// <summary>Control (CON)</summary>
        public double Control { get; set; }

        /// <summary>Ground Ball To Fly Ball Rate (G/F%)</summary>
        public double GroundBallToFlyBallRate { get; set; }

        /// <summary>Base Performance Value (BPV)</summary>
        public double BasePerformanceValue { get; set; }
    }
}