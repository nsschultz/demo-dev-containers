using System.Collections.Generic;
using FantasyBaseball.PlayerDatabaseService.Enums;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Models.Builders.UnitTests
{
    public class BattingStatsBuilderTest
    {
        [Fact] public void BuildEmptyList() => Compare(new BattingStats(), new BattingStatsBuilder().Build());

        [Fact] public void BuildWithEmptyCollection() => 
            Compare(new BattingStats(), new BattingStatsBuilder().AddStats(new BattingStats[]{}).Build());

        [Fact] public void BuildWithNullCollection() => 
            Compare(new BattingStats(), new BattingStatsBuilder().AddStats((List<BattingStats>) null).Build());

        [Fact] public void BuildWithNullObject() => Compare(new BattingStats(), new BattingStatsBuilder().AddStats((BattingStats) null).Build());

        [Fact] public void BuildWithMultipleBothAddTypes() 
        {
            var stats1 = new BattingStats
            {
                AtBats = 300,
                Runs = 75,
                Hits = 96,
                Doubles = 24,
                Triples = 6,
                HomeRuns = 12,
                RunsBattedIn = 48,
                BaseOnBalls = 30,
                StrikeOuts = 60,
                StolenBases = 9,
                CaughtStealing = 3,
                Power = 100,
                Speed = 61
            };
            var stats2 = new BattingStats
            {
                AtBats = 200,
                Runs = 50,
                Hits = 64,
                Doubles = 16,
                Triples = 4,
                HomeRuns = 8,
                RunsBattedIn = 32,
                BaseOnBalls = 20,
                StrikeOuts = 40,
                StolenBases = 6,
                CaughtStealing = 2,
                Power = 225,
                Speed = 96
            };
            var expected = new BattingStats
            {
                AtBats = 500,
                Runs = 125,
                Hits = 160,
                Doubles = 40,
                Triples = 10,
                HomeRuns = 20,
                RunsBattedIn = 80,
                BaseOnBalls = 50,
                StrikeOuts = 100,
                StolenBases = 15,
                CaughtStealing = 5,
                TotalBases = 280,
                BattingAverage = 0.32,
                OnBasePercentage = 210d / 550,
                SluggingPercentage = 0.56,
                OnBasePlusSlugging = 210d / 550 + .56,
                ContractRate = 0.8,
                Power = 150,
                WalkRate = 50d / 550,
                Speed = 75,
                BasePerformanceValue = 82.6818181818182
            };
            Compare(expected, new BattingStatsBuilder().AddStats(stats1).AddStats(new BattingStats[]{ stats2, null }).Build());
        }

        [Fact] public void BuildWithCollectionAdd() 
        {
            var stats1 = new BattingStats
            {
                AtBats = 300,
                Runs = 75,
                Hits = 96,
                Doubles = 24,
                Triples = 6,
                HomeRuns = 12,
                RunsBattedIn = 48,
                BaseOnBalls = 30,
                StrikeOuts = 60,
                StolenBases = 9,
                CaughtStealing = 3,
                Power = 100,
                Speed = 61
            };
            var stats2 = new BattingStats
            {
                AtBats = 200,
                Runs = 50,
                Hits = 64,
                Doubles = 16,
                Triples = 4,
                HomeRuns = 8,
                RunsBattedIn = 32,
                BaseOnBalls = 20,
                StrikeOuts = 40,
                StolenBases = 6,
                CaughtStealing = 2,
                Power = 225,
                Speed = 96
            };
            var expected = new BattingStats
            {
                AtBats = 500,
                Runs = 125,
                Hits = 160,
                Doubles = 40,
                Triples = 10,
                HomeRuns = 20,
                RunsBattedIn = 80,
                BaseOnBalls = 50,
                StrikeOuts = 100,
                StolenBases = 15,
                CaughtStealing = 5,
                TotalBases = 280,
                BattingAverage = 0.32,
                OnBasePercentage = 210d / 550,
                SluggingPercentage = 0.56,
                OnBasePlusSlugging = 210d / 550 + .56,
                ContractRate = 0.8,
                Power = 150,
                WalkRate = 50d / 550,
                Speed = 75,
                BasePerformanceValue = 82.6818181818182
            };
            Compare(expected, new BattingStatsBuilder().AddStats(new BattingStats[]{ stats1, stats2 }).Build());
        }

        [Fact] public void BuildWithMultipleSingleAdds() 
        {
            var stats1 = new BattingStats
            {
                AtBats = 300,
                Runs = 75,
                Hits = 96,
                Doubles = 24,
                Triples = 6,
                HomeRuns = 12,
                RunsBattedIn = 48,
                BaseOnBalls = 30,
                StrikeOuts = 60,
                StolenBases = 9,
                CaughtStealing = 3,
                Power = 100,
                Speed = 61
            };
            var stats2 = new BattingStats
            {
                AtBats = 200,
                Runs = 50,
                Hits = 64,
                Doubles = 16,
                Triples = 4,
                HomeRuns = 8,
                RunsBattedIn = 32,
                BaseOnBalls = 20,
                StrikeOuts = 40,
                StolenBases = 6,
                CaughtStealing = 2,
                Power = 225,
                Speed = 96
            };
            var expected = new BattingStats
            {
                StatsType = StatsType.CMBD,
                AtBats = 500,
                Runs = 125,
                Hits = 160,
                Doubles = 40,
                Triples = 10,
                HomeRuns = 20,
                RunsBattedIn = 80,
                BaseOnBalls = 50,
                StrikeOuts = 100,
                StolenBases = 15,
                CaughtStealing = 5,
                TotalBases = 280,
                BattingAverage = 0.32,
                OnBasePercentage = 210d / 550,
                SluggingPercentage = 0.56,
                OnBasePlusSlugging = 210d / 550 + .56,
                ContractRate = 0.8,
                Power = 150,
                WalkRate = 50d / 550,
                Speed = 75,
                BasePerformanceValue = 82.6818181818182
            };
            Compare(expected, new BattingStatsBuilder().AddStats(stats1).AddStats(stats2).SetStatsType(StatsType.CMBD).Build());
        }

        private static void Compare(BattingStats expected, BattingStats actual)
        {
            Assert.Equal(expected.StatsType, actual.StatsType);
            Assert.Equal(expected.AtBats, actual.AtBats);
            Assert.Equal(expected.Runs, actual.Runs);
            Assert.Equal(expected.Hits, actual.Hits);
            Assert.Equal(expected.Doubles, actual.Doubles);
            Assert.Equal(expected.Triples, actual.Triples);
            Assert.Equal(expected.HomeRuns, actual.HomeRuns);
            Assert.Equal(expected.RunsBattedIn, actual.RunsBattedIn);
            Assert.Equal(expected.BaseOnBalls, actual.BaseOnBalls);
            Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
            Assert.Equal(expected.StolenBases, actual.StolenBases);
            Assert.Equal(expected.CaughtStealing, actual.CaughtStealing);
            Assert.Equal(expected.TotalBases, actual.TotalBases);
            Assert.Equal(expected.BattingAverage, actual.BattingAverage);
            Assert.Equal(expected.OnBasePercentage, actual.OnBasePercentage);
            Assert.Equal(expected.SluggingPercentage, actual.SluggingPercentage);
            Assert.Equal(expected.OnBasePlusSlugging, actual.OnBasePlusSlugging);
            Assert.Equal(expected.ContractRate, actual.ContractRate);
            Assert.Equal(expected.Power, actual.Power);
            Assert.Equal(expected.WalkRate, actual.WalkRate);
            Assert.Equal(expected.Speed, actual.Speed);
            Assert.Equal(expected.BasePerformanceValue, actual.BasePerformanceValue);
        }
    }
}