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
    /// Логика взаимодействия для AddNewRepairWindow.xaml
    /// </summary>
    public partial class AddNewRepairWindow : Window
    {
        DB.Entity db = RepairWindow.db;

        public AddNewRepairWindow()
        {
            InitializeComponent();
            cbxCarriages.ItemsSource = db.Carriages.ToList();
            cbxCarriages.SelectedIndex = 0;

            cbxGroups.ItemsSource = db.Groups.ToList();
            cbxGroups.DisplayMemberPath = "Name";
            cbxGroups.SelectedIndex = 0;

            cbxRepairType.ItemsSource = db.RepairTypes.ToList();
            cbxRepairType.DisplayMemberPath = "Name";
            cbxRepairType.SelectedIndex = 0;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new RepairWindow().Show();
            this.Close();
        }

        private void click_AddNewRepair(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Repair.Add(new DB.Repair {
                    Carriages = (DB.Carriages)cbxCarriages.SelectedItem,
                    Groups = (DB.Groups)cbxGroups.SelectedItem,
                    RepairTypes = (DB.RepairTypes)cbxRepairType.SelectedItem,
                    Start = DateTime.Now,
                    Reason = tbxReason.Text,
                    BonusPercent = byte.Parse(tbxBonusPercent.Text)
                });
                db.SaveChanges();

                HelpClasses.Messages.OK("Вагон отправлен на ремонт!");
                new RepairWindow().Show();
                this.Close();
            }
            catch
            {
                HelpClasses.Messages.Error("Введите корректные данные!");
            }
        }
    }
}
