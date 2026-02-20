using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BUSINESS_LAYER;

namespace PRESENTATION_LAYER
{
    /// <summary>
    /// Interaction logic for AddEditTask.xaml
    /// </summary>
    public partial class AddEditTaskWindow : Window
    {

        private clsTask Task;
        private Action Save_Event;

        enum enMode { Add, Edit }
        enMode Mode;

        //Constructor for adding new task
        public AddEditTaskWindow(Action Save_Event, int TaskTypeID)
        {
            InitializeComponent();
            this.Task = new clsTask();
            this.Save_Event = Save_Event;
            Mode = enMode.Add;
            dpDueDate.SelectedDate = DateTime.Now;
            FillTaskTypes();

            //Select task type that user has choosen
            clsTaskType selectedType = clsTaskType.FindTaskType(TaskTypeID);
            if (selectedType != null)
            {
                int index = cbTaskType.Items.IndexOf(selectedType.Name);
                if (index >= 0)
                    cbTaskType.SelectedIndex = index;
            }

        }

        //Constructor for editing task
        public AddEditTaskWindow(clsTask Task, Action Save_Event)
        {
            InitializeComponent();
            this.Task = Task;
            this.Save_Event = Save_Event;
            Mode = enMode.Edit;
            FillTaskTypes();
            ShowData(Task);
        }

        //Fill task types in a list
        private void FillTaskTypes()
        {

            DataTable TaskTypes = clsTaskType.GetTaskTypes(General.User.UserID);

            foreach (DataRow TaskType in TaskTypes.Rows)
            {
                cbTaskType.Items.Add(TaskType["Name"].ToString());
            }

        }

        //Show task information
        private void ShowData(clsTask Task)
        {

            if (Task == null)
                return;

            tbTaskName.Text = Task.Name;
            tbDescription.Text = Task.Description;
            dpDueDate.SelectedDate = Task.DueDate;
            cbPriority.SelectedIndex = (int)Task.PriorityLevel - 1;
            cbStatus.SelectedIndex = (Task.Status == clsTask.enStatus.NotStarted) ? 0 : 1;

            clsTaskType TaskType = clsTaskType.FindTaskType(Task.TaskTypeID);
            if(TaskType != null)
                cbTaskType.SelectedIndex = cbTaskType.Items.IndexOf(TaskType.Name);

        }

        private bool ValidateInput()
        {
            return (tbTaskName.Text != string.Empty && dpDueDate.SelectedDate.HasValue && cbPriority.SelectedIndex >= 0 && cbStatus.SelectedIndex >= 0);
        }

        private bool Save()
        {

            clsTask Task = enMode.Add == Mode ? new clsTask() : clsTask.FindTask(this.Task.TaskID);

            Task.Name = tbTaskName.Text;
            Task.Description = tbDescription.Text;
            Task.DueDate = dpDueDate.SelectedDate.HasValue ? dpDueDate.SelectedDate.Value : DateTime.Now;
            Task.PriorityLevel = (clsTask.enPriorityLevel)Convert.ToInt16(cbPriority.SelectedIndex + 1);
            Task.Status = (cbStatus.SelectedIndex == 0) ? clsTask.enStatus.NotStarted : clsTask.enStatus.Completed;

            clsTaskType TaskType = clsTaskType.FindTaskType(cbTaskType.SelectedItem.ToString());
            Task.TaskTypeID = TaskType.TaskTypeID;

            Task.Save();

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateInput())
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Save())
            {
                MessageBox.Show("Error saving task. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Save_Event?.Invoke();
                this.Close();
            }

        }

    }

}
