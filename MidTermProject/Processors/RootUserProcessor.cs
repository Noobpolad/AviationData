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
    public class RootUserProcessor : IUserProcessor
    {
        //List of flights
        private List<IUser> flightsInfo = new List<IUser>();

        /// <summary>
        /// Initialize all flights.
        /// </summary>
        public RootUserProcessor()
        {
            List<string> flights = File.ReadLines(ConfigurationManager.AppSettings["DataPathFilePath"]).ToList();
            for (int i = 1; i < flights.Count; i++)
            {
                string[] elements = flights[i].Split('|');
                RootUserModel rum = new RootUserModel(elements);
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
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.ACCIDENTBETWEENDATESSEARCHFILE, "Between", $"{From.Day}/{From.Month}/{From.Year} and {To.Day}/{To.Month}/{To.Year}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents between {From.Day}/{From.Month}/{From.Year} and {To.Day}/{To.Month}/{To.Year}");
            }
        }

        /// <summary>
        /// Search for an accidents with a given Air Carrier, display the accidents and save them to the file. 
        /// </summary>
        /// <param name="AirCarrier">Air Carrier name</param>
        public void AccidentsByAirCarrier(string AirCarrier)
        {
            List<IUser> flights = flightsInfo.Where(x => x.AirCarrier.Trim() == AirCarrier && AirCarrier != "").ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.ACCIDENTBYAIRCARRIERSFILE, "AirCarrier", $"{AirCarrier}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents by {AirCarrier} air carrier");
            }
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
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.ACCIDENTBYAIRPLANESEARCHFILE, "Airplane", $"{AircraftCategory}");
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
            List<IUser> flights = flightsInfo.Where(x => x.Country.Trim() == Country && Country != "").ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.ACCIDENTBYCOUNTRYSEARCHFILE, "Country", $"{Country}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents in {Country}");
            }
        }

        /// <summary>
        /// Search for an accidents with a given Weather conditions, display the accidents and save them to the file. 
        /// </summary>
        /// <param name="WCondition">Type of conditions</param>
        public void AccidentsByWeatherCondition(string WCondition)
        {
            List<IUser> flights = flightsInfo.Where(x => x.WeatherCondition.Trim() == WCondition && WCondition != "").ToList();
            if (flights.Count == 0)
            {
                DecoratorsAndUIMethods.NoInformationFoundMessage();
                return;
            }
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.ACCIDENTBYWEATHERCONDITIONFILE, "Weather Conditions", $"{WCondition}");
            foreach (var flight in flights)
            {
                flight.DecorateWithTitle($"Accidents in {WCondition} weather condition");
            }
        }

        /// <summary>
        /// Gather statistic for an accidents with a given Aircarft category, display the accidents and save them to the file. 
        /// </summary>
        public void AccidentStatisticByAircraftCategory()
        {
            var flights = flightsInfo.Where(x => x.InvestigationType.Trim() == "Accident" && x.AircraftCategory.Trim().Length != 0).GroupBy(x => x.AircraftCategory).ToList();
            flights.SaveStatistic(HelperMethods.GetTheRootFolderPath() + GlobalConfig.STATISTICSBYAIRCRAFTCATEGORYFILE, "AircraftCategory");
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
            flights.SaveStatistic(HelperMethods.GetTheRootFolderPath() + GlobalConfig.STATISTICSBYCOUNTRYFILE, "Country");
            flights.DecorateStatisticWithTitle("Accidents by country");

        }

        /// <summary>
        /// Gather statistic for an accidents with a given Purpose of flight, display the accidents and save them to the file. 
        /// </summary>
        public void AccidentStatisticByPurposeOfFlight()
        {
            var flights = flightsInfo.Where(x => x.InvestigationType.Trim() == "Accident" && x.PurposeOfFlight.Trim().Length != 0).GroupBy(x => x.PurposeOfFlight).ToList();
            flights.SaveStatistic(HelperMethods.GetTheRootFolderPath() + GlobalConfig.STATISTICSBYPURPOSEOFFLIGHTFILE, "PurposeOfFlight");
            flights.DecorateStatisticWithTitle("Accidents by purpose of flight");

        }

        /// <summary>
        /// Gather statistic for an accidents with Ten Most Fatal Injuries, display the accidents and save them to the file. 
        /// </summary>
        public void TenMostFatalInjuries()
        {
            List<IUser> flights = flightsInfo.Where(x => x.TotalFatalInjuries.Trim().Length != 0).OrderByDescending(x => Convert.ToInt32(x.TotalFatalInjuries.Trim())).ToList();
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.TENMOSTFATALINJURIESFILE);
            for (int i = 0; i < 10; i++)
            {
                flights[i].DecorateWithTitle($"Ten most fatal injuries");
            }
        }

        /// <summary>
        /// Gather statistic for an accidents with Ten Most Minor Injuries, display the accidents and save them to the file. 
        /// </summary>
        public void TenMostMinorInjuries()
        {
            List<IUser> flights = flightsInfo.Where(x => x.TotalMinorInjuries.Trim().Length != 0).OrderByDescending(x => Convert.ToInt32(x.TotalMinorInjuries.Trim())).ToList();
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.TENMOSTSERIOUSINJURIESFILE);
            for (int i = 0; i < 10; i++)
            {
                flights[i].DecorateWithTitle($"Ten most minor injuries");
            }
        }

        /// <summary>
        /// Gather statistic for an accidents with Ten Most Serious Injuries, display the accidents and save them to the file. 
        /// </summary>
        public void TenMostSeriousInjuries()
        {
            List<IUser> flights = flightsInfo.Where(x => x.TotalSeriousInjuries.Trim().Length != 0).OrderByDescending(x => Convert.ToInt32(x.TotalSeriousInjuries.Trim())).ToList();
            flights.SaveSearchResults(HelperMethods.GetTheRootFolderPath() + GlobalConfig.TENMOSTMINORINJURIESFILE);
            for (int i = 0; i < 10; i++)
            {
                flights[i].DecorateWithTitle($"Ten most serious injuries");
            }
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
