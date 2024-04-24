using System.ComponentModel.DataAnnotations;

namespace BiddingService.DTOs;

public class CreateBiddingDto
{
    [Required]
    public string Company { get; set;}
    [Required]
    public string ModelNo { get; set;}
    [Required]
    public int BuildDate { get; set;}
    [Required]
    public string Colour { get; set;}
    [Required]
    public int Milage { get; set;}
    [Required]
    public string PhotoUrl { get; set;}
    [Required]
    public int ReservePrice { get; set;}
    [Required]
    public DateTime BiddingEnd { get; set; }
}
