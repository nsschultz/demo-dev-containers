using Xunit;
using static FantasyBaseball.PlayerDatabaseService.Enums.EnumUtility;

namespace FantasyBaseball.PlayerDatabaseService.Enums.UnitTests
{
    public class StatsTypeTest
    {
        [Theory]
        [InlineData(StatsType.CMBD, "Combined"    )]
        [InlineData(StatsType.PROJ, "Projected"   )]
        [InlineData( StatsType.YTD, "Year to Date")]
        [InlineData(StatsType.UNKN, "Unknown"     )]
        [InlineData(          null, "Unknown"     )]
        public void GetDescriptionTest(StatsType type, string description) => Assert.Equal(description, GetDescription(type));

        [Theory]
        [InlineData(StatsType.CMBD, "Combined"      )]
        [InlineData(StatsType.PROJ, "ProjecTED"     )]
        [InlineData( StatsType.YTD, "Year TO Date"  )]
        [InlineData(StatsType.UNKN, "unknown"       )]
        [InlineData(StatsType.UNKN, "Something Else")]
        [InlineData(StatsType.UNKN, null            )]
        public void GetFromDescriptionTest(StatsType type, string desc) => Assert.Equal(type, GetFromDescription<StatsType>(desc));

        [Theory]
        [InlineData(StatsType.CMBD, "cmbd"          )]
        [InlineData(StatsType.PROJ, "PROJ"          )]
        [InlineData( StatsType.YTD, "Ytd"           )]
        [InlineData(StatsType.UNKN, "unKN"          )]
        [InlineData(StatsType.UNKN, "Something Else")]
        [InlineData(StatsType.UNKN, null            )]
        public void GetFromKeyTest(StatsType type, string key) => Assert.Equal(type, GetFromKey<StatsType>(key));
    }
}