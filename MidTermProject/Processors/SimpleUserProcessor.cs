using MidTermProject.UserModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Processors
{
    public class SimpleUserProcessor : IUserProcessor
    {
        //List of flights
        private List<IUser> flightsInfo = new List<IUser>();

        /// <summary>
        /// Initialize all flights.
        /// </summary>
        public SimpleUserProcessor()
        {
            List<string> flights = File.ReadLines(ConfigurationManager.AppSettings["DataPathFilePath"]).ToList();
            for (int i = 1; i < flights.Count; i++)
            {
                string[] elements = flights[i].Split('|');
                SimpleUserModel rum = new SimpleUserModel(elements);
                flightsInfo.Add(rum);
            }
        }

        /// <summary>
        /// Search for an accidents between the given dates, display the accidents and save them to the file.
        /// </summary>
        /// <param name="From">From date</param>
        /// <summary>
        /// Initialize all flights.
        /// </summary>
        /// <param name="To">To date</param>
        public void AccidentsBetweenDates(DateTime From, DateTime To)
        {
            List<IUser> flights = flightsInfo.Where(x => Convert.ToDateTime(x.EventDate).IsBetween(From, To)).ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheSimpleFolderPath() + GlobalConfig.ACCIDENTBETWEENDATESSEARCHFILE, "Between", $"{From.Day}/{From.Month}/{From.Year} and {To.Day}/{To.Month}/{To.Year}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents between {From.Day}/{From.Month}/{From.Year} and {To.Day}/{To.Month}/{To.Year}");
            }
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void AccidentsByAirCarrier(string AirCarrier)
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Search for an accidents with a given Aircraft Category, display the accidents and save them to the file. 
        /// </summary>
        /// <param name="AircraftCategory">Aircraft Category</param>
        public void AccidentsByAirplane(string AircraftCategory)
        {
            List<IUser> flights = flightsInfo.Where(x => x.AircraftCategory.Trim() == AircraftCategory && AircraftCategory != "").ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheSimpleFolderPath() + GlobalConfig.ACCIDENTBYAIRPLANESEARCHFILE, "Airplane", $"{AircraftCategory}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents with {AircraftCategory}");
            }
        }

        /// <summary>
        /// Search for an accidents with a given Country, display the accidents and save them to the file. 
        /// </summary>
        /// <param name="Country">Country name</param>
        public void AccidentsByCountry(string Country)
        {
            List<IUser> flights = flightsInfo.Where(x => x.Country.Trim() == Country).ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheSimpleFolderPath() + GlobalConfig.ACCIDENTBYCOUNTRYSEARCHFILE, "Country", $"{Country}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents in {Country}");
            }
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void AccidentsByWeatherCondition(string WCondition)
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Gather statistic for an accidents with a given Aircarft category, display the accidents and save them to the file. 
        /// </summary>
        public void AccidentStatisticByAircraftCategory()
        {
            var flights = flightsInfo.Where(x => x.InvestigationType.Trim() == "Accident" && x.AircraftCategory.Trim().Length != 0).GroupBy(x => x.AircraftCategory).ToList();
            flights.SaveStatistic(HelperMethods.GetTheSimpleFolderPath() + GlobalConfig.STATISTICSBYAIRCRAFTCATEGORYFILE, "AircraftCategory");
            flights.DecorateStatisticWithTitle("Accidents by Aircraft category");
        }

        /// <summary>
        /// Display that no information available
        /// </summary>
        public void AccidentStatisticByAirplaneType()
        {
            DecoratorsAndUIMethods.NoInformationFoundMessage();
        }

        /// <summary>
        /// Gather statistic for an accidents with a given Country, display the accidents and save them to the file. 
        /// </summary>
        public void AccidentStatisticByCountry()
        {
            var flights = flightsInfo.Where(x => x.InvestigationType.Trim() == "Accident" && x.Country.Trim().Length != 0).GroupBy(x => x.Country).ToList();
            flights.SaveStatistic(HelperMethods.GetTheSimpleFolderPath() + GlobalConfig.STATISTICSBYCOUNTRYFILE, "Country");
            flights.DecorateStatisticWithTitle("Accidents by country");
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void AccidentStatisticByPurposeOfFlight()
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void TenMostFatalInjuries()
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void TenMostMinorInjuries()
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void TenMostSeriousInjuries()
        {
            DecoratorsAndUIMethods.AccessDeniedMessage();
        }

        /// <summary>
        /// Display that no information available 
        /// </summary>
        public void TwentyMostCrowdedFlights()
        {
            DecoratorsAndUIMethods.NoInformationFoundMessage();
        }
    }
}
