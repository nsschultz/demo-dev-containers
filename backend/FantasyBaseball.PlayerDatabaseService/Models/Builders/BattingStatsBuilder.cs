using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerDatabaseService.Enums;

namespace FantasyBaseball.PlayerDatabaseService.Models.Builders
{
    /// <summary>Builds a new instance of a <c>BattingStats</c> from one or more instances.</summary>
    public class BattingStatsBuilder
    {
        private static readonly double MinimumContractRate = .75;
        private static readonly int  MinimumPowerAndSpeed = 80;
        private static readonly double MinimumWalkRate = .05;
        private static readonly int WeightContractRate = 400;
        private static readonly double WeightPower = .8;
        private static readonly double WeightSpeed = .3;
        private static readonly int WeightWalkRate = 200;
        private readonly List<BattingStats> statsList = new List<BattingStats>();
        private StatsType statsType = StatsType.UNKN;
        
        /// <summary>Set the output <c>StatsType</c> for the <c>BattingStats</c> being creatd</summary>
        /// <param name="stats">The type of stats.</param>
        /// <returns>The instance of the builder.</returns>
        public BattingStatsBuilder AddStats(BattingStats stats)
        {
            if (stats != null) statsList.Add(stats);
            return this;
        }

        /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
        /// <param name="stats">The collection of <c>BattingStats</c> to add to the list.</param>
        /// <returns>The instance of the builder.</returns>
        public BattingStatsBuilder AddStats(IEnumerable<BattingStats> stats)
        {
            if (stats != null) statsList.AddRange(stats.Where(s => s != null));
            return this;
        }

        /// <summary>Creates a new instance of <c>BattingStats</c> from the given data.</summary>
        /// <returns>A new instance of <c>BattingStats</c> from the given data.</returns>
        public BattingStats Build() => Calculate(Sum());

        /// <summary>Adds another instance of <c>BattingStats</c> to the list.</summary>
        /// <param name="type">The collection of <c>BattingStats</c> to add to the list.</param>
        /// <returns>The instance of the builder.</returns>
        public BattingStatsBuilder SetStatsType(StatsType type)
        {
            statsType = type;
            return this;
        }

        private BattingStats Calculate(BattingStats stats) 
        {
            stats.TotalBases = stats.Hits - stats.Doubles - stats.Triples - stats.HomeRuns 
                + stats.Doubles * 2 + stats.Triples * 3 + stats.HomeRuns * 4;
            stats.BattingAverage = Divide(stats.Hits, stats.AtBats);
            stats.OnBasePercentage = Divide(stats.Hits + stats.BaseOnBalls, stats.AtBats + stats.BaseOnBalls);
            stats.SluggingPercentage = Divide(stats.TotalBases, stats.AtBats);
            stats.OnBasePlusSlugging = stats.OnBasePercentage + stats.SluggingPercentage;
            stats.ContractRate = Divide(stats.AtBats - stats.StrikeOuts, stats.AtBats);
            stats.Power = Divide(statsList.Select(s => s.AtBats * s.Power).Sum(), stats.AtBats);
            stats.WalkRate = Divide(stats.BaseOnBalls, stats.AtBats + stats.BaseOnBalls);
            stats.Speed = Divide(statsList.Select(s => s.AtBats * s.Speed).Sum(), stats.AtBats);
            stats.BasePerformanceValue = stats.AtBats + stats.BaseOnBalls > 0 
                ? (stats.WalkRate - MinimumWalkRate) * WeightWalkRate 
                    + (stats.ContractRate - MinimumContractRate) * WeightContractRate +
                    + (stats.Power - MinimumPowerAndSpeed) * WeightPower +
                    + (stats.Speed - MinimumPowerAndSpeed) * WeightSpeed
                : 0;
            return stats;
        }

        private static double Divide(double dividend, double divisor) => divisor == 0 || dividend == 0 ? 0 : dividend / divisor;

        private BattingStats Sum() =>
            new BattingStats
            {
                StatsType = statsType,
                AtBats = statsList.Select(s => s.AtBats).Sum(),
                Runs = statsList.Select(s => s.Runs).Sum(),
                Hits = statsList.Select(s => s.Hits).Sum(),
                Doubles = statsList.Select(s => s.Doubles).Sum(),
                Triples = statsList.Select(s => s.Triples).Sum(),
                HomeRuns = statsList.Select(s => s.HomeRuns).Sum(),
                RunsBattedIn = statsList.Select(s => s.RunsBattedIn).Sum(),
                BaseOnBalls = statsList.Select(s => s.BaseOnBalls).Sum(),
                StrikeOuts = statsList.Select(s => s.StrikeOuts).Sum(),
                StolenBases = statsList.Select(s => s.StolenBases).Sum(),
                CaughtStealing = statsList.Select(s => s.CaughtStealing).Sum()
            };
    }
}