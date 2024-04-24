using BiddingService.Data;
using BiddingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingService;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        InitializeData(scope.ServiceProvider.GetService<BiddingDbContext>());
    }

    private static void InitializeData(BiddingDbContext context)
    {
        context.Database.Migrate();

        if(context.Biddings.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var biddings = new List<Bidding>()
        {

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 120000,
                Vendor = "Bober",
                BiddingEnd = DateTime.UtcNow.AddDays(30),
                Aircraft = new Aircraft
                {
                    Company = "Cessna",
                    ModelNo = "172",
                    Colour = "White",
                    Milage = 1550000,
                    BuildDate = 1993,
                    PhotoUrl = "https://www.flyhpa.com/files/2018/10/2018.10.03-02.03-flyhpa-5bb4238cb83cf.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 1900000,
                Vendor = "Smith",
                BiddingEnd = DateTime.UtcNow.AddDays(25),
                Aircraft = new Aircraft
                {
                    Company = "Airbus",
                    ModelNo = "A320",
                    Colour = "Blue",
                    Milage = 1000000,
                    BuildDate = 2005,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Airbus_A320-214%2C_Airbus_Industrie_JP7617615.jpg/450px-Airbus_A320-214%2C_Airbus_Industrie_JP7617615.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 1100000,
                Vendor = "Johnson",
                BiddingEnd = DateTime.UtcNow.AddDays(35),
                Aircraft = new Aircraft
                {
                    Company = "Boeing",
                    ModelNo = "737",
                    Colour = "Red",
                    Milage = 800000,
                    BuildDate = 2010,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/70/ENTERAIR6-SPENB.jpg/240px-ENTERAIR6-SPENB.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 150000,
                Vendor = "Smith",
                BiddingEnd = DateTime.UtcNow.AddDays(32),
                Aircraft = new Aircraft
                {
                    Company = "Cirrus",
                    ModelNo = "SR22",
                    Colour = "White",
                    Milage = 900000,
                    BuildDate = 2007,
                    PhotoUrl = "https://www.aircraft24.pl/images/aircraftpics/14/pic_136814_1_xxl.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 1750000,
                Vendor = "Martin",
                BiddingEnd = DateTime.UtcNow.AddDays(29),
                Aircraft = new Aircraft
                {
                    Company = "Bombardier",
                    ModelNo = "Global 6000",
                    Colour = "Black",
                    Milage = 400000,
                    BuildDate = 2018,
                    PhotoUrl = "https://static.vecdn.net/images/aircraft/bombardier-global-6000/aircraft.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 65000,
                Vendor = "Brown",
                BiddingEnd = DateTime.UtcNow.AddDays(26),
                Aircraft = new Aircraft
                {
                    Company = "Diamond Aircraft",
                    ModelNo = "DA40",
                    Colour = "Blue",
                    Milage = 1100000,
                    BuildDate = 2004,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Diamond_DA40_%288736184864%29.jpg/450px-Diamond_DA40_%288736184864%29.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 750000,
                Vendor = "Garcia",
                BiddingEnd = DateTime.UtcNow.AddDays(30),
                Aircraft = new Aircraft
                {
                    Company = "Gulfstream",
                    ModelNo = "G650",
                    Colour = "Gold",
                    Milage = 300000,
                    BuildDate = 2019,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d6/G-ULFS_Gulfstream_G650_CVT_05-05-16_%2827046023031%29_%28cropped%29.jpg/1024px-G-ULFS_Gulfstream_G650_CVT_05-05-16_%2827046023031%29_%28cropped%29.jpg"
                }
            },

            new Bidding
            {
                Id = Guid.NewGuid(),
                State = State.Ongoing,
                ReservePrice = 120000,
                Vendor = "Wilson",
                BiddingEnd = DateTime.UtcNow.AddDays(31),
                Aircraft = new Aircraft
                {
                    Company = "Mooney",
                    ModelNo = "M20",
                    Colour = "Red",
                    Milage = 950000,
                    BuildDate = 1998,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Mooney.m20j.g-muni.arp.jpg/1024px-Mooney.m20j.g-muni.arp.jpg"
                }
            }                        

        };

        context.AddRange(biddings);

        context.SaveChanges();
    }
}
