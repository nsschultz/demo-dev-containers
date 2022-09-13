using FantasyBaseball.PlayerDatabaseService.Enums;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Models.UnitTests
{
    public class PitchingStatsTest
    {
        [Fact] public void DefaultsSetTest()
        {
            var obj = new PitchingStats();
            Assert.Equal(StatsType.UNKN, obj.StatsType);
            Assert.Equal(0, obj.Wins);
            Assert.Equal(0, obj.Losses);
            Assert.Equal(0, obj.QualityStarts);
            Assert.Equal(0, obj.Saves);
            Assert.Equal(0, obj.BlownSaves);
            Assert.Equal(0, obj.Holds);
            Assert.Equal(0, obj.InningsPitched);
            Assert.Equal(0, obj.HitsAllowed);
            Assert.Equal(0, obj.EarnedRuns);
            Assert.Equal(0, obj.HomeRunsAllowed );
            Assert.Equal(0, obj.BaseOnBallsAllowed);
            Assert.Equal(0, obj.StrikeOuts);
            Assert.Equal(0, obj.FlyBallRate);
            Assert.Equal(0, obj.GroundBallRate);
            Assert.Equal(0, obj.EarnedRunAverage);
            Assert.Equal(0, obj.WalksAndHitsPerInningPitched);
            Assert.Equal(0, obj.BattingAverageOnBallsInPlay);
            Assert.Equal(0, obj.StrandRate);
            Assert.Equal(0, obj.Command);
            Assert.Equal(0, obj.Dominance);
            Assert.Equal(0, obj.Control);
            Assert.Equal(0, obj.GroundBallToFlyBallRate);
            Assert.Equal(0, obj.BasePerformanceValue);
        }
    }
}