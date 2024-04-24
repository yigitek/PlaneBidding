using BiddingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.Data;

public class BiddingDbContext : DbContext
{
    public BiddingDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Bidding> Biddings { get; set; }
}
