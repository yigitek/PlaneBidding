using System.Data;
using System.Numerics;

namespace BiddingService.Models;

public class Bidding
{
    public Guid Id { get; set;}
    public int ReservePrice { get; set; } = 0;
    public string Vendor { get; set; }
    public string WinningBidder { get; set;}
    public int? AmountSold { get; set; }
    public int? CurrentTopBid { get; set; }
    //postgres forces to use utctime
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public DateTime BiddingEnd { get; set; }
    public State State{ get; set; }
    public Aircraft Aircraft { get; set; }
}
