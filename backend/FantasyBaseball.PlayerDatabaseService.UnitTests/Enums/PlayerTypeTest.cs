using Xunit;
using static FantasyBaseball.PlayerDatabaseService.Enums.EnumUtility;

namespace FantasyBaseball.PlayerDatabaseService.Enums.UnitTests
{
    public class PlayerTypeTest
    {
        [Theory]
        [InlineData(PlayerType.U, "Unknown")]
        [InlineData(PlayerType.B, "Batter" )]
        [InlineData(PlayerType.P, "Pitcher")]
        [InlineData(        null, "Unknown")]
        public void GetDescriptionTest(PlayerType type, string description) => Assert.Equal(description, GetDescription(type));

        [Theory]
        [InlineData(PlayerType.U, "Unknown")]
        [InlineData(PlayerType.B, "batter" )]
        [InlineData(PlayerType.P, "PITCHER")]
        [InlineData(PlayerType.U, ""       )]
        [InlineData(PlayerType.U, null     )]
        public void GetFromDescriptionTest(PlayerType type, string desc) => Assert.Equal(type, GetFromDescription<PlayerType>(desc));

        [Theory]
        [InlineData(PlayerType.U, "U" )]
        [InlineData(PlayerType.B, "b" )]
        [InlineData(PlayerType.P, "P" )]
        [InlineData(PlayerType.U, ""  )]
        [InlineData(PlayerType.U, null)]
        public void GetFromKeyTest(PlayerType type, string key) => Assert.Equal(type, GetFromKey<PlayerType>(key));
    }
}