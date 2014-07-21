using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglApi
{
    public class Constants
    {
        public class Urls
        {
            public const string API_URL = "https://www.toggl.com/api/v8";
            public const string TIMEENTRIES_URL = API_URL + "/time_entries?";
            public const string ME = API_URL + "/me";
            public const string ME_DETAILED = ME + "?with_related_data=true";
            public const string ME_CLIENTS = API_URL + "/clients";
            public const string ME_PROJECT = API_URL + "/projects";
            public const string ME_WORKSPACES = API_URL + "/workspaces";
            public const string ME_TAGS = API_URL + "/tags";
            public const string ME_PROJECT_USERS = API_URL + "/project_users";
        }

        public sealed class  Colors
        {
            #region colour codes from Toggl
            //based on response from Toggl API Developers
            //0 = "#4dc3ff" light blue
            //1 = "#bc85e6" very soft violet
            //2 = "#df7baa" very soft pink
            //3 = "#f68d38" bright orange
            //4 = "#b27636" light brown
            //5 = "#8ab734" moderate green
            //6 = "#14a88e" dark cyan
            //7 = "#268bb5" strong blue
            //8 = "#6668b4" slightly desaturated blue
            //9 = "#a4506c" dark moderate pink
            //10 = "#67412c" dark brown
            //11 = "#3c6526" dark green
            //12 = "#094558" very dark cyan
            //13 = "#bc2d07" red
            //14 = "#999999" dark grey
            #endregion

            public const string LIGHT_BLUE = "0";
            public const string LIGHT_VIOLET = "1";
            public const string LIGHT_PINK = "2";
            public const string ORANGE = "3";
            public const string LIGHT_BROWN = "4";
            public const string GREEN = "5";
            public const string CYAN = "6";
            public const string STRONG_BLUE = "7";
            public const string BLUE = "8";
            public const string DARK_PINK = "9";
            public const string DARK_BROWN = "10";
            public const string DARK_GREEN = "11";
            public const string DARK_CYAN = "12";
            public const string RED = "13";
            public const string DARK_GREY = "14";

            public string GetName(string data)
            {
                string result = string.Empty;
                switch (data)
                {
                    case "0" :
                        result = "Light Blue";
                        break;
                    case "1":
                        result = "Light Violet";
                        break;
                    case "2":
                        result = "Light Pink";
                        break;
                    case "3":
                        result = "Orange";
                        break;
                    case "4":
                        result = "Light Brown";
                        break;
                    case "5":
                        result = "Green";
                        break;
                    case "6":
                        result = "Cyan";
                        break;
                    case "7":
                        result = "Deep Blue";
                        break;
                    case "8":
                        result = "Blue";
                        break;
                    case "9":
                        result = "Dark Pink";
                        break;
                    case "10":
                        result = "Dark Brown";
                        break;
                    case "11":
                        result = "Dark Green";
                        break;
                    case "12":
                        result = "Dark Cyan";
                        break;
                    case "13":
                        result = "Red";
                        break;
                    case "14":
                        result = "Dark Grey";
                        break;
                }
                return result;
            }
        }

        public class Request
        {
            public class Properties
            {
                public const string API_TOKEN = "api_token";
                public const string CONTENT_TYPE = "Content-Type";
            }

            public class Values
            {
                public const string CONTENT_TYPE = "application/json";
            }
        }
    }
}
