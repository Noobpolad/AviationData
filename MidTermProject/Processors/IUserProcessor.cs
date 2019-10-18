using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Processors
{
    public interface IUserProcessor
    {
        //Searching
        void AccidentsByCountry(string Country);
        void AccidentsBetweenDates(DateTime From, DateTime To);
        void AccidentsByAirplane(string AirplaneType);
        void TenMostFatalInjuries();
        void TenMostSeriousInjuries();
        void TenMostMinorInjuries();
        void TwentyMostCrowdedFlights();
        void AccidentsByAirCarrier(string AirCarrier);
        void AccidentsByWeatherCondition(string WCondition);

        //Statistics gathering
        void AccidentStatisticByCountry();
        void AccidentStatisticByAirplaneType();
        void AccidentStatisticByAircraftCategory();
        void AccidentStatisticByPurposeOfFlight();

    }
}
