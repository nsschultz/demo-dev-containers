using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Models.Builders
{
    /// <summary>Builds a new instance of a <c>PitchingStats</c> from one or more instances.</summary>
    public class PitchingStatsBuilder
    {
        private static readonly double BabipMultiplier = 2.82;
        private static readonly int MaxiumumControl = 4;
        private static readonly int MinimumDominance = 5;
        private static readonly double MinimumGroundBallRate = .4;
        private static readonly int WeightControl = 27;
        private static readonly int WeightGroundBallRate = 100;
        private static readonly int WeightDominance = 18;
        private readonly List<PitchingStats> statsList = new List<PitchingStats>();
        private StatsType statsType = StatsType.UNKN;

        /// <summary>Adds another instance of <c>PitchingStats</c> to the list.</summary>
        /// <param name="stats">The <c>PitchingStats</c> to add to the list.</param>
        /// <returns>The instance of the builder.</returns>
        public PitchingStatsBuilder AddStats(PitchingStats stats)
        {
            if (stats != null) statsList.Add(stats);
            return this;
        }

        /// <summary>Adds another instance of <c>PitchingStats</c> to the list.</summary>
        /// <param name="stats">The collection of <c>PitchingStats</c> to add to the list.</param>
        /// <returns>The instance of the builder.</returns>
        public PitchingStatsBuilder AddStats(IEnumerable<PitchingStats> stats)
        {
            if (stats != null) statsList.AddRange(stats.Where(s => s != null));
            return this;
        }

        /// <summary>Creates a new instance of <c>PitchingStats</c> from the given data.</summary>
        /// <returns>A new instance of <c>PitchingStats</c> from the given data.</returns>
        public PitchingStats Build() => Calculate(Sum());

        /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
        /// <param name="type">The collection of <c>BattingStats</c> to add to the list.</param>
        /// <returns>The instance of the builder.</returns>
        public PitchingStatsBuilder SetStatsType(StatsType type)
        {
            statsType = type;
            return this;
        }

        private PitchingStats Calculate(PitchingStats stats) 
        {
            stats.FlyBallRate = Divide(statsList.Select(s => s.InningsPitched * s.FlyBallRate).Sum(), stats.InningsPitched);
            stats.GroundBallRate = Divide(statsList.Select(s => s.InningsPitched * s.GroundBallRate).Sum(), stats.InningsPitched);
            stats.EarnedRunAverage = Divide(stats.EarnedRuns, stats.InningsPitched / 9);
            stats.WalksAndHitsPerInningPitched = Divide(stats.HitsAllowed + stats.BaseOnBallsAllowed, stats.InningsPitched);
            stats.BattingAverageOnBallsInPlay = Divide(stats.HitsAllowed - stats.HomeRunsAllowed, 
                stats.InningsPitched * BabipMultiplier + stats.HitsAllowed - stats.StrikeOuts - stats.HomeRunsAllowed);
            stats.StrandRate = Divide(stats.HitsAllowed + stats.BaseOnBallsAllowed - stats.EarnedRuns,
                stats.HitsAllowed + stats.BaseOnBallsAllowed - stats.HomeRunsAllowed);
            stats.Dominance = Divide(stats.StrikeOuts, stats.InningsPitched / 9);
            stats.Control = Divide(stats.BaseOnBallsAllowed, stats.InningsPitched / 9);
            stats.Command = Divide(stats.Dominance, stats.Control);
            stats.GroundBallToFlyBallRate = Divide(stats.GroundBallRate, stats.FlyBallRate);
            stats.BasePerformanceValue = stats.InningsPitched > 0
                ? (stats.Dominance - MinimumDominance) * WeightDominance
                    + (MaxiumumControl - stats.Control) * WeightControl
                    + (stats.GroundBallRate - MinimumGroundBallRate) * WeightGroundBallRate
                : 0;
            return stats;
        }

        private static double Divide(double dividend, double divisor) => divisor == 0 || dividend == 0 ? 0 : dividend / divisor;

        private PitchingStats Sum() =>
            new PitchingStats
            {
                StatsType = statsType,
                Wins = statsList.Select(s => s.Wins).Sum(),
                Losses = statsList.Select(s => s.Losses).Sum(),
                QualityStarts = statsList.Select(s => s.QualityStarts).Sum(),
                Saves = statsList.Select(s => s.Saves).Sum(),
                BlownSaves = statsList.Select(s => s.BlownSaves).Sum(),
                Holds = statsList.Select(s => s.Holds).Sum(),
                InningsPitched = statsList.Select(s => s.InningsPitched).Sum(),
                HitsAllowed = statsList.Select(s => s.HitsAllowed).Sum(),
                EarnedRuns = statsList.Select(s => s.EarnedRuns).Sum(),
                HomeRunsAllowed = statsList.Select(s => s.HomeRunsAllowed).Sum(),
                BaseOnBallsAllowed = statsList.Select(s => s.BaseOnBallsAllowed).Sum(),
                StrikeOuts = statsList.Select(s => s.StrikeOuts).Sum()
            };
    }
}