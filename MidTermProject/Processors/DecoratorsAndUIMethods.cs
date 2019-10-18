using MidTermProject.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermProject.Processors
{
    public static class DecoratorsAndUIMethods
    {
        private const int TITLELENGTH = 38;

        /// <summary>
        /// Dislay that no information found
        /// </summary>
        public static void NoInformationFoundMessage()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("|    No information found    |");
            Console.WriteLine(new string('-', 30));
        }

        /// <summary>
        /// Display that no accessible information found
        /// </summary>
        public static void AccessDeniedMessage()
        {
            Console.WriteLine(new string('-', 51));
            Console.WriteLine("|    You don't have access to this information!   |");
            Console.WriteLine(new string('-', 51));
        }

        /// <summary>
        /// Display the user login menu
        /// </summary>
        public static void UserLoginMenu()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("| Select the user type:      |");
            Console.WriteLine("| (1) Root                   |");
            Console.WriteLine("| (2) Simple User            |");
            Console.WriteLine(new string('-', 30));
            Console.Write("Enter the corresponding number:");
        }

        /// <summary>
        /// Display the type of request menu
        /// </summary>
        public static void TypeOfRequestMenu()
        {
            Console.WriteLine(new string('-', 32));
            Console.WriteLine("| Select the type of request:  |");
            Console.WriteLine("| (1) Search                   |");
            Console.WriteLine("| (2) Statistic                |");
            Console.WriteLine(new string('-', 32));
            Console.Write("Enter the type of search you want to perform:");
        }

        /// <summary>
        /// Display the statistic categories menu
        /// </summary>
        public static void StatisticCategoriesMenu()
        {
            Console.WriteLine(new string('-', 34));
            Console.WriteLine("| Choose the key for statistic:  |");
            Console.WriteLine("| (1) Stats by country           |");
            Console.WriteLine("| (2) Stats by Airplane type     |");
            Console.WriteLine("| (3) Stats by Purpose of flight |");
            Console.WriteLine("| (4) Stats by category          |");
            Console.WriteLine("| (5) Back to previous menu...   |");
            Console.WriteLine(new string('-', 34));
        }

        /// <summary>
        /// Display the search categories menu
        /// </summary>
        public static void SearchCategoriesMenu()
        {
            Console.WriteLine(new string('-', 64));
            Console.WriteLine("| Choose the category for searching:                           |");
            Console.WriteLine("| (1) Accidents by country...                                  |");
            Console.WriteLine("| (2) Accidents between dates...                               |");
            Console.WriteLine("| (3) Accidents by plane type...                               |");
            Console.WriteLine("| (4) Accidents by air carrier...                              |");
            Console.WriteLine("| (5) Accidents by weather conditions...                       |");
            Console.WriteLine("| (6) The ten first accidents with most Total Fatal Injuries   |");
            Console.WriteLine("| (7) The ten first accidents with most Total Serious Injuries |");
            Console.WriteLine("| (8) The ten first accidents with most Total Minor Injuries   |");
            Console.WriteLine("| (9) Back to the previous menu...                             |");
            Console.WriteLine(new string('-', 64));
        }

        /// <summary>
        /// Allow user to get statistics, as long as he wish
        /// </summary>
        public static bool StartStatistic()
        {
            string userInput = "";
            while (true)
            {
                StatisticCategoriesMenu();
                Console.Write("Choose the statistic type:");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    GlobalConfig.User.AccidentStatisticByCountry();
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    GlobalConfig.User.AccidentStatisticByAirplaneType();

                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    GlobalConfig.User.AccidentStatisticByPurposeOfFlight();
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    GlobalConfig.User.AccidentStatisticByAircraftCategory();
                }
                else if (userInput == "5")
                {
                    Console.Clear();
                    return true;
                }
                else if (userInput == "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Bye...");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the correct number!");
                    Console.WriteLine();
                    continue;
                }
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            return false;
        }

        /// <summary>
        /// Allow user to get searches, as long as he wish
        /// </summary>
        public static bool StartSearching()
        {
            string userInput = "";
            while (true)
            {
                SearchCategoriesMenu();
                Console.Write("Choose the search type:");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    Console.Write("Enter the country:");
                    string country = Console.ReadLine();
                    GlobalConfig.User.AccidentsByCountry(country);
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.Write("Enter the from date:");
                    DateTime from;
                    DateTime.TryParse(Console.ReadLine(), out from);
                    Console.Write("Enter the to date:");
                    DateTime to;
                    DateTime.TryParse(Console.ReadLine(), out to);
                    GlobalConfig.User.AccidentsBetweenDates(from, to);
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    Console.Write("Enter the plane type:");
                    string planeType = Console.ReadLine();
                    GlobalConfig.User.AccidentsByAirplane(planeType);
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    Console.Write("Enter the air carrier name:");
                    string airCarrierType = Console.ReadLine();
                    GlobalConfig.User.AccidentsByAirCarrier(airCarrierType);
                }
                else if (userInput == "5")
                {
                    Console.Clear();
                    Console.Write("Enter the weather condition:");
                    string weatherConditionType = Console.ReadLine();
                    GlobalConfig.User.AccidentsByWeatherCondition(weatherConditionType);
                }
                else if (userInput == "6")
                {
                    Console.Clear();
                    GlobalConfig.User.TenMostFatalInjuries();
                }
                else if (userInput == "7")
                {
                    Console.Clear();
                    GlobalConfig.User.TenMostSeriousInjuries();
                }
                else if (userInput == "8")
                {
                    Console.Clear();
                    GlobalConfig.User.TenMostMinorInjuries();
                }
                else if (userInput == "9")
                {
                    Console.Clear();
                    return true;
                }
                else if (userInput == "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Bye...");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the correct number!");
                    Console.WriteLine();
                    continue;
                }
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            return false;
        }

        /// <summary>
        /// Decorate the given data with the proper format
        /// </summary>
        /// <param name="model"></param>
        /// <param name="title"></param>
        public static void DecorateWithTitle(this IUser model, string title)
        {
            BuildTitle(title, model.GetLongestProperty() + TITLELENGTH);
            BuildContentForSearch(model.GetLongestProperty() + TITLELENGTH, model);
            BuildFooter(model.GetLongestProperty() + TITLELENGTH);
        }

        /// <summary>
        /// Build title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="max"></param>
        private static void BuildTitle(string title, int max)
        {
            for (int i = 0; i < (max - title.Length) / 2; i++)
            {
                Console.Write("-");
            }
            Console.Write(title);
            for (int i = 0; i < max - ((max - title.Length) / 2) - title.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Build content part for seaching
        /// </summary>
        /// <param name="max"></param>
        /// <param name="model"></param>
        private static void BuildContentForSearch(int max, IUser model)
        {
            var props = model.GetType().GetProperties();
            Console.WriteLine("|" + props[0].Name + " : " + props[0].GetValue(model) + new string(' ', 23 - ((string)props[0].GetValue(model)).Length) + new string(' ', model.GetLongestProperty() + 8) + "|");
            for (int i = 1; i < props.Length; i++)
            {
                if (props[i].GetValue(model) == "Access denied") continue;
                Console.WriteLine("|" + new string(' ', 11) + props[i].Name + new string(' ', 23 - ((string)props[i].Name).Length) + ": " + props[i].GetValue(model) + new string(' ', max - ((string)props[i].GetValue(model)).Length - 38) + "|");
            }
        }

        /// <summary>
        /// Build content part for statistic
        /// </summary>
        /// <param name="statistic"></param>
        /// <param name="max"></param>
        /// <param name="maxKey"></param>
        private static void BuildContentForStaticstic(List<IGrouping<string, IUser>> statistic, int max, int maxKey)
        {
            foreach (var item in statistic)
            {
                string firstPart = $"|{item.Key}" + new string(' ', maxKey - item.Key.Length + 1) + $"--> {item.ToList().Count} accidents";
                Console.WriteLine(firstPart + new string(' ', max - firstPart.Length) + "|");
            }
        }

        /// <summary>
        /// Build footer
        /// </summary>
        /// <param name="max"></param>
        private static void BuildFooter(int max)
        {
            Console.Write(new string('-', max));
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Decorate the given date with the proper format
        /// </summary>
        /// <param name="statistic"></param>
        /// <param name="title"></param>
        public static void DecorateStatisticWithTitle(this List<IGrouping<string, IUser>> statistic, string title)
        {
            int max = 0;
            int maxKey = 0;
            foreach (var item in statistic)
            {
                max = Math.Max(max, item.Key.Length + Convert.ToString(item.ToList().Count).Length);
                maxKey = Math.Max(maxKey, item.Key.Length);
            }

            BuildTitle(title, max + 22);
            BuildContentForStaticstic(statistic, max + 21, maxKey);
            BuildFooter(max + 22);
        }
    }
}
