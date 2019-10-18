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
    public static class HelperMethods
    {
        /// <summary>
        /// Tell if the given date is between dates
        /// </summary>
        /// <param name="given"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime given, DateTime from, DateTime to)
        {
            if (from == null || to == null)
            {
                return false;
            }
            return given >= from && given <= to;
        }

        /// <summary>
        /// Get the full path to the Root user folder
        /// </summary>
        /// <returns>Root user folder path</returns>
        public static string GetTheRootFolderPath()
        {
            return ConfigurationManager.AppSettings["RootUserDataFolderPath"];
        }

        /// <summary>
        /// Get the full path to the Simple user folder
        /// </summary>
        /// <returns>Simple user folder path</returns>
        public static string GetTheSimpleFolderPath()
        {
            return ConfigurationManager.AppSettings["SimpleUserDataFolderPath"];
        }

        /// <summary>
        /// Using reflections calculate the max property lenght for the given flight
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int GetLongestProperty(this IUser model)
        {
            int max = 0;
            var listOfProperties = model.GetType().GetProperties();
            foreach (var item in listOfProperties)
            {
                if (item.GetValue(model) == "Access denied") continue;
                max = Math.Max(((string)item.GetValue(model)).Length, max);
            }
            return max;
        }

        /// <summary>
        /// Save statistic results to the given file
        /// </summary>
        /// <param name="statistic"></param>
        /// <param name="path"></param>
        /// <param name="keyName"></param>
        public static void SaveStatistic(this List<IGrouping<string, IUser>> statistic, string path, string keyName)
        {
            List<string> lines = new List<string>();
            lines.Add($"{keyName},Accidents number");

            foreach (var item in statistic)
            {
                lines.Add($"{item.Key},{item.ToList().Count}");
            }
            File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Save the search results to the given file
        /// </summary>
        /// <param name="matches"></param>
        /// <param name="path"></param>
        public static void SaveSearchResults(this List<IUser> matches, string path)
        {
            List<string> lines = new List<string>();

            string title = "\"";

            foreach (var element in matches[0].GetType().GetProperties())
            {
                title += element.Name.Trim() + "\",\"";
            }

            title = title.Substring(0, title.Length - 2);

            lines.Add(title);
            

            string line = "\"";


            for (int i = 0; i < 10; i++)
            {
                line = "\"";
                foreach (var element in matches[i].GetType().GetProperties())
                {
                    line += ((string)element.GetValue(matches[i])).Trim() + "\",\"";
                }
                line = line.Substring(0, line.Length - 2);
                lines.Add(line); 
            }
            
            File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Save search results to the given file with additional title at the end, specifying the search key
        /// </summary>
        /// <param name="matches"></param>
        /// <param name="path"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        public static void SaveSearchResults(this List<IUser> matches, string path, string keyName, string keyValue)
        {
            List<string> lines = new List<string>();

            if (!File.Exists(path))
            {
                string title = "\"";

                foreach (var element in matches[0].GetType().GetProperties())
                {
                    title += element.Name.Trim() + "\",\"";
                }

                title += "Key - " + keyName + "\"";

                lines.Add(title);
            }

            string line = "\"";

            foreach (var match in matches)
            {
                line = "\"";
                foreach (var element in match.GetType().GetProperties())
                {
                    line += ((string)element.GetValue(match)).Trim() + "\",\"";
                }
                line += keyValue+ "\"";
                lines.Add(line);
            }
            File.AppendAllLines(path, lines);
        }

    }
}
