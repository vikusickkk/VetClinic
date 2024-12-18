using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess;

namespace VetClinic.UnitTest.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class ReviewRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllReviewsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();
            var reviews = new ReviewEntity[]
            {
            new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
             new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test2",
                DateWriting = new DateTime(2021, 7, 7, 12, 30, 0),
                ExternalId = Guid.NewGuid()
            }
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();

            //execute
            var repository = new Repository<ReviewEntity>(DbContextFactory);
            var actualReviews = repository.GetAll();

            //assert        
            actualReviews.Should().BeEquivalentTo(reviews, options => options.Excluding(x => x.DateWriting)
                .Excluding(x => x.Admin)
                .Excluding(x => x.Client));
        }

        [Test]
        public void GetAllReviewsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();
            var reviews = new ReviewEntity[]
            {
            new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
             new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test2",
                DateWriting = new DateTime(2021, 7, 7, 12, 30, 0),
                ExternalId = Guid.NewGuid()
            }
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();
            //execute

            var repository = new Repository<ReviewEntity>(DbContextFactory);
            var actualReviews = repository.GetAll(x => x.Description == "Test2").ToArray();

            //assert
            actualReviews.Should().BeEquivalentTo(reviews.Where(x => x.Description == "Test2"),
                options => options.Excluding(x => x.DateWriting)
                .Excluding(x => x.Admin)
                .Excluding(x => x.Client));
        }

        [Test]
        public void SaveNewReviewTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();

            //execute
            var reviews = new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<ReviewEntity>(DbContextFactory);
            repository.Save(reviews);

            //assert
            var actualReview = context.Reviews.SingleOrDefault();
            actualReview.Should().BeEquivalentTo(reviews, options => options.Excluding(x => x.DateWriting)
                .Excluding(x => x.Admin)
                .Excluding(x => x.Client)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualReview.Id.Should().NotBe(default);
            actualReview.ModificationTime.Should().NotBe(default);
            actualReview.CreationTime.Should().NotBe(default);
            actualReview.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateReviewTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();

            var review = new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            };
            context.Reviews.Add(review);
            context.SaveChanges();

            //execute

            review.Description = "NewDescription";
            var repository = new Repository<ReviewEntity>(DbContextFactory);
            repository.Save(review);

            //assert
            var actualReview = context.Reviews.SingleOrDefault();
            actualReview.Should().BeEquivalentTo(review, options => options.Excluding(x => x.DateWriting)
                .Excluding(x => x.Admin)
                .Excluding(x => x.Client));
        }


        [Test]
        public void DeleteReviewTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();

            var review = new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            };
            context.Reviews.Add(review);
            context.SaveChanges();

            //execute

            var repository = new Repository<ReviewEntity>(DbContextFactory);
            repository.Delete(review);

            //assert
            context.Reviews.Count().Should().Be(0);
        }

        [Test]
        public void GetByIdTest_PositiveCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();
            var reviews = new ReviewEntity[]
            {
            new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
             new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test2",
                DateWriting = new DateTime(2021, 7, 7, 12, 30, 0),
                ExternalId = Guid.NewGuid()
            }
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();

            //execute
            var repository = new Repository<ReviewEntity>(DbContextFactory);
            var actualReviews = repository.GetById(reviews[0].Id);

            //assert
            actualReviews.Should().BeEquivalentTo(reviews[0]);
        }
        [Test]
        public void GetByIdTest_NegativeCase()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            
            var client = new ClientEntity()
            {
                NameClient = "MyClient",
                PhoneNumber = "MyClient",
                Email = "MyClient",
                PasswordHash = "MyClient",
                ExternalId = Guid.NewGuid()
            };
            context.Clients.Add(client);
            context.SaveChanges();

            var vetClinic = new VetClinicEntity()
            {
                Address = "MyVetClinic",
                PhoneNumber = "MyVetClinic",
                ExternalId = Guid.NewGuid()
            };
            context.VetClinics.Add(vetClinic);
            context.SaveChanges();

            var admin = new AdminEntity()
            {
                VetClinicID = vetClinic.Id,
                Email = "MyEmail",
                PasswordHash = "MyPasswordHash",
                ExternalId = Guid.NewGuid()
            };
            context.Admins.Add(admin);
            context.SaveChanges();
            var reviews = new ReviewEntity[]
            {
            new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test1",
                DateWriting = new DateTime(2022, 1, 17, 11, 0, 0),
                ExternalId = Guid.NewGuid()
            },
             new ReviewEntity()
            {
                ClientID = client.Id,
                AdminID = admin.Id,
                Description = "Test2",
                DateWriting = new DateTime(2021, 7, 7, 12, 30, 0),
                ExternalId = Guid.NewGuid()
            }
            };
            context.Reviews.AddRange(reviews);
            context.SaveChanges();

            //execute
            var repository = new Repository<ReviewEntity>(DbContextFactory);
            var actualReview = repository.GetById(reviews[reviews.Length - 1].Id + 1);

            //assert
            actualReview.Should().BeNull();
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
                context.Reviews.RemoveRange(context.Reviews);
                context.SaveChanges();
            }
        }
    }
}
