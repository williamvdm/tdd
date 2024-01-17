using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tdd.Server.Controllers;
using tdd.Server.Context;
using tdd.Server.Models;
using Xunit;

class FakeDb : DbContext, DbContextInterface
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BedrijfModel> Bedrijven { get; set; }
    public DbSet<ContactPersoonModel> Contactpersonen { get; set; }
    public DbSet<LocatieModel> Locaties { get; set; }
    public DbSet<OnderzoekModel> Onderzoeken { get; set; }
    public DbSet<AntwoordModel> Antwoorden { get; set; }
    public DbSet<BeantwoordModel> Beantwoord { get; set; }
    public DbSet<OpdrachtModel> Opdrachten { get; set; }
    public DbSet<VraagModel> Vragen { get; set; }
    public DbSet<AandoeningModel> Aandoeningen { get; set; }
    public DbSet<BeperkingModel> Beperkingen { get; set; }
    public DbSet<BeschikbaarheidModel> Beschikbaarheid { get; set; }
    public DbSet<HulpmiddelModel> Hulpmiddelen { get; set; }
    public DbSet<TrackingGegevensModel> TrackingGegevens { get; set; }
    public DbSet<VerzorgerModel> Verzorgers { get; set; }
    public DbSet<UserModel> Deelnemers { get; set; }

    public FakeDb(DbContextOptions<FakeDb> options) : base(options)
    {
        Users = Set<UserModel>();
        Bedrijven = Set<BedrijfModel>();
        Contactpersonen = Set<ContactPersoonModel>();
        Locaties = Set<LocatieModel>();
        Onderzoeken = Set<OnderzoekModel>();
        Antwoorden = Set<AntwoordModel>();
        Beantwoord = Set<BeantwoordModel>();
        Opdrachten = Set<OpdrachtModel>();
        Vragen = Set<VraagModel>();
        Aandoeningen = Set<AandoeningModel>();
        Beperkingen = Set<BeperkingModel>();
        Beschikbaarheid = Set<BeschikbaarheidModel>();
        Hulpmiddelen = Set<HulpmiddelModel>();
        TrackingGegevens = Set<TrackingGegevensModel>();
        Verzorgers = Set<VerzorgerModel>();
        Deelnemers = Set<UserModel>();
    }

    public void Add(OnderzoekModel item)
    {
        throw new NotImplementedException();
    }

    public void Remove(BedrijfModel item)
    {
        throw new NotImplementedException();
    }

    public void Remove(UserModel item)
    {
        Users.Remove(item);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}

public class UserControllerTests
{
    [Fact]
    public async Task GetUserListTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FakeDb>()
            .UseInMemoryDatabase(databaseName: "FakeDb")
            .Options;

        var db = new FakeDb(options);
        var controller = new UserController(db);

        // Act
        IActionResult result = await controller.GetUserListAsync();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<List<UserModel>>(okResult.Value);
        var userList = (List<UserModel>)okResult.Value;
    }

    [Fact]
    public async Task GetUserByIdTest_UserExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FakeDb>()
            .UseInMemoryDatabase(databaseName: "FakeDb")
            .Options;

        var db = new FakeDb(options);
        var controller = new UserController(db);
        var user = new UserModel { Id = Guid.NewGuid(), Email = "test@example.com" };
        db.Users.Add(user);

        // Act
        IActionResult result = await controller.GetUserByIdAsync(user.Id.ToString());

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = (OkObjectResult)result;
        Assert.IsType<UserModel>(okResult.Value);
        var returnedUser = (UserModel)okResult.Value;
        Assert.Equal(user.Id, returnedUser.Id);
    }

    [Fact]
    public async Task GetUserByIdTest_UserNotFound()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FakeDb>()
            .UseInMemoryDatabase(databaseName: "FakeDb")
            .Options;

        var db = new FakeDb(options);
        var controller = new UserController(db);

        // Act
        IActionResult result = await controller.GetUserByIdAsync(Guid.NewGuid().ToString());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
