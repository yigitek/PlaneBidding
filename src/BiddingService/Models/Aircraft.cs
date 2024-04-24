using System.ComponentModel.DataAnnotations.Schema;
using BiddingService.Models;

namespace BiddingService;
//annotating the table name to railroad EF to create table with the
//plural name
[Table("Aircrafts")]
public class Aircraft
{
        public Guid Id { get; set;}
        public string Company { get; set;}
        public string ModelNo { get; set;}
        public int BuildDate { get; set;}
        public string Colour { get; set;}
        public int Milage { get; set;}
        public string PhotoUrl { get; set;}

        //navs
        public Bidding Bidding { get; set;}
        public Guid BiddingId { get; set;}
}
