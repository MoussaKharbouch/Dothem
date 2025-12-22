using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DATA_LAYER;

namespace DVLDBusinessLayer
{

    public class clsUser
    {

        enum enMode { Add, Update }
        enMode Mode;

        public enum enStatus { Active = 1, Expired = 2, Banned = 3 }

        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public enStatus Status { get; set; }

        public clsUser()
        {

            UserID = -1;
            PersonID = -1;

            Username = string.Empty;
            Password = string.Empty;
            Status = enStatus.Expired;

            Mode = enMode.Add;

        }

        public clsUser(int UserID, int PersonID, string Username, string Password, enStatus Status)
        {

            this.UserID = UserID;
            this.PersonID = PersonID;

            this.Username = Username;
            this.Password = Password;
            this.Status = Status;

            Mode = enMode.Update;

        }

        public static clsUser FindUser(string Username, string Password)
        {

            int UserID = -1;
            int PersonID = -1;

            short status = 0;

            UsersData.FindUser(Username, Password, ref UserID, ref PersonID, ref status);

            if (UserID == -1)
                return null;

            return new clsUser(UserID, PersonID, Username, Password, (enStatus)status);

        }

        public static clsUser FindUser(int UserID)
        {

            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;

            short status = 0;

            UsersData.FindUser(UserID, ref PersonID, ref Username, ref Password, ref status);

            if (PersonID == -1)
                return null;

            return new clsUser(UserID, PersonID, Username, Password, (enStatus)status);

        }

        private bool Add()
        {

            if (DoesUsernameExist(Username))
                return false;

            int UserID = this.UserID;

            bool succeeded = UsersData.AddUser(ref UserID, PersonID, Username, Password, (short)Status);

            this.UserID = UserID;

            return succeeded;

        }

        private bool Update()
        {

            if (UsersData.DoesUsernameExist(Username, UserID))
                return false;

            return UsersData.UpdateUser(UserID, PersonID, Username, Password, (short)Status);

        }

        public bool Save()
        {

            bool succeeded = false;

            switch (Mode)
            {

                case enMode.Add:
                    succeeded = Add();

                    if (succeeded)
                        Mode = enMode.Update;

                    break;

                case enMode.Update:
                    succeeded = Update();
                    break;

                default:
                    break;

            }

            return succeeded;

        }

        public static bool DeleteUser(int UserID)
        {

            if (!UsersData.DoesUserExist(UserID))
                return false;

            return UsersData.DeleteUser(UserID);

        }

        public static bool DoesUserExist(string Username, string Password)
        {

            return UsersData.DoesUserExist(Username, Password);

        }

        public static bool DoesUsernameExist(string Username)
        {

            return UsersData.DoesUsernameExist(Username);

        }

        static public DataTable GetUsers()
        {

            return UsersData.GetUsers();

        }

    }

}