
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroTrip2.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SourceTime { get; set; }
        public DateTime DestinationTime { get; set; }
        public int PassengerCount { get; set; }

        public int? Flight_Id { get; set; }

        [ForeignKey("Flight_Id")]
        public Flight Flight { get; set; }

        
        public int TripRoute_Id { get; set; }

        [ForeignKey("TripRoute_Id")]
        public TripRoute TripRoute { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
