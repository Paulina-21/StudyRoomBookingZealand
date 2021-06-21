using Microsoft.AspNetCore.Identity;
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
        
        public static bool Exists
        {
            get { return LoggedUser != null; }
        }

        public static bool IsAdmin //Right now its checking if the user is a teacher, it will also be considered as admin
        {
            get { return LoggedUser.IsTeacher; }
        }
        
        public static bool Login(string[] login, bool rememberme, Models.User user)
        {
            PasswordHasher<Models.User> hasher = new PasswordHasher<Models.User>();
            //  For convenience, since our application does not have a sign up page, the code will check if the nonhashed password 
            //matches with the one from the database so that user accounts created directly inside the database with unhashed passwords
            //can stil be accessed, if it doesnt, it checks the hashed version
            if (login[1]==user.Password)
            {
                if (rememberme)
                {
                    //stores the user login details in a json file in order to log in automatically next time
                    Data.Helpers.JsonFileHelper<string[]>.WriteToJson(login, JsonLoggedInUser);
                }
                LoggedUser = user;
                return true;
            }
            else
            {
                try
                {
                    if (hasher.VerifyHashedPassword(user, user.Password, login[1]) == PasswordVerificationResult.Success)
                    {
                        if (rememberme)
                        {
                            login[1] = user.Password;
                            Data.Helpers.JsonFileHelper<string[]>.WriteToJson(login, JsonLoggedInUser);
                        }
                        LoggedUser = user;
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public static void Logout()
        {
            Data.Helpers.JsonFileHelper<string[]>.ClearJson(JsonLoggedInUser);
            LoggedUser = null;
        }
        public static void Update(Models.User user, Models.User updateduser)
        {
            user.FirstName = updateduser.FirstName;
            user.LastName = updateduser.LastName;
            user.PhoneNr = updateduser.PhoneNr;
            user.Address = updateduser.Address;
        }
    }
}
