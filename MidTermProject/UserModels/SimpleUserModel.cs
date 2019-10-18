using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.UserModels
{
    public class SimpleUserModel : IUser
    {
        //Accessible properties
        public string ID { get; set; }
        public string InvestigationType { get; set; }
        public string EventDate { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string AirportName { get; set; }
        public string InjurySeverity { get; set; }
        public string AircraftDamage { get; set; }
        public string AircraftCategory { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BroadPhaseOfFlight { get; set; }
        public string PublicationDate { get; set; }

        //Unaccessible properties
        public string AccidentNumber { get { return "Access denied"; } set { } }
        public string Latitute { get { return "Access denied"; } set { } }
        public string Longtitude { get { return "Access denied"; } set { } }
        public string AirportCode { get { return "Access denied"; } set { } }
        public string RegistrationNumber { get { return "Access denied"; } set { } }
        public string AmateurBuilt { get { return "Access denied"; } set { } }
        public string NumberOfEngines { get { return "Access denied"; } set { } }
        public string EngineType { get { return "Access denied"; } set { } }
        public string FARDescription { get { return "Access denied"; } set { } }
        public string Schedule { get { return "Access denied"; } set { } }
        public string PurposeOfFlight { get { return "Access denied"; } set { } }
        public string AirCarrier { get { return "Access denied"; } set { } }
        public string TotalFatalInjuries { get { return "Access denied"; } set { } }
        public string TotalSeriousInjuries { get { return "Access denied"; } set { } }
        public string TotalMinorInjuries { get { return "Access denied"; } set { } }
        public string TotalInjured { get { return "Access denied"; } set { } }
        public string WeatherCondition { get { return "Access denied"; } set { } }
        public string ReportStatus { get { return "Access denied"; } set { } }

        public SimpleUserModel(string[] list)
        {
            ID = list[0];
            InvestigationType = list[1];
            EventDate = list[3];
            Location = list[4];
            Country = list[5];
            AirportName = list[9];
            InjurySeverity = list[10];
            AircraftDamage = list[11];
            AircraftCategory = list[12];
            Make = list[14];
            Model = list[15];
            BroadPhaseOfFlight = list[28];
            PublicationDate = list[30];
        }
    }
}
