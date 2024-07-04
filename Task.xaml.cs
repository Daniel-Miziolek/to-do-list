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
using System.Windows.Shapes;

namespace toDoList
{
    
    public partial class Task : Window
    {
        public Task()
        {
            InitializeComponent();
            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = comboBox1.SelectedItem as ComboBoxItem;

            if (selectedItem != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string priority = selectedItem.Content.ToString();
                string taskDescription = $"{textBox1.Text} Priority ({priority})";
                DateTime creationDate = DateTime.Now; 
                DateTime dueDate = dataPicker1.SelectedDate ?? DateTime.Now; 

                MainWindow.Instance.Tasks.Add(new TaskItem { Description = taskDescription, IsDone = false, Priority = int.Parse(priority), CreationDate = creationDate, DueDate = dueDate });
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter task description and select priority.");
            }
        }


    }
}
