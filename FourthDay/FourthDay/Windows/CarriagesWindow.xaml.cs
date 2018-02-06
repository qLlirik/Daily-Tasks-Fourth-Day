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
    /// Логика взаимодействия для CarriagesWindow.xaml
    /// </summary>
    public partial class CarriagesWindow : Window
    {
        static public DB.Entity db = new DB.Entity();

        public CarriagesWindow()
        {
            InitializeComponent();

            lv.ItemsSource = db.Carriages.ToList();
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void click_AddNewCarriages(object sender, RoutedEventArgs e)
        {
            new AddNewCarriagesWindow().Show();
            this.Close();
        }
    }
}
