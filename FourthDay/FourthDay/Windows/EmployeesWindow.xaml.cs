using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        static public DB.Entity db = new DB.Entity();

        public EmployeesWindow()
        {
            InitializeComponent();

            lv.ItemsSource = db.Employees.ToList();
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void click_AddNewEmployee(object sender, RoutedEventArgs e)
        {
            new Windows.AddNewEmployeeWindow().Show();
            this.Close();
        }

        private void click_JoinEmployeesToGroup(object sender, RoutedEventArgs e)
        {
            new Windows.JoinEmployeesToGroupWindow().Show();
            this.Close();
        }

        private void click_Search(object sender, RoutedEventArgs e)
        {
            lv.ItemsSource = db.Employees.Where(w => w.FIO.Contains(cbxFIO.Text)).ToList();
            using (StreamWriter sw = new StreamWriter("Search.txt",true))
                sw.WriteLine(cbxFIO.Text);
            
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            cbxFIO.Items.Clear();
            var str = File.ReadAllLines("Search.txt");
            foreach (var i in str)
                if (i.Contains(cbxFIO.Text))
                    cbxFIO.Items.Add(i);
        }
    }
}