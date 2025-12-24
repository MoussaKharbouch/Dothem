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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int TaskTypeID;

        public MainWindow()
        {

            InitializeComponent();

            DataTable TaskTypes = clsTaskType.GetTaskTypes(General.User.UserID);
            if (TaskTypes.Rows.Count > 0)
            {
                TaskTypeID = Convert.ToInt32(TaskTypes.Rows[0]["TaskTypeID"]);
            }

        }

        private void ShowTasks()
        {

            spTasks.Children.Clear();

            DataTable Tasks = clsTask.GetTasks(TaskTypeID);

            foreach (DataRow row in Tasks.Rows)
            {

                clsTask task = clsTask.FindTask(Convert.ToInt32(row["TaskID"]));
                TaskUserControl TaskControl = new TaskUserControl(task, ShowTasks, ShowTasks);

                TaskControl.DeleteFunc += () => ShowTasks();

                spTasks.Children.Add(TaskControl);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (General.User != null)
            {

                AddEditTaskWindow AddEditTask = new AddEditTaskWindow(ShowTasks, TaskTypeID);
                AddEditTask.ShowDialog();

            }

        }

        private void FillTaskTypes()
        {

            //Hardcoded User ID for test
            DataTable TaskTypes = clsTaskType.GetTaskTypes(General.User.UserID);

            foreach (DataRow TaskType in TaskTypes.Rows)
            {
                lbTaskTypes.Items.Add(TaskType["Name"].ToString());
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillTaskTypes();
            Dispatcher.BeginInvoke(new Action(() => ColorTaskTypes()), System.Windows.Threading.DispatcherPriority.Loaded);
            ShowTasks();
        }

        private void ColorTaskTypes()
        {

            if (lbTaskTypes.Items == null)
                return;

            for (int i = 0; i < lbTaskTypes.Items.Count; i++)
            {
                ListBoxItem ItemContainer = (ListBoxItem)lbTaskTypes.ItemContainerGenerator.ContainerFromIndex(i);

                if (ItemContainer == null)
                    continue;

                string TaskTypeName = lbTaskTypes.Items[i].ToString();
                clsTaskType TaskType = clsTaskType.FindTaskType(TaskTypeName);

                if (TaskType != null)
                {

                    if(TaskType.Color == null || TaskType.Color == string.Empty)
                    {
                        ItemContainer.Background = Brushes.LightGray;
                        ItemContainer.Foreground = Brushes.Black;
                        continue;
                    }

                    ItemContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(TaskType.Color));
                    SolidColorBrush bgBrush = ItemContainer.Background as SolidColorBrush;

                    if (bgBrush != null)
                    {
                        double luminance = 0.2126 * bgBrush.Color.R + 0.7152 * bgBrush.Color.G + 0.0722 * bgBrush.Color.B;
                        ItemContainer.Foreground = luminance > 128 ? Brushes.Black : Brushes.White;
                    }

                }

            }

        }

        private void lbTaskTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lbTaskTypes.SelectedIndex >= 0)
            {

                string SelectedTaskType = lbTaskTypes.SelectedItem.ToString();
                clsTaskType TaskType = clsTaskType.FindTaskType(SelectedTaskType);

                if (TaskType != null)
                {

                    TaskTypeID = TaskType.TaskTypeID;
                    ShowTasks();

                }

            }

        }

    }

}
