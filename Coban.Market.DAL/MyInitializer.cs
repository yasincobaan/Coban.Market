using System;
using System.Data.Entity;
using Coban.Market.Entities;
using Coban.Market.Entities.Enums;

namespace Coban.Market.DAL
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            MarketUser admin = new MarketUser()
            {
                Name = "Yasin",
                Surname = "Çoban",
                Email = "yasincobaan@gmail.com",
                Username = "yasincoban",
                Password = "123456",
                ActivateGuid = Guid.NewGuid(),
                ProfileImageFilename = "user_boy.png",
                IsActive = true,
                Role = MarketUserRole.Admin,
                Job = "Admin",
                Facebook = "https://www.facebook.com/yasiincobaan",
                Instagram = "https://www.instagram.com/yasiincoban/",
                Twitter = "null",
                Phone = "+905425314977",
                RewardScore = 30,
                CreatedOn = DateTime.Now,
                CreatedUsername = "systemAuth",
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "systemAuth"
            };
            context.MarketUsers.Add(admin);
            context.SaveChanges();
            for (int i = 0; i < 8; i++)
            {
                MarketUser user = new MarketUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ProfileImageFilename = "user_boy.png",
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    Role = MarketUserRole.NewUser,
                    Job = "User",
                    Username = $"user{i}",
                    Password = "123",
                    Facebook = "https://www.facebook.com/yasiincobaan",
                    Instagram = "https://www.instagram.com/yasiincoban/",
                    Twitter = "null",
                    Phone = "+905425314977",
                    RewardScore = 30,
                    CreatedOn = DateTime.Now,
                    CreatedUsername = "systemAuth",
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = "systemAuth"

                };
                context.MarketUsers.Add(user);
            }
            context.SaveChanges();
            Category catMain = new Category()
            {
                Title = "Main Category",
                Description = FakeData.PlaceData.GetAddress(),
                Image = "cat_1",
                CreatedOn = DateTime.Now,
                CreatedUsername = "systemAuth",
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "systemAuth"
            };
            context.Categories.Add(catMain);
            context.SaveChanges();
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    Image = "cat_{i}",
                    CategoryId = 1,
                    CreatedOn = DateTime.Now,
                    CreatedUsername = "systemAuth",
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = "systemAuth"
                };
                context.Categories.Add(cat);
            }
            context.SaveChanges();
            for (int i = 0; i < 10; i++)
            {
                Product prd = new Product()
                {
                    ProductName = FakeData.NameData.GetCompanyName(),
                    ProductBrand = FakeData.NameData.GetCompanyName(),
                    ExchangeRate = PriceExchangeRate.Dollar,
                    Price = 1000,
                    DiscountedPrice = 10,
                    TaxPercent = 18,
                    Image1 = "prd_1_{i}",
                    Image2 = "prd_2_{i}",
                    Image3 = "prd_3_{i}",
                    Image4 = "prd_4_{i}",
                    Description = FakeData.PlaceData.GetAddress(),
                    LittleDescription = FakeData.PlaceData.GetAddress(),
                    IsSale = true,
                    BarCode = FakeData.TextData.GetNumeric(20),
                    StockCode = FakeData.TextData.GetNumeric(20),
                    Stock = FakeData.NumberData.GetNumber(),
                    CategoryId = 2,
                    CreatedOn = DateTime.Now,
                    CreatedUsername = "systemAuth",
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = "systemAuth"
                };
                context.Products.Add(prd);
            }
            context.SaveChanges();

        }
    }
}
