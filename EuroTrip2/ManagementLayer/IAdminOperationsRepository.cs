using EuroTrip2.Contexts;
using EuroTrip2.Models;
using System.Security.Policy;

namespace EuroTrip2.ManagementLayer
{
    interface IAdminOperationsRepository
    {
        //Flights
        
        public Flight GetFlight(int id);
        public Flight CreateFlight(Flight flight);
        public Flight UpdateFlight(Flight flight);
        public Flight DeleteFlight(int id);

        public IEnumerable<Flight> GetAllFlights();


        //// places 
        //public Place GetPlace(int id);
        //public Place CreatePlace(Place place);
        //public Place UpdatePlace(Place place);
        //public Place DeletePlace(int id);

        //public IEnumerable<Place> GetAllPlaces();

        ////route
        //public TripRoute GetRoute(int id);
        //public TripRoute CreateRoute(TripRoute route);
        //public TripRoute UpdateRoute(TripRoute route);
        //public TripRoute DeleteRoute(int id );

        //public IEnumerable<TripRoute> GetAllRoutes();


        ////seats

        //public Seat GetSeat(int id);
        //public Seat CreateSeat(Seat seat);
        //public Seat UpdateSeat(Seat seat);
        //public Seat DeleteSeat(int id);

        //public IEnumerable<Seat> GetSeatsByFlight();
        



        ////Trips

        //public Trip GetTrip(int id);
        //public Trip CreateTrip(Trip trip);
        //public Trip UpdateTrip(Trip trip);
        //public Trip DeleteTrip(int id);
        

        //// TripRoute

        //public TripRoute GetTripRoute(int id);
        //public ICollection<TripRoute> GetAllTripRoutes();
        //public ICollection<TripRoute> GetTripRoutesByPlaces(int source_Id,int destination_Id);

        //public ICollection<TripRoute> GetTripRoutesByPlaces(Place source, Place destination);

        //public TripRoute CreateTripRoute (TripRoute tripRoute);

        //public TripRoute UpdateTripRoute(TripRoute tripRoute);

        //public TripRoute DeleteTripRoute(int id);


        //// user

        //public User GetUser(int id);
        //public User CreateUser(User user);
        //public User UpdateUser(User user);
        //public User DeleteUser(User user);

    

        


    }
}
