using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Models
{
    /// <summary>A single type of batting stats.</summary>
    public class BattingStats
    {
        /// <summary>The type of stats.</summary>
        public StatsType StatsType { get; set; }

        /// <summary>At Bats (AB)</summary>
        public int AtBats { get; set; }

        /// <summary>Runs (R)</summary>
        public int Runs { get; set; }

        /// <summary>Hits (H)</summary>
        public int Hits { get; set; }

        /// <summary>Doubles (2B)</summary>
        public int Doubles { get; set; }

        /// <summary>Triples (3B)</summary>
        public int Triples { get; set; }

        /// <summary>Home Runs (HR)</summary>
        public int HomeRuns { get; set; }

        /// <summary>Runs Batted In (RBI)</summary>
        public int RunsBattedIn { get; set; }

        /// <summary>Base on Balls (BB)</summary>
        public int BaseOnBalls { get; set; }

        /// <summary>Strike Outs (K)</summary>
        public int StrikeOuts { get; set; }

        /// <summary>Stolen Bases (SB)</summary>
        public int StolenBases { get; set; }

        /// <summary>Caught Stealing (CS)</summary>
        public int CaughtStealing { get; set; }

        /// <summary>Total Bases (TB)</summary>
        public int TotalBases { get; set; }

        /// <summary>Batting Average (AVG)</summary>
        public double BattingAverage { get; set; }

        /// <summary>On Base Percentage (OBP)</summary>
        public double OnBasePercentage { get; set; }

        /// <summary>Slugging Percentage (SLG)</summary>
        public double SluggingPercentage { get; set; }

        /// <summary>On Base + Slugging (OPS)</summary>
        public double OnBasePlusSlugging { get; set; }

        /// <summary>Contact Rate (CT%)</summary>
        public double ContractRate { get; set; }

        /// <summary>Linear Weighted Power Index (PX)</summary>
        public double Power { get; set; }

        /// <summary>Walk Rate (BB%)</summary>
        public double WalkRate { get; set; }

        /// <summary>Statistically Scouted Speed (SPD)</summary>
        public double Speed { get; set; }

        /// <summary>Base Performance Value (BPV)</summary>
        public double BasePerformanceValue { get; set; }
    }
}