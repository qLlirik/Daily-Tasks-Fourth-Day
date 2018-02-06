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
    /// Логика взаимодействия для JoinEmployeesToGroupWindow.xaml
    /// </summary>
    public partial class JoinEmployeesToGroupWindow : Window
    {
        DB.Entity db = EmployeesWindow.db;

        public JoinEmployeesToGroupWindow()
        {
            InitializeComponent();
            
            foreach (var i in db.Employees.Except(db.EmployeesInGroup.Select(w => w.Employees)))
            {
                lvOut.Items.Add(i);
            }
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new EmployeesWindow().Show();
            this.Close();
        }

        private void click_Select(object sender, RoutedEventArgs e)
        {
            lvIn.Items.Add((DB.Employees)((Button)sender).DataContext);
            lvOut.Items.Remove((DB.Employees)((Button)sender).DataContext);
        }

        private void click_Delete(object sender, RoutedEventArgs e)
        {
            lvOut.Items.Add((DB.Employees)((Button)sender).DataContext);
            lvIn.Items.Remove((DB.Employees)((Button)sender).DataContext);
        }

        private void click_MakeGroup(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text.Length == 0)
            {
                HelpClasses.Messages.Error("Введите название бригады!");
                return;
            }

            if (lvIn.Items.Count == 0)
            {
                HelpClasses.Messages.Error("Выберите сотрудников!");
                return;
            }

            int check = 0;
            foreach (var i in lvIn.Items)
            {
                var empl = (DB.Employees)i;
                if (empl.Cheif)
                    check++;
            }
            if (check == 0)
            {
                HelpClasses.Messages.Error("Выберите бригадира!");
                return;
            }

            db.Groups.Add(new DB.Groups { Name = tbxName.Text});

            foreach(var i in lvIn.Items)
            {
                var empl = (DB.Employees)i;
                db.EmployeesInGroup.Add(new DB.EmployeesInGroup {
                    Groups = db.Groups.ToList().Last(),
                    Employees = empl,
                    Cheif = empl.Cheif
                });
            }
            db.SaveChanges();

            HelpClasses.Messages.OK("Бригада сформирована!");
            this.Close();
        }
    }
}
