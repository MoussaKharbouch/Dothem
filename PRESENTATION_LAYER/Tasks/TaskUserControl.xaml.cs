using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUSINESS_LAYER;

namespace PRESENTATION_LAYER
{

    /// <summary>
    /// Interaction logic for TaskUserControl.xaml
    /// </summary>
    public partial class TaskUserControl : UserControl
    {

        private clsTask Task;
        public delegate void Delete_Event();
        public Action DeleteFunc;
        private Action Save_Event;

        public TaskUserControl()
        {
            InitializeComponent();
        }

        public TaskUserControl(clsTask Task, Action DeleteFunc, Action Save_Event)
        {

            InitializeComponent();
            this.Task = Task;

            this.DeleteFunc = DeleteFunc;
            this.Save_Event = Save_Event;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            if (Task == null) 
                return;

            tbTaskName.Text = Task.Name;

            //If description is longer than 100 characters then truncate it and add ...
            tbDescription.Text = (Task.Description.Length > 50) ? Task.Description.Substring(0, 100) + "..." : Task.Description;

            //Every task control has a tag that saves task id
            this.Tag = Task.TaskID.ToString();

            if (Task.Status == clsTask.enStatus.Completed)
            {
                chkCompleted.IsChecked = true;
                tbTaskName.TextDecorations = TextDecorations.Strikethrough;
            }

        }

        //Complete task
        private void chkCompleted_Click(object sender, RoutedEventArgs e)
        {

            if ((bool)chkCompleted.IsChecked)
            {
                Task.Status = clsTask.enStatus.Completed;
                tbTaskName.TextDecorations = TextDecorations.Strikethrough;
            }
            else
            {
                Task.Status = clsTask.enStatus.NotStarted;
                tbTaskName.TextDecorations = null;
            }

            Task.Save();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            AddEditTaskWindow AddEditTaskWindow = new AddEditTaskWindow(Task, Save_Event);
            AddEditTaskWindow.ShowDialog();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                if (clsTask.DeleteTask(Task.TaskID))
                {
                    MessageBox.Show("Task has been deleted successfully", "Succeeded", MessageBoxButton.OK, MessageBoxImage.Information);
                    DeleteFunc?.Invoke();
                }
                else
                {
                    MessageBox.Show("Task deletion failed", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
                MessageBox.Show("Deletion has been cancelled", "Canceled", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }

}
