using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EuroTrip2.ModelView
{
    
    public class CompleteTrip 
    {
        
        public IEnumerable<TripView> TripViews { get; set; }
    }
}
