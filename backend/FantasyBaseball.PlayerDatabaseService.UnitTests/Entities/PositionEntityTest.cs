using FantasyBaseball.PlayerDatabaseService.Enums;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Entities.UnitTests
{
    public class PositionEntityTest
    {
        [Fact] public void DefaultsSetTest()
        {
            var obj = new PositionEntity();
            Assert.Null(obj.Code);
            Assert.Null(obj.FullName);
            Assert.Equal(PlayerType.U, obj.PlayerType);
            Assert.Equal(0, obj.SortOrder);
            Assert.Empty(obj.Players);
        }
    }
}