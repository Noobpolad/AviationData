using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.UserModels
{
    public interface IUser
    {
        string ID { get; set; }
        string InvestigationType { get; set; }
        string AccidentNumber { get; set; }
        string EventDate { get; set; }
        string Location { get; set; }
        string Country { get; set; }
        string Latitute { get; set; }
        string Longtitude { get; set; }
        string AirportCode { get; set; }
        string AirportName { get; set; }
        string InjurySeverity { get; set; }
        string AircraftDamage { get; set; }
        string AircraftCategory { get; set; }
        string RegistrationNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string AmateurBuilt { get; set; }
        string NumberOfEngines { get; set; }
        string EngineType { get; set; }
        string FARDescription { get; set; }
        string Schedule { get; set; }
        string PurposeOfFlight { get; set; }
        string AirCarrier { get; set; }
        string TotalFatalInjuries { get; set; }
        string TotalSeriousInjuries { get; set; }
        string TotalMinorInjuries { get; set; }
        string TotalInjured { get; set; }
        string WeatherCondition { get; set; }
        string BroadPhaseOfFlight { get; set; }
        string ReportStatus { get; set; }
        string PublicationDate { get; set; }
    }
}
