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

namespace ToDoList
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            List<string> list = new List<string>
            {
                "Important",
                "Not Important"
            };
            comboBox.ItemsSource = list;
            text_date.IsReadOnly = true;
            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendar.SelectedDate.HasValue)
            {
                string data = calendar.SelectedDate.Value.ToString();
                text_date.Text = data;
            }
        }

        private void text_title_LostFocus(object sender, RoutedEventArgs e)
        {
            if (text_title.Text == "")
            {
                text_title.Text = "Title";
            }
        }

        private void text_title_GotFocus(object sender, RoutedEventArgs e)
        {
            text_title.Text = "";
        }

        private void text_des_GotFocus(object sender, RoutedEventArgs e)
        {
            text_des.Text = "";
        }

        private void text_des_LostFocus(object sender, RoutedEventArgs e)
        {
            if (text_des.Text == "")
            {
                text_des.Text = "Description";
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.listBox1.Items.Add($"Title: {text_title.Text}\nDescription: {text_des.Text}, Date: {text_date.Text}, Status: {comboBox.Text}");
            main.Show();
            this.Close();
            
        }
    }
}
