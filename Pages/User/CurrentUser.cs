using StudyroomBookingZealand.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyroomBookingZealand.Pages.User
{
    public class CurrentUser
    {
        public const string JsonLoggedInUser = @"Data\LoggedInUser.json";
        public static Models.User LoggedUser;
        public IUsers UserService;
        public IInvitations InvitationService;
        public CurrentUser(IUsers service, IInvitations invitationservice)
        {
            UserService = service;
            InvitationService = invitationservice;
        }
        
        //public static void ChangeUser(string[] login, Models.User user)//user will be provided from the GetUSerByUsername() method
        //{
        //    if(user.Password == login[1])
        //    {
        //        LoggedUser = user;
        //    }
        //}
        public static bool Exists
        {
            get { return LoggedUser != null; }
        }
        
        public static bool Login(string[] login, bool rememberme, Models.User user)
        {
            if (login[1] == user.Password)
            {
                if (rememberme)
                {
                    Data.Helpers.JsonFileHelper<string[]>.WriteToJson(login, JsonLoggedInUser);
                }
                LoggedUser = user;
                return true;
            }
            return false;
        }
        public static void Logout()
        {
            Data.Helpers.JsonFileHelper<string[]>.ClearJson(JsonLoggedInUser);
            LoggedUser = null;
        }
    }
}
