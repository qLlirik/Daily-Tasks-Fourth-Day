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

namespace FourthDay.Windows
{
    /// <summary>
    /// Логика взаимодействия для RepairWindow.xaml
    /// </summary>
    public partial class RepairWindow : Window
    {
        static public DB.Entity db = new DB.Entity();

        public RepairWindow()
        {
            InitializeComponent();

            lv.ItemsSource = db.Repair.ToList();
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void click_AddNewCarriages(object sender, RoutedEventArgs e)
        {
            new AddNewRepairWindow().Show();
            this.Close();
        }

        private void click_EndRepairRegistration(object sender, RoutedEventArgs e)
        {
            new EndRepairRegistrationWindow().Show();
            this.Close();
        }
    }
}
