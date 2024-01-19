using MahApps.Metro.Controls;
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

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTodayDate();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();

        }

        private void SetTodayDate()
        {
            
            DateTime today = DateTime.Now;

           
            string formattedDate = today.ToString("MM/dd/yyyy");

           
            label.Content = formattedDate;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you want to DELETE this task?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int choose = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(choose);
            }
            else
            {

            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you want to CLEAR the list?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                listBox1.Items.Clear();
            }
            else
            {

            }
        }
    }
}