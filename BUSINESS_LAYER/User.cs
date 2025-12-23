using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DATA_LAYER;

namespace BusinessLayer
{

    public class User
    {

        enum enMode { Add, Update }
        enMode Mode;

        public enum enStatus { Active = 1, Expired = 2, Banned = 3 }

        public int UserID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public enStatus Status { get; set; }

        public User()
        {

            UserID = -1;

            Username = string.Empty;
            Password = string.Empty;
            Status = enStatus.Active;

            Mode = enMode.Add;

        }

        public User(int UserID, string Username, string Password, enStatus Status)
        {

            this.UserID = UserID;

            this.Username = Username;
            this.Password = Password;
            this.Status = Status;

            Mode = enMode.Update;

        }

        public static User FindUser(string Username, string Password)
        {

            int UserID = -1;

            short status = 1;

            UsersData.FindUser(Username, Password, ref UserID, ref status);

            if (UserID == -1)
                return null;

            return new User(UserID, Username, Password, (enStatus)status);

        }

        public static User FindUser(int UserID)
        {

            string Username = string.Empty;
            string Password = string.Empty;

            short status = 0;

            UsersData.FindUser(UserID, ref Username, ref Password, ref status);

            if (Username == string.Empty && Password == string.Empty && status == 0)
                return null;

            return new User(UserID, Username, Password, (enStatus)status);

        }

        private bool Add()
        {

            if (DoesUsernameExist(Username))
                return false;

            int UserID = this.UserID;

            bool succeeded = UsersData.AddUser(ref UserID, Username, Password, (short)Status);

            this.UserID = UserID;

            return succeeded;

        }

        private bool Update()
        {

            if (UsersData.DoesUsernameExist(Username, UserID))
                return false;

            return UsersData.UpdateUser(UserID, Username, Password, (short)Status);

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