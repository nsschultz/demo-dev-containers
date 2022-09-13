using System.Collections.Generic;
using FantasyBaseball.PlayerDatabaseService.Enums;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Models.Builders.UnitTests
{
    public class PitchingStatsBuilderTest
    {
        [Fact] public void BuildEmptyList() => Compare(new PitchingStats(), new PitchingStatsBuilder().Build());

        [Fact] public void BuildWithEmptyCollection() => 
            Compare(new PitchingStats(), new PitchingStatsBuilder().AddStats(new PitchingStats[]{}).Build());

        [Fact] public void BuildWithNullCollection() => 
            Compare(new PitchingStats(), new PitchingStatsBuilder().AddStats((List<PitchingStats>) null).Build());

        [Fact] public void BuildWithNullObject() => Compare(new PitchingStats(), new PitchingStatsBuilder().AddStats((PitchingStats) null).Build());

        [Fact] public void BuildWithMultipleBothAddTypes() 
        {
            var stats1 = new PitchingStats
            {
                Wins = 12,
                Losses = 6,
                QualityStarts = 18,
                Saves = 9,
                BlownSaves = 3,
                Holds = 15,
                InningsPitched = 60,
                HitsAllowed = 45,
                EarnedRuns = 24,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 30,
                StrikeOuts = 120,
                FlyBallRate = 0.2,
                GroundBallRate = 0.31
            };
            var stats2 = new PitchingStats
            {
                Wins = 8,
                Losses = 4,
                QualityStarts = 12,
                Saves = 6,
                BlownSaves = 2,
                Holds = 10,
                InningsPitched = 40,
                HitsAllowed = 30,
                EarnedRuns = 16,
                HomeRunsAllowed = 0,
                BaseOnBallsAllowed = 20,
                StrikeOuts = 80,
                FlyBallRate = 0.45,
                GroundBallRate = 0.66
            };
            var expected = new PitchingStats
            {
                Wins = 20,
                Losses = 10,
                QualityStarts = 30,
                Saves = 15,
                BlownSaves = 5,
                Holds = 25,
                InningsPitched = 100,
                HitsAllowed = 75,
                EarnedRuns = 40,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 50,
                StrikeOuts = 200,
                FlyBallRate = .30,
                GroundBallRate = .45,
                EarnedRunAverage = 3.6,
                WalksAndHitsPerInningPitched = 1.25,
                BattingAverageOnBallsInPlay = 74 / 156d,
                StrandRate = 85 / 124d,
                Command = 4,
                Dominance = 18,
                Control = 4.5,
                GroundBallToFlyBallRate = 1.5,
                BasePerformanceValue = 225.5
            };
            Compare(expected, new PitchingStatsBuilder().AddStats(stats1).AddStats(new PitchingStats[]{ stats2, null }).Build());
        }

        [Fact] public void BuildWithCollectionAdd() 
        {
            var stats1 = new PitchingStats
            {
                Wins = 12,
                Losses = 6,
                QualityStarts = 18,
                Saves = 9,
                BlownSaves = 3,
                Holds = 15,
                InningsPitched = 60,
                HitsAllowed = 45,
                EarnedRuns = 24,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 30,
                StrikeOuts = 120,
                FlyBallRate = 0.2,
                GroundBallRate = 0.31
            };
            var stats2 = new PitchingStats
            {
                Wins = 8,
                Losses = 4,
                QualityStarts = 12,
                Saves = 6,
                BlownSaves = 2,
                Holds = 10,
                InningsPitched = 40,
                HitsAllowed = 30,
                EarnedRuns = 16,
                HomeRunsAllowed = 0,
                BaseOnBallsAllowed = 20,
                StrikeOuts = 80,
                FlyBallRate = 0.45,
                GroundBallRate = 0.66
            };
            var expected = new PitchingStats
            {
                Wins = 20,
                Losses = 10,
                QualityStarts = 30,
                Saves = 15,
                BlownSaves = 5,
                Holds = 25,
                InningsPitched = 100,
                HitsAllowed = 75,
                EarnedRuns = 40,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 50,
                StrikeOuts = 200,
                FlyBallRate = .30,
                GroundBallRate = .45,
                EarnedRunAverage = 3.6,
                WalksAndHitsPerInningPitched = 1.25,
                BattingAverageOnBallsInPlay = 74 / 156d,
                StrandRate = 85 / 124d,
                Command = 4,
                Dominance = 18,
                Control = 4.5,
                GroundBallToFlyBallRate = 1.5,
                BasePerformanceValue = 225.5
            };
            Compare(expected, new PitchingStatsBuilder().AddStats(new PitchingStats[]{ stats1, stats2 }).Build());
        }

        [Fact] public void BuildWithMultipleSingleAdds() 
        {
            var stats1 = new PitchingStats
            {
                Wins = 12,
                Losses = 6,
                QualityStarts = 18,
                Saves = 9,
                BlownSaves = 3,
                Holds = 15,
                InningsPitched = 60,
                HitsAllowed = 45,
                EarnedRuns = 24,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 30,
                StrikeOuts = 120,
                FlyBallRate = 0.2,
                GroundBallRate = 0.31
            };
            var stats2 = new PitchingStats
            {
                Wins = 8,
                Losses = 4,
                QualityStarts = 12,
                Saves = 6,
                BlownSaves = 2,
                Holds = 10,
                InningsPitched = 40,
                HitsAllowed = 30,
                EarnedRuns = 16,
                HomeRunsAllowed = 0,
                BaseOnBallsAllowed = 20,
                StrikeOuts = 80,
                FlyBallRate = 0.45,
                GroundBallRate = 0.66
            };
            var expected = new PitchingStats
            {
                StatsType = StatsType.CMBD,
                Wins = 20,
                Losses = 10,
                QualityStarts = 30,
                Saves = 15,
                BlownSaves = 5,
                Holds = 25,
                InningsPitched = 100,
                HitsAllowed = 75,
                EarnedRuns = 40,
                HomeRunsAllowed = 1,
                BaseOnBallsAllowed = 50,
                StrikeOuts = 200,
                FlyBallRate = .30,
                GroundBallRate = .45,
                EarnedRunAverage = 3.6,
                WalksAndHitsPerInningPitched = 1.25,
                BattingAverageOnBallsInPlay = 74 / 156d,
                StrandRate = 85 / 124d,
                Command = 4,
                Dominance = 18,
                Control = 4.5,
                GroundBallToFlyBallRate = 1.5,
                BasePerformanceValue = 225.5
            };
            Compare(expected, new PitchingStatsBuilder().AddStats(stats1).AddStats(stats2).SetStatsType(StatsType.CMBD).Build());
        }

        private static void Compare(PitchingStats expected, PitchingStats actual)
        {
            Assert.Equal(expected.StatsType, actual.StatsType);
            Assert.Equal(expected.Wins, actual.Wins);
            Assert.Equal(expected.Losses, actual.Losses);
            Assert.Equal(expected.QualityStarts, actual.QualityStarts);
            Assert.Equal(expected.Saves, actual.Saves);
            Assert.Equal(expected.BlownSaves, actual.BlownSaves);
            Assert.Equal(expected.Holds, actual.Holds);
            Assert.Equal(expected.InningsPitched, actual.InningsPitched);
            Assert.Equal(expected.HitsAllowed, actual.HitsAllowed);
            Assert.Equal(expected.EarnedRuns, actual.EarnedRuns);
            Assert.Equal(expected.HomeRunsAllowed, actual.HomeRunsAllowed);
            Assert.Equal(expected.BaseOnBallsAllowed, actual.BaseOnBallsAllowed);
            Assert.Equal(expected.StrikeOuts, actual.StrikeOuts);
            Assert.Equal(expected.FlyBallRate, actual.FlyBallRate);
            Assert.Equal(expected.GroundBallRate, actual.GroundBallRate);
            Assert.Equal(expected.EarnedRunAverage, actual.EarnedRunAverage);
            Assert.Equal(expected.WalksAndHitsPerInningPitched, actual.WalksAndHitsPerInningPitched);
            Assert.Equal(expected.BattingAverageOnBallsInPlay, actual.BattingAverageOnBallsInPlay);
            Assert.Equal(expected.StrandRate, actual.StrandRate);
            Assert.Equal(expected.Command, actual.Command);
            Assert.Equal(expected.Dominance, actual.Dominance);
            Assert.Equal(expected.Control, actual.Control);
            Assert.Equal(expected.GroundBallToFlyBallRate, actual.GroundBallToFlyBallRate);
            Assert.Equal(expected.BasePerformanceValue, actual.BasePerformanceValue);
        }
    }
}