using Xunit;
using static FantasyBaseball.PlayerDatabaseService.Enums.EnumUtility;

namespace FantasyBaseball.PlayerDatabaseService.Enums.UnitTests
{
    public class PlayerStatusTest
    {
        [Theory]
        [InlineData(PlayerStatus.XX, ""              )]
        [InlineData(PlayerStatus.DL, "Disabled List" )]
        [InlineData(PlayerStatus.NA, "Not Available" )]
        [InlineData(PlayerStatus.NE, "New Entry"     )]
        [InlineData(           null, ""              )]
        public void GetDescriptionTest(PlayerStatus type, string description) => Assert.Equal(description, GetDescription(type));

        [Theory]
        [InlineData(PlayerStatus.XX, ""              )]
        [InlineData(PlayerStatus.DL, "DISABLED List" )]
        [InlineData(PlayerStatus.NA, "NOT Available" )]
        [InlineData(PlayerStatus.NE, "New ENTRY"     )]
        [InlineData(PlayerStatus.XX, "Normal"        )]
        [InlineData(PlayerStatus.XX, null            )]
        public void GetFromDescriptionTest(PlayerStatus type, string desc) => Assert.Equal(type, GetFromDescription<PlayerStatus>(desc));

        [Theory]
        [InlineData(PlayerStatus.XX, ""  )]
        [InlineData(PlayerStatus.DL, "dl")]
        [InlineData(PlayerStatus.NA, "nA")]
        [InlineData(PlayerStatus.NE, "Ne")]
        [InlineData(PlayerStatus.XX, "XX")]
        [InlineData(PlayerStatus.XX, null)]
        public void GetFromKeyTest(PlayerStatus type, string key) => Assert.Equal(type, GetFromKey<PlayerStatus>(key));
    }
}