using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT.DataAccess;
using System.Collections.Generic;

namespace PMT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddAirport()
        {
            Repository r = new Repository();
            Airport newAirport = new Airport();
            newAirport.AirportCode = "111113";
            newAirport.AirportName = "Kamaraj";
            newAirport.Description = "In INDIA";
            newAirport.Location = "Chennai";
            int actual = r.AddAirport(newAirport);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void TestRemoveAirport()
        {
            Repository r = new Repository();
            Airport newAirport = new Airport();
            newAirport.AirportCode = "111112";

            int actual = r.RemoveAirport(newAirport.AirportCode);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void TestViewAirports()
        {
            Repository r = new Repository();
            List<Airport> airports = r.GetAirportDetails();
            Assert.AreEqual(2, airports.Count);
        }
        [TestMethod]
        public void TestEditAirport()
        {
            Repository r = new Repository();
            Airport newAirport = new Airport();
            newAirport.AirportCode = "111113";
            newAirport.AirportName = "Dadar";
            newAirport.Description = "In INDIA";
            newAirport.Location = "Mumbai";
            int actual = r.UpdateAirport(newAirport);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Infrastructure.DbUpdateException))]
        public void TestMethod1()
        {
            Repository rep = new Repository();
            FlightSchedule schedule = new FlightSchedule();
            schedule.FlightNumber = "SA12";
            schedule.Origin = "CHE001";
            schedule.Destination = "BAN001";
            schedule.DepartureTime = new DateTime(2019, 11, 15);
            schedule.ArrivalTime = new DateTime(2019,11,15);
            int actual = rep.AddSchedule(schedule);
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            Repository rep = new Repository();
            
            int actual = rep.RemoveSchedule(5);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Repository rep = new Repository();
            FlightSchedule schedule = new FlightSchedule();
            List<FlightSchedule> flights = rep.GetFlightSchedules();
            int actual = flights.Count;
            Assert.AreEqual(1, actual);
        }

        [TestMethod]        
        public void TestMethod4()
        {
            Repository rep = new Repository();
            FlightSchedule schedule = new FlightSchedule();
            schedule.Id = 6;
            schedule.FlightNumber = "IND687";
            schedule.Origin = "CHE001";
            schedule.Destination = "BAN001";
            schedule.DepartureTime = new DateTime(2019, 11, 15);
            schedule.ArrivalTime = new DateTime(2019, 11, 15);
            int actual = rep.UpdateSchedule(schedule);
            Assert.AreEqual(1, actual);
        }


        [TestMethod]
        public void TestMethod5()
        {
            Repository rep = new Repository();
            FlightSchedule schedule = new FlightSchedule();
            schedule.FlightNumber = "AID87";
            schedule.Origin = "CHE001";
            schedule.Destination = "BAN001";
            schedule.DepartureTime = new DateTime(2019, 11, 15);
            schedule.ArrivalTime = new DateTime(2019, 11, 15);
            int actual = rep.AddSchedule(schedule);

        }
        [TestMethod]
        public void TestAddFlight()
        {
            Repository test = new Repository();
            Flight flight = new Flight();
            flight.FlightName = "Air India";
            flight.FlightNumber = "654321";
            flight.SeatsCapacity = 200;
            flight.NoOfSeatsAvailable = 200;
            int actual = test.AddFlight(flight);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void TestRemoveFlight()
        {
            Repository test = new Repository();
            Flight flight = new Flight();
            flight.FlightNumber = "123456";
            int actual = test.RemoveFlight(flight.FlightNumber);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void TestGetFlights()
        {
            Repository test = new Repository();
            List<Flight> flights = test.GetFlights();
            Assert.AreEqual(1, flights.Count);
        }
        [TestMethod]
        public void TestUpdateFlight()
        {
            Repository test = new Repository();
            Flight flight = new Flight();
            flight.FlightName = "Air Asia";
            flight.FlightNumber = "654321";
            flight.SeatsCapacity = 300;
            flight.NoOfSeatsAvailable = 300;
            int actual = test.UpdateFlight(flight);
            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        public void TestLogin()
        {
            Repository r = new Repository();

            User user = r.Login("pmt@pmt.com", "password");

            Assert.IsNotNull(user);
        }
    }
}
