using MidTermProject.Processors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject
{
    public static class GlobalConfig
    {
        public const string STATISTICSBYAIRCRAFTCATEGORYFILE = "AircraftCategoryStats.csv";
        public const string STATISTICSBYCOUNTRYFILE = "CountryStats.csv";
        public const string STATISTICSBYPURPOSEOFFLIGHTFILE = "PurposeOfFlightStats.csv";
        public const string ACCIDENTBETWEENDATESSEARCHFILE = "AccidentsBetweenDates.csv";
        public const string ACCIDENTBYAIRPLANESEARCHFILE = "AccidentsByAirplane.csv";
        public const string ACCIDENTBYCOUNTRYSEARCHFILE = "AccidentsByCountry.csv";
        public const string TENMOSTFATALINJURIESFILE = "TMFI.csv";
        public const string TENMOSTSERIOUSINJURIESFILE = "TMSI.csv";
        public const string TENMOSTMINORINJURIESFILE = "TMMI.csv";
        public const string ACCIDENTBYAIRCARRIERSFILE = "AccidentsByCarrier.csv";
        public const string ACCIDENTBYWEATHERCONDITIONFILE = "AccidentsByWeather.csv";
        public static IUserProcessor User { get; private set; }

        /// <summary>
        /// Validate and initialize the user
        /// </summary>
        /// <param name="userType">User type</param>
        /// <returns></returns>
        private static bool InitializeUser(string userType)
        {
            int user = -1;
            bool validUser = int.TryParse(userType, out user);
            if (!validUser)
            {
                Console.WriteLine("Enter the number!");
                return false;
            }
            if (user - 1 == Convert.ToInt32(UserType.ROOT))
            {
                while (true)
                {
                    Console.Write("Enter the UserName:");
                    string userName = Console.ReadLine();
                    Console.Write("Enter the password:");
                    string password = Console.ReadLine();
                    if (IsUserValid(userName, password))
                    {
                        User = new RootUserProcessor();
                        return true;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Wrong username or password, try again!");
                    Console.WriteLine();
                }   
            }
            else if (user - 1 == Convert.ToInt32(UserType.SIMPLE))
            {
                User = new SimpleUserProcessor();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Open the security file and check if the given credentials are correct
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        private static bool IsUserValid(string userName,string password)
        {
            List<string> lines = File.ReadAllLines(ConfigurationManager.AppSettings["SecurityFilePath"]).ToList();
            foreach (string line in lines)
            {
                string[] elements = line.Split(',');
                if (userName == elements[0] && password == elements[1])
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Run the party
        /// </summary>
        public static void StartProgram()
        {
            DecoratorsAndUIMethods.UserLoginMenu();
            while (!GlobalConfig.InitializeUser(Console.ReadLine()))
            {
                Console.WriteLine();
                Console.WriteLine("Choose the correct number!");
                Console.WriteLine();
                DecoratorsAndUIMethods.UserLoginMenu();
            }
            Console.Clear();
            string userInput;
            while (true)
            {
                DecoratorsAndUIMethods.TypeOfRequestMenu();
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    if (DecoratorsAndUIMethods.StartSearching())
                    {
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    if (DecoratorsAndUIMethods.StartStatistic())
                    {
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                else if (userInput == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("Bye...");
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Wrong number, try again!");
                Console.WriteLine();
            }
        }
    }
}
