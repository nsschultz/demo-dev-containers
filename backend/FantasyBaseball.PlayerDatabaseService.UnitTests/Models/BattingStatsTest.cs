using FantasyBaseball.PlayerDatabaseService.Enums;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Models.UnitTests
{
    public class BattingStatsTest
    {
        [Fact] public void DefaultsSetTest()
        {
            var obj = new BattingStats();
            Assert.Equal(StatsType.UNKN, obj.StatsType);
            Assert.Equal(0, obj.AtBats);
            Assert.Equal(0, obj.Runs);
            Assert.Equal(0, obj.Hits);
            Assert.Equal(0, obj.Doubles);
            Assert.Equal(0, obj.Triples);
            Assert.Equal(0, obj.HomeRuns);
            Assert.Equal(0, obj.RunsBattedIn);
            Assert.Equal(0, obj.BaseOnBalls);
            Assert.Equal(0, obj.StrikeOuts);
            Assert.Equal(0, obj.StolenBases);
            Assert.Equal(0, obj.CaughtStealing);
            Assert.Equal(0, obj.TotalBases);
            Assert.Equal(0, obj.BattingAverage);
            Assert.Equal(0, obj.OnBasePercentage);
            Assert.Equal(0, obj.SluggingPercentage);
            Assert.Equal(0, obj.OnBasePlusSlugging);
            Assert.Equal(0, obj.ContractRate);
            Assert.Equal(0, obj.Power);
            Assert.Equal(0, obj.WalkRate);
            Assert.Equal(0, obj.Speed);
            Assert.Equal(0, obj.BasePerformanceValue);
        }
    }
}