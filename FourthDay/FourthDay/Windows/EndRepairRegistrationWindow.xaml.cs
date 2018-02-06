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
    /// Логика взаимодействия для EndRepairRegistrationWindow.xaml
    /// </summary>
    public partial class EndRepairRegistrationWindow : Window
    {
        DB.Entity db = RepairWindow.db;

        public EndRepairRegistrationWindow()
        {
            InitializeComponent();

            cbxRepair.ItemsSource = db.Repair.ToList();
            cbxRepair.SelectedIndex = 0;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new RepairWindow().Show();
            this.Close();
        }

        private void click_End(object sender, RoutedEventArgs e)
        {
            var rep = (DB.Repair)cbxRepair.SelectedItem;
            rep.Finish = DateTime.Now;
            rep.Bonus = rbPerfect.IsChecked == true ? true : false;
            db.SaveChanges();

            HelpClasses.Messages.OK("Ремонт окончен!");
            click_Back(null, null);
        }
    }
}
