using VetClinic.DataAccess;
using VetClinic.DataAccess.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace VetClinic.UnitTest.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class ClientRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllClientsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var clients = new ClientEntity[]
            {
            new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new ClientEntity()
            {
                NameClient = "Test2",
                PhoneNumber = "Test2",
                Email = "Test2",
                PasswordHash = "Test2",
                ExternalId = Guid.NewGuid()
            }
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();

            //execute
            var repository = new Repository<ClientEntity>(DbContextFactory);
            var actualClients = repository.GetAll();

            //assert        
            actualClients.Should().BeEquivalentTo(clients, options => options.Excluding(x => x.Email)
                .Excluding(x => x.PhoneNumber));
        }

        [Test]
        public void GetAllClientsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var clients = new ClientEntity[]
            {
            new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new ClientEntity()
            {
                NameClient = "Test2",
                PhoneNumber = "Test2",
                Email = "Test2",
                PasswordHash = "Test2",
                ExternalId = Guid.NewGuid()
            }
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();
            //execute

            var repository = new Repository<ClientEntity>(DbContextFactory);
            var actualClients = repository.GetAll(x => x.NameClient == "Test2").ToArray();

            //assert
            actualClients.Should().BeEquivalentTo(clients.Where(x => x.NameClient == "Test2"),
                options => options.Excluding(x => x.Email)
                .Excluding(x => x.PhoneNumber));
        }

        [Test]
        public void SaveNewClientTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            //execute

            var client = new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<ClientEntity>(DbContextFactory);
            repository.Save(client);

            //assert
            var actualClient = context.Clients.SingleOrDefault();
            actualClient.Should().BeEquivalentTo(client, options => options.Excluding(x => x.Email)
                .Excluding(x => x.PhoneNumber)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualClient.Id.Should().NotBe(default);
            actualClient.ModificationTime.Should().NotBe(default);
            actualClient.CreationTime.Should().NotBe(default);
            actualClient.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateClientTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            //execute

            client.NameClient = "new name";
            var repository = new Repository<ClientEntity>(DbContextFactory);
            repository.Save(client);

            //assert
            var actualClient = context.Clients.SingleOrDefault();
            actualClient.Should().BeEquivalentTo(client, options => options.Excluding(x => x.Email)
                .Excluding(x => x.PhoneNumber));
        }


        [Test]
        public void DeleteClientTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            //execute

            var repository = new Repository<ClientEntity>(DbContextFactory);
            repository.Delete(client);

            //assert
            context.Clients.Count().Should().Be(0);
        }

        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var clients = new ClientEntity[]
            {
            new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new ClientEntity()
            {
                NameClient = "Test2",
                PhoneNumber = "Test2",
                Email = "Test2",
                PasswordHash = "Test2",
                ExternalId = Guid.NewGuid()
            }
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();

            //execute
            var repository = new Repository<ClientEntity>(DbContextFactory);
            var actualClient = repository.GetById(clients[0].Id);

            //assert
            actualClient.Should().BeEquivalentTo(clients[0]);
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var clients = new ClientEntity[]
            {
            new ClientEntity()
            {
                NameClient = "Test1",
                PhoneNumber = "Test1",
                Email = "Test1",
                PasswordHash = "Test1",
                ExternalId = Guid.NewGuid()
            },
            new ClientEntity()
            {
                NameClient = "Test2",
                PhoneNumber = "Test2",
                Email = "Test2",
                PasswordHash = "Test2",
                ExternalId = Guid.NewGuid()
            }
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();

            //execute
            var repository = new Repository<ClientEntity>(DbContextFactory);
            var actualClient = repository.GetById(clients[clients.Length - 1].Id + 1);

            //assert
            actualClient.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Clients.RemoveRange(context.Clients);
                context.SaveChanges();
            }
        }
    }
}
