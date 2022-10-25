

using System.ComponentModel.DataAnnotations;

namespace EuroTrip2.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TripRoute>? Sources { get; set; }
        public ICollection<TripRoute>? Destinations { get; set; }
    }
}
