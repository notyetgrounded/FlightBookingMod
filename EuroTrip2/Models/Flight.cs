using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroTrip2.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; } 
        
        public int Price { get; set; }

        public ICollection<Seat>? Seats { get; set; }
        public ICollection<Trip>? Trips { get; set; }

        
    }
}
