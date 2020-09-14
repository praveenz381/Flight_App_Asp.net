using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PMT.DataAccess
{
    public class Repository
    {
        PlanMyTripEntities PMTEntity = new PlanMyTripEntities();
        /// <summary>
        /// Adds a FlightSchedule entity object to the FlightSchedule table
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns>Returns 1 if successfully inserted else 0</returns>
        public int AddSchedule(FlightSchedule schedule)
        {
            PMTEntity.FlightSchedules.Add(schedule);
            return PMTEntity.SaveChanges();
        }

        /// <summary>
        /// Deletes the row which matches the id passed in the parameter list from the FlightSchedule table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns 1 if successfully deleted else 0</returns>
        public int RemoveSchedule(int id)
        {
            FlightSchedule schedule = PMTEntity.FlightSchedules.Find(id);
            PMTEntity.FlightSchedules.Remove(schedule);
            return PMTEntity.SaveChanges();
        }

        /// <summary>
        /// Gets the list of all the rows present in the FlightScedule table
        /// </summary>
        /// <returns>Returns list of all Flight Schedules</returns>
        public List<FlightSchedule> GetFlightSchedules()
        {
            return PMTEntity.FlightSchedules.ToList<FlightSchedule>();
        }

        /// <summary>
        /// Updates the row of the particular entity object passed
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns>Returns 1 if successfully updated else 0</returns>
        public int UpdateSchedule(FlightSchedule schedule)
        {
            PMTEntity.Entry(schedule).State = EntityState.Modified;
            return PMTEntity.SaveChanges();
        }


        /// <summary>
        /// Gets the row with the id passed in the parameter list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity object which matches the id</returns>
        public FlightSchedule GetSchedule(int id)
        {
            FlightSchedule schedule = PMTEntity.FlightSchedules.Find(id);
            return schedule;
        }


        public List<Flight> LoadFlights()
        {
            return PMTEntity.Flights.ToList<Flight>();
        }


        public List<Airport> LoadAirports()
        {
            return PMTEntity.Airports.ToList<Airport>();
        }
        /// <summary>
        /// It inserts a new row in the aiport table.
        /// </summary>
        /// <param name="newAirport">Object of the entity class Airport</param>
        /// <returns>Returns 1  If successfully inserted or returns 0 If not inserted</returns>
        public int AddAirport(Airport newAirport)
        {
            PMTEntity.Airports.Add(newAirport);
            return PMTEntity.SaveChanges();
        }
        /// <summary>
        /// It removes a row in the airport table.
        /// </summary>
        /// <param name="newAirport">Object of the entity class Airport</param>
        /// <returns>Returns 1  If successfully removed or returns 0 If not removed</returns>
        public int RemoveAirport(String AirportCode)
        {
            Airport airport = PMTEntity.Airports.Find(AirportCode);
            List<FlightSchedule> schedulesToRemove = new List<FlightSchedule>();
            foreach (FlightSchedule schedule in airport.FlightSchedules)
            {
                schedulesToRemove.Add(schedule);
            }
            foreach (FlightSchedule schedule in airport.FlightSchedules1)
            {
                schedulesToRemove.Add(schedule);
            }
            for (int i = 0; i < schedulesToRemove.Count; i++)
            {
                PMTEntity.FlightSchedules.Remove(schedulesToRemove[i]);
            }
            
            PMTEntity.Airports.Remove(airport);
            return PMTEntity.SaveChanges();

        }
        /// <summary>
        /// It displays the all the rows in the airport table
        /// </summary>
        /// <returns>All details of all airports inside the table</returns>
        public List<Airport> GetAirportDetails()
        {
            return PMTEntity.Airports.ToList<Airport>();
        }
        /// <summary>
        /// It modifies a row in the airport table.
        /// </summary>
        /// <param name="newAirport">Object of the entity class Airport</param>
        /// <returns>Returns 1  If successfully updated or returns 0 If not updated.</returns>
        public int UpdateAirport(Airport newAirport)
        {
            PMTEntity.Entry(newAirport).State = System.Data.Entity.EntityState.Modified;
            return PMTEntity.SaveChanges();
        }
        /// <summary>
        /// It displays a specific row in the airport table
        /// </summary>
        /// <param name="AirportCode">Object of the entity class Airport</param>
        /// <returns>Returns 1  If available or returns 0 If not available.</returns>
        public Airport GetAirport(String AirportCode)
        {
            Airport a = PMTEntity.Airports.Find(AirportCode);
            return a;
        }
        /// <summary>
        /// Adds a new row in the Flight table
        /// </summary>
        /// <param name="flight">Entity class object or row</param>
        /// <returns>1 if inserted / 0 if not inserted</returns>
        public int AddFlight(Flight flight)
        {
            PMTEntity.Flights.Add(flight);
            return PMTEntity.SaveChanges();
        }
        /// <summary>
        /// Removes a row from the Flight table
        /// </summary>
        /// <param name="flightnumber">Entity class parameter</param>
        /// <returns>1 if removed / 0 if not removed</returns>
        public int RemoveFlight(String flightnumber)
        {
            Flight flight = PMTEntity.Flights.Find(flightnumber);
            List<FlightSchedule> schedulesToRemove = new List<FlightSchedule>();
            foreach(FlightSchedule schedule in flight.FlightSchedules)
            {
                schedulesToRemove.Add(schedule);
            }
            for(int i=0;i<schedulesToRemove.Count;i++)
            {
                PMTEntity.FlightSchedules.Remove(schedulesToRemove[i]);
            }
            PMTEntity.Flights.Remove(flight);
            return PMTEntity.SaveChanges();
        }
        /// <summary>
        /// Displays all the rows in the Flight table
        /// </summary>
        /// <returns>List of objects or rows </returns>
        public List<Flight> GetFlights()
        {
            return PMTEntity.Flights.ToList<Flight>();
        }
        /// <summary>
        /// Modifies a row in the Flight table
        /// </summary>
        /// <param name="flight">Entity class object or row</param>
        /// <returns>1 if updated / 0 if not updated</returns>
        public int UpdateFlight(Flight flight)
        {
            PMTEntity.Entry(flight).State = System.Data.Entity.EntityState.Modified;
            return PMTEntity.SaveChanges();
        }
        public Flight GetFlight(String flightnumber)
        {
            Flight flight = PMTEntity.Flights.Find(flightnumber);
            return flight;
        }
        /// <summary>
        /// Validates the Login credentials of the user.
        /// </summary>
        /// <param name="username">E-mail ID of the user</param>
        /// <param name="password">Corresponding password</param>
        /// <returns>
        /// Returns the user object containing the username and password, if credentials valid.
        /// Else, returns null.
        /// </returns>
        public User Login(string username, string password)
        {
            User result = null;
            foreach (User user in PMTEntity.Users)
            {
                if (user.EmailId.Equals(username) && user.Password.Equals(password))
                {
                    result = user;
                    break;
                }
            }
            return result;
        }

        public int Register(User user)
        {
            PMTEntity.Users.Add(user);
            return PMTEntity.SaveChanges();
        }

        public List<FlightSchedule> SearchSchedule(string source,string dest,string date)
        {
            List<FlightSchedule> schedules = new List<FlightSchedule>();
            foreach(FlightSchedule f in PMTEntity.FlightSchedules)
            {
                if (f.Airport1.Location == source && f.Airport.Location == dest && f.DepartureTime.GetValueOrDefault().ToShortDateString() == date)
                /*if(f.Origin==source && f.Destination==dest && f.DepartureTime.GetValueOrDefault().ToShortDateString() == date)*/
                {
                    schedules.Add(f);
                }
            }
            return schedules;
        }


    }
}
