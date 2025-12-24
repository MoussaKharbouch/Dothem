using System;
using System.Data;
using DATA_LAYER;

namespace BUSINESS_LAYER
{

    public class clsTask
    {

        enum enMode { Add, Update }
        enMode Mode;

        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public enum enStatus { NotStarted = 1, Completed = 2}
        public enStatus Status { get; set; }

        public enum enPriorityLevel { Low = 1, Medium = 2, High = 3 }
        public enPriorityLevel PriorityLevel { get; set; }

        public DateTime DueDate { get; set; }

        private int _TaskTypeID;
        public int TaskTypeID
        {

            get { return _TaskTypeID; }

            set
            {

                clsTaskType TaskType = clsTaskType.FindTaskType(value);

                if (TaskType == null)
                    return;

                _TaskTypeID = value;
                this.TaskType = TaskType;

            }

        }
        public clsTaskType TaskType { get; set; }


        public clsTask()
        {

            TaskID = -1;
            Name = string.Empty;
            Description = string.Empty;

            Status = enStatus.NotStarted;
            PriorityLevel = enPriorityLevel.Medium;

            DueDate = DateTime.MinValue;

            TaskTypeID = -1;

            Mode = enMode.Add;

        }

        private clsTask(int TaskID, string Name, string Description,
                        short Status, short PriorityLevel,
                        DateTime DueDate, int TaskTypeID)
        {

            this.TaskID = TaskID;
            this.Name = Name;
            this.Description = Description;

            this.Status = (enStatus)Status;
            this.PriorityLevel = (enPriorityLevel)PriorityLevel;

            this.DueDate = DueDate;

            this.TaskTypeID = TaskTypeID;

            Mode = enMode.Update;

        }

        public static clsTask FindTask(int TaskID)
        {

            string Name = string.Empty;
            string Description = string.Empty;
            short Status = 0;
            short PriorityLevel = -1;
            DateTime DueDate = DateTime.MinValue;
            int TaskTypeID = -1;

            TasksData.FindTask(TaskID, ref Name, ref Description,
                               ref Status, ref PriorityLevel,
                               ref DueDate, ref TaskTypeID);

            if (Name == string.Empty)
                return null;

            return new clsTask(TaskID, Name, Description, Status,
                               PriorityLevel, DueDate, TaskTypeID);

        }

        private bool Add()
        {

            int TaskID = this.TaskID;

            bool succeeded = TasksData.AddTask(ref TaskID, Name, Description,
                                               (short)Status, (short)PriorityLevel,
                                               DueDate, TaskTypeID);

            this.TaskID = TaskID;

            return succeeded;

        }

        private bool Update()
        {

            return TasksData.UpdateTask(TaskID, Name, Description,
                                        (short)Status, (short)PriorityLevel,
                                        DueDate, TaskTypeID);

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

        public static bool DeleteTask(int TaskID)
        {

            if (!DoesTaskExist(TaskID))
                return false;

            return TasksData.DeleteTask(TaskID);

        }

        public static bool DoesTaskExist(int TaskID)
        {

            return TasksData.DoesTaskExist(TaskID);

        }

        static public DataTable GetTasks(int TaskTypeID)
        {

            return TasksData.GetTasks(TaskTypeID);

        }

    }

}