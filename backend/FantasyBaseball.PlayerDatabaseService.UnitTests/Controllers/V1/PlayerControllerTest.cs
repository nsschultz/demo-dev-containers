using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.PlayerDatabaseService.Exceptions;
using FantasyBaseball.PlayerDatabaseService.Models;
using FantasyBaseball.PlayerDatabaseService.Entities;
using FantasyBaseball.PlayerDatabaseService.Services;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerDatabaseService.Controllers.V1.UnitTests
{
    public class PlayerControllerTest
    {
        [Fact] public async void GetPlayersTest()
        {
            var getService = new Mock<IGetPlayersService>();
            getService.Setup(o => o.GetPlayers()).ReturnsAsync(new List<PlayerEntity> { new PlayerEntity() });
            var builderService = new Mock<IBaseballPlayerBuilderService>();
            builderService.Setup(o => o.BuildBaseballPlayer(It.IsAny<PlayerEntity>())).Returns(new BaseballPlayer());
            var sortService = new Mock<ISortService>();
            sortService.Setup(o => o.SortPlayers(It.IsAny<List<BaseballPlayer>>())).Returns((List<BaseballPlayer> players) => players);
            Assert.NotEmpty((await new PlayerController(builderService.Object, null, getService.Object, null, sortService.Object).GetPlayers()));
        }

        [Fact] public void GetPlayersEnumMapTest()
        {
            var expected = new Dictionary<int, string>() { { 0, "Available" }, { 1, "Rostered" }, { 2, "Unavailable" }, { 3, "Scouted" } };
            var getEnumMapService = new Mock<IGetPlayerEnumMapService>();
            getEnumMapService.Setup(o => o.GetPlayerEnumMap(It.Is<string>(i => "LeagueStatus".Equals(i)))).Returns(expected);
            Assert.Equal(expected, new PlayerController(null, getEnumMapService.Object, null, null, null).GetPlayersEnumMap("LeagueStatus"));
        }

        [Fact] public async void UpdatePlayersTest()
        {   
            var id = Guid.NewGuid();
            var updateService = new Mock<IPlayerUpdateService>();
            updateService.Setup(o => o.UpdatePlayer(It.Is<BaseballPlayer>(p => p.Id == id))).Returns(Task.FromResult(0));
            await new PlayerController(null, null, null, updateService.Object, null).UpdatePlayer(id, new BaseballPlayer { Id = id });
            updateService.VerifyAll();
        }

        [Fact] public void UpdatePlayersTestDifferentPlayerIds() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), new BaseballPlayer { Id = Guid.NewGuid() }));

        [Fact] public void UpdatePlayersTestEmptyPlayerId() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.Empty, new BaseballPlayer()));

        [Fact] public void UpdatePlayersTestNullPlayer() =>
            Assert.ThrowsAsync<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpdatePlayer(Guid.NewGuid(), null));
     }
}