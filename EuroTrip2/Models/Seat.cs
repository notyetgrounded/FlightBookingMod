using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroTrip2.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Flight_Id { get; set; }

        [ForeignKey("Flight_Id")]
        public Flight? Flight { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
