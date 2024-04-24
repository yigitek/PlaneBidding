namespace BiddingService.DTOs;

public class BiddingDto
{
    public Guid Id { get; set;}
    public int ReservePrice { get; set; }
    public string Vendor { get; set; }
    public string WinningBidder { get; set;}
    public int AmountSold { get; set; }
    public int CurrentTopBid { get; set; }
    //postgres forces to use utctime
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public DateTime BiddingEnd { get; set; }
    public string State{ get; set; }
    public string Company { get; set;}
    public string ModelNo { get; set;}
    public int BuildDate { get; set;}
    public string Colour { get; set;}
    public int Milage { get; set;}
    public string PhotoUrl { get; set;}

}
