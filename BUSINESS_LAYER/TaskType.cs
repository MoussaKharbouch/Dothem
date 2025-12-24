using System;
using System.Data;
using DATA_LAYER;

namespace BUSINESS_LAYER
{

    public class clsTaskType
    {

        enum enMode { Add, Update }
        enMode Mode;

        public int TaskTypeID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        private int _UserID;
        public int UserID
        {

            get { return _UserID; }

            set
            {

                clsUser User = clsUser.FindUser(value);

                if (User == null)
                    return;

                _UserID = value;
                this.User = User;

            }

        }
        public clsUser User { get; set; }

        public clsTaskType()
        {

            TaskTypeID = -1;
            Name = string.Empty;
            DateOfCreation = DateTime.MinValue;
            Color = string.Empty;
            Description = string.Empty;
            UserID = -1;
            User = new clsUser();

            Mode = enMode.Add;

        }

        private clsTaskType(int TaskTypeID, string Name, DateTime DateOfCreation,
                            string Color, string Description, int UserID)
        {

            this.TaskTypeID = TaskTypeID;
            this.Name = Name;
            this.DateOfCreation = DateOfCreation;
            this.Color = Color;
            this.Description = Description;
            this.UserID = UserID;
            this.User = clsUser.FindUser(UserID);

            Mode = enMode.Update;

        }

        public static clsTaskType FindTaskType(int TaskTypeID)
        {

            string Name = string.Empty;
            DateTime DateOfCreation = DateTime.MinValue;
            string Color = string.Empty;
            string Description = string.Empty;
            int UserID = -1;

            TaskTypesData.FindTaskType(TaskTypeID, ref Name, ref DateOfCreation, ref Color, ref Description, ref UserID);

            if (Name == string.Empty)
                return null;

            return new clsTaskType(TaskTypeID, Name, DateOfCreation, Color, Description, UserID);

        }

        public static clsTaskType FindTaskType(string Name)
        {

            int TaskTypeID = -1;
            DateTime DateOfCreation = DateTime.MinValue;
            string Color = string.Empty;
            string Description = string.Empty;
            int UserID = -1;

            TaskTypesData.FindTaskType(Name, ref TaskTypeID, ref DateOfCreation, ref Color, ref Description, ref UserID);

            if (TaskTypeID == -1)
                return null;

            return new clsTaskType(TaskTypeID, Name, DateOfCreation, Color, Description, UserID);

        }

        private bool Add()
        {

            int TaskTypeID = this.TaskTypeID;

            bool succeeded = TaskTypesData.AddTaskType(ref TaskTypeID, Name, DateOfCreation, Color, Description, UserID);

            this.TaskTypeID = TaskTypeID;

            return succeeded;

        }

        private bool Update()
        {

            return TaskTypesData.UpdateTaskType(TaskTypeID, Name, DateOfCreation, Color, Description, UserID);

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

        public static bool DeleteTaskType(int TaskTypeID)
        {

            if (!DoesTaskTypeExist(TaskTypeID))
                return false;

            return TaskTypesData.DeleteTaskType(TaskTypeID);

        }

        public static bool DoesTaskTypeExist(int TaskTypeID)
        {

            return TaskTypesData.DoesTaskTypeExist(TaskTypeID);

        }

        static public DataTable GetTaskTypes(int UserID)
        {

            return TaskTypesData.GetTaskTypes(UserID);

        }

    }

}