using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroTrip2.Models
{
    public class TripRoute
    {
        [Key]
        public int Id { get; set; }

        public int Distance { get; set; }
        public int Source_Id { get; set; }

        [ForeignKey("Source_Id")]
        public Place? Source { get; set; }

        public int Destination_Id { get; set; }

        [ForeignKey("Destination_Id")]

        public Place? Destination { get; set; }      

        public ICollection<Trip>? Trips { get; set; }

    }
}
