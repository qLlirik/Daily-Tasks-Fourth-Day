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
    /// Логика взаимодействия для AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        DB.Entity db = EmployeesWindow.db;

        public AddNewEmployeeWindow()
        {
            InitializeComponent();
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new Windows.EmployeesWindow().Show();
            this.Close();
        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
            if ((tbxFIO.Text.Length == 0) && (tbxBase.Text.Length == 0) && (tbxYear.Text.Length == 0) && (tbxSpecial.Text.Length == 0) && (tbxNumberBankKart.Text.Length == 0))
            {
                HelpClasses.Messages.Error("Введите данные!");
                return;
            }

            try
            {
                db.Employees.Add(new DB.Employees {
                    FIO = tbxFIO.Text,
                    Base = tbxBase.Text,
                    Year = byte.Parse(tbxYear.Text),
                    Special = tbxSpecial.Text,
                    NumberBankKart = tbxNumberBankKart.Text
                });
                db.SaveChanges();

                HelpClasses.Messages.OK("Новый сотрудник добавлен!");
                click_Back(null,null);
            }
            catch
            {
                HelpClasses.Messages.Error("Введите корректные данные!");
            }
        }
    }
}
