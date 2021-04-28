using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Pages.User
{
    public static class CurrentUser
    {
        const string JsonLoggedInUser = @"Data\LoggedInUser.json";
        public static Models.User LoggedUser;

        public static void CheckUser()
        {
            try
            {
                LoggedUser = Data.Helpers.JsonFileHelper<Models.User>.ReadJson(JsonLoggedInUser);
            }
            catch
            {
                LoggedUser.Id = 0;
            }
        }
        public static void Login(Models.User user, bool rememberme)
        {
            if (rememberme)
            {
                Data.Helpers.JsonFileHelper<Models.User>.WriteToJson(user, JsonLoggedInUser);
            }
        }
        public static void Logout()
        {
            Data.Helpers.JsonFileHelper<Models.User>.ClearJson(JsonLoggedInUser);
        }
    }
}
