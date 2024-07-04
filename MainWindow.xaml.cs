using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace toDoList
{
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static MainWindow Instance {  get; private set; }
        private ObservableCollection<TaskItem> tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        private string newTaskDescription;
        public string NewTaskDescription
        {
            get { return newTaskDescription; }
            set
            {
                newTaskDescription = value;
                OnPropertyChanged("NewTaskDescription");
            }
        }

        private TaskItem selectedTask;
        public TaskItem SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            if (Instance == null)
            {
                Instance = this;
            }
            DataContext = this;
            Tasks = new ObservableCollection<TaskItem>();
            LoadTasksFromFile("tasks.txt");
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.Show();

            /*if (!string.IsNullOrWhiteSpace(NewTaskDescription))
            {
                Tasks.Add(new TaskItem { Description = NewTaskDescription, IsDone = false });
                NewTaskDescription = "";
            }
            else
            {
                MessageBox.Show("Wprowadź treść zadania.");
            }*/
        }

        private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
            {
                Tasks.Remove(SelectedTask);
            }
            else
            {
                MessageBox.Show("Wybierz zadanie do usunięcia.");
            }
        }

        private void MarkAsDoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
            {
                SelectedTask.IsDone = true;
            }
            else
            {
                MessageBox.Show("Wybierz zadanie do oznaczenia jako wykonane.");
            }
        }

        private void SortByPriorityButton_Click(object sender, RoutedEventArgs e)
        {
            Tasks = new ObservableCollection<TaskItem>(Tasks.OrderBy(task => task.Priority));
        }

        private void SortByDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            Tasks = new ObservableCollection<TaskItem>(Tasks.OrderBy(task => task.Description));
        }

        private void SaveTasksToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var task in Tasks)
                {
                    writer.WriteLine($"{task.Description},{task.IsDone}");
                }
            }
        }

        private void LoadTasksFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                Tasks.Clear();
                foreach (string line in File.ReadLines(filename))
                {
                    string[] parts = line.Split(',');
                    bool isDone = bool.Parse(parts[1]);
                    Tasks.Add(new TaskItem { Description = parts[0], IsDone = isDone });
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveTasksToFile("tasks.txt");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                TaskItem taskItem = button.DataContext as TaskItem;
                if (taskItem != null)
                {
                    Tasks.Remove(taskItem);
                }
            }
        }

    }

    public class TaskItem : INotifyPropertyChanged
    {
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        private int priority;
        public int Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            {
                creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged("DueDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}