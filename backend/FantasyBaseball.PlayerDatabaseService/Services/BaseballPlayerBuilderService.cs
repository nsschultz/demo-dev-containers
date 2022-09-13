using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.PlayerDatabaseService.Enums;
using FantasyBaseball.PlayerDatabaseService.Models;
using FantasyBaseball.PlayerDatabaseService.Models.Builders;
using FantasyBaseball.PlayerDatabaseService.Entities;

namespace FantasyBaseball.PlayerDatabaseService.Services
{
    /// <summary>Service for converting a PlayerEntity to a BaseballPlayer.</summary>
    public class BaseballPlayerBuilderService : IBaseballPlayerBuilderService
    {
        private static readonly StatsType[] ExpectedStats = new [] { StatsType.YTD, StatsType.PROJ };

        /// <summary>Converts a PlayerEntity to a BaseballPlayer.</summary>
        /// <param name="player">The database values.</param>
        /// <returns>A BaseballPlayer based off the database values.</returns>
        public BaseballPlayer BuildBaseballPlayer(PlayerEntity player)
        {
            return player == null 
                ? new BaseballPlayer() 
                : BuildStats(new BaseballPlayer 
                    {   
                        Id = player.Id,
                        BhqId = player.BhqId,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Age = player.Age,
                        Type = player.Type,
                        Positions = BuildPositionString(player.Positions),
                        Team = player.Team,
                        Status = player.Status,
                        League1 = player.LeagueStatuses.Where(p => p.LeagueId == 1).Select(l => l.LeagueStatus).FirstOrDefault(),
                        League2 = player.LeagueStatuses.Where(p => p.LeagueId == 2).Select(l => l.LeagueStatus).FirstOrDefault(),
                        DraftRank = player.DraftRank,
                        AverageDraftPick = player.AverageDraftPick,
                        HighestPick = player.HighestPick,
                        DraftedPercentage = player.DraftedPercentage,
                        MayberryMethod = player.MayberryMethod,
                        Reliability = player.Reliability,
                        BattingStats = BuildBattingStats(player),
                        PitchingStats = BuildPitchingStats(player)
                    });
        }

        private static List<BattingStats> BuildBattingStats(PlayerEntity player) => ExpectedStats.Select(s => BuildBattingStats(player, s)).ToList();

        private static BattingStats BuildBattingStats(PlayerEntity player, StatsType statsType)
        {
            var stats = player.BattingStats.FirstOrDefault(b => b.StatsType == statsType);
            var battingStats = stats == null ? new BattingStats() : new BattingStats
            {
                AtBats = stats.AtBats,
                Runs = stats.Runs,
                Hits = stats.Hits,
                Doubles = stats.Doubles,
                Triples = stats.Triples,
                HomeRuns = stats.HomeRuns,
                RunsBattedIn = stats.RunsBattedIn,
                BaseOnBalls = stats.BaseOnBalls,
                StrikeOuts = stats.StrikeOuts,
                StolenBases = stats.StolenBases,
                CaughtStealing = stats.CaughtStealing,
                Power = stats.Power,
                Speed = stats.Speed
            };
            return new BattingStatsBuilder().AddStats(battingStats).SetStatsType(statsType).Build();
        }

        private static List<PitchingStats> BuildPitchingStats(PlayerEntity player) => ExpectedStats.Select(s => BuildPitchingStats(player, s)).ToList();

        private static PitchingStats BuildPitchingStats(PlayerEntity player, StatsType statsType)
        {
            var stats = player.PitchingStats.FirstOrDefault(b => b.StatsType == statsType);
            var pitchingStats = stats == null ? new PitchingStats() : new PitchingStats
            {
                Wins = stats.Wins,
                Losses = stats.Losses,
                QualityStarts = stats.QualityStarts,
                Saves = stats.Saves,
                BlownSaves = stats.BlownSaves,
                Holds = stats.Holds,
                InningsPitched = stats.InningsPitched,
                HitsAllowed = stats.HitsAllowed,
                EarnedRuns = stats.EarnedRuns,
                HomeRunsAllowed = stats.HomeRunsAllowed,
                BaseOnBallsAllowed = stats.BaseOnBallsAllowed,
                StrikeOuts = stats.StrikeOuts,
                FlyBallRate = stats.FlyBallRate,
                GroundBallRate = stats.GroundBallRate
            };
            return new PitchingStatsBuilder().AddStats(pitchingStats).SetStatsType(statsType).Build();
        }

        private static string BuildPositionString(List<PlayerPositionEntity> positions) =>
            string.Join("-", positions.Select(p => p.Position).OrderBy(p => p.SortOrder).Select(p => p.Code));
        
        private static BaseballPlayer BuildStats(BaseballPlayer player)
        {
            player.BattingStats.Add(new BattingStatsBuilder()
                .AddStats(player.BattingStats.FirstOrDefault(b => b.StatsType == StatsType.YTD))
                .AddStats(player.BattingStats.FirstOrDefault(b => b.StatsType == StatsType.PROJ))
                .SetStatsType(StatsType.CMBD)
                .Build());
            player.PitchingStats.Add(new PitchingStatsBuilder()
                .AddStats(player.PitchingStats.FirstOrDefault(p => p.StatsType == StatsType.YTD))
                .AddStats(player.PitchingStats.FirstOrDefault(p => p.StatsType == StatsType.PROJ))
                .SetStatsType(StatsType.CMBD)
                .Build());
            return player;
        }
    }
}