using Xunit;
using static FantasyBaseball.PlayerDatabaseService.Enums.EnumUtility;

namespace FantasyBaseball.PlayerDatabaseService.Enums.UnitTests
{
    public class LeagueStatusTest
    {
        [Theory]
        [InlineData(LeagueStatus.A, "Available"  )]
        [InlineData(LeagueStatus.R, "Rostered"   )]
        [InlineData(LeagueStatus.X, "Unavailable")]
        [InlineData(LeagueStatus.S, "Scouted"    )]
        [InlineData(          null, "Available"  )]
        public void GetDescriptionTest(LeagueStatus type, string description) => Assert.Equal(description, GetDescription(type));

        [Theory]
        [InlineData(LeagueStatus.A, "Available"  )]
        [InlineData(LeagueStatus.R, "RosTERed"   )]
        [InlineData(LeagueStatus.X, "unavailable")]
        [InlineData(LeagueStatus.S, "Scouted"    )]
        [InlineData(LeagueStatus.A, ""           )]
        [InlineData(LeagueStatus.A, null         )]
        public void GetFromDescriptionTest(LeagueStatus type, string desc) => Assert.Equal(type, GetFromDescription<LeagueStatus>(desc));

        [Theory]
        [InlineData(LeagueStatus.A, "a" )]
        [InlineData(LeagueStatus.R, "R" )]
        [InlineData(LeagueStatus.X, "x" )]
        [InlineData(LeagueStatus.S, "s" )]
        [InlineData(LeagueStatus.A, ""  )]
        [InlineData(LeagueStatus.A, null)]
        public void GetFromKeyTest(LeagueStatus type, string key) => Assert.Equal(type, GetFromKey<LeagueStatus>(key));
    }
}