using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.UserModels
{
    public class RootUserModel : IUser
    {
        public string ID { get; set; }
        public string InvestigationType { get; set; }
        public string AccidentNumber { get; set; }
        public string EventDate { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Latitute { get; set; }
        public string Longtitude { get; set; }
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string InjurySeverity { get; set; }
        public string AircraftDamage { get; set; }
        public string AircraftCategory { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string AmateurBuilt { get; set; }
        public string NumberOfEngines { get; set; }
        public string EngineType { get; set; }
        public string FARDescription { get; set; }
        public string Schedule { get; set; }
        public string PurposeOfFlight { get; set; }
        public string AirCarrier { get; set; }
        public string TotalFatalInjuries { get; set; }
        public string TotalSeriousInjuries { get; set; }
        public string TotalMinorInjuries { get; set; }
        public string TotalInjured { get; set; }
        public string WeatherCondition { get; set; }
        public string BroadPhaseOfFlight { get; set; }
        public string ReportStatus { get; set; }
        public string PublicationDate { get; set; }

        /// <summary>
        /// Use reflection to initialize the properties
        /// </summary>
        /// <param name="list"></param>
        public RootUserModel(string[] list)
        {
            var listOfProperties = this.GetType().GetProperties();
            for (int i = 0; i < 31; i++)
            {
                listOfProperties[i].SetValue(this, list[i]);
            }
        }

    }
}
