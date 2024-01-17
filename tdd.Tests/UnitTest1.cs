using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Controllers;
using tdd.Server.Context;
using tdd.Server.Models;
using Xunit;

namespace tdd.Tests
{
    class FakeDb : DbContextInterface
    {
        // TODO: find a way to make the getters and setters interact with these private lists
        private List<BedrijfModel> BedrijfModels = new List<BedrijfModel>();
        private List<ContactPersoonModel> ContactPersoonModels = new List<ContactPersoonModel>();

        DbSet<BedrijfModel> DbContextInterface.Bedrijven { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<ContactPersoonModel> DbContextInterface.Contactpersonen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<LocatieModel> DbContextInterface.Locaties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<OnderzoekModel> DbContextInterface.Onderzoeken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<AntwoordModel> DbContextInterface.Antwoorden { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<BeantwoordModel> DbContextInterface.Beantwoord { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<UserModel> DbContextInterface.Deelnemers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<OpdrachtModel> DbContextInterface.Opdrachten { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<VraagModel> DbContextInterface.Vragen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<UserModel> DbContextInterface.Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<AandoeningModel> DbContextInterface.Aandoeningen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<BeperkingModel> DbContextInterface.Beperkingen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<BeschikbaarheidModel> DbContextInterface.Beschikbaarheid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<HulpmiddelModel> DbContextInterface.Hulpmiddelen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<TrackingGegevensModel> DbContextInterface.TrackingGegevens { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<VerzorgerModel> DbContextInterface.Verzorgers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void DbContextInterface.Add(OnderzoekModel item)
        {
            throw new NotImplementedException();
        }

        void DbContextInterface.Remove(BedrijfModel item)
        {
            throw new NotImplementedException();
        }

        void DbContextInterface.Remove(UserModel item)
        {
            throw new NotImplementedException();
        }

        Task<int> DbContextInterface.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
    public class UserControllerTests
    {
        [Fact]
        public void UserListTest()
        {
            // Arrange
            var db = new FakeDb();
            
            // Act
            IActionResult result = new UserController(db).GetUserListAsync().GetAwaiter().GetResult();

            // Assert
            Assert.Equal("", result.ToString());
        }
    }
}
