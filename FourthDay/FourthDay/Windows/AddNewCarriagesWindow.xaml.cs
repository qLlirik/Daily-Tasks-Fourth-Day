using Microsoft.Win32;
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
    /// Логика взаимодействия для AddNewCarriagesWindow.xaml
    /// </summary>
    public partial class AddNewCarriagesWindow : Window
    {
        DB.Entity db = CarriagesWindow.db;

        public AddNewCarriagesWindow()
        {
            InitializeComponent();

            cbxCarriageType.ItemsSource = db.CarriageTypes.ToList();
            cbxCarriageType.DisplayMemberPath = "Name";
            cbxCarriageType.SelectedIndex = 0;
        }

        private void click_Back(object sender, RoutedEventArgs e)
        {
            new CarriagesWindow().Show();
            this.Close();
        }

        private void click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Carriages.Add(new DB.Carriages {
                    RegNumber = double.Parse(tbxRegNumber.Text),
                    RegName = tbxRegName.Text,
                    RegCheif = tbxRegCheif.Text,
                    TypeID = cbxCarriageType.SelectedIndex + 1,
                    Year = short.Parse(tbxYear.Text),
                    Picture = ImageToByte(tbxPicture.Text)
                });
                db.SaveChanges();

                HelpClasses.Messages.OK("Новый вагон добавлен!");

                new CarriagesWindow().Show();
                this.Close();
            }
            catch 
            {
                HelpClasses.Messages.Error("Введите корректные данные!");
            }
        }

        private void click_SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Images|*.png;*.bmp;*.jpg;*.jpeg";
            if (ofd.ShowDialog() == true)
                tbxPicture.Text = ofd.FileName;
        }

        private Byte[] ImageToByte(string uri)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(uri,UriKind.Relative))));
            MemoryStream ms = new MemoryStream();
            encoder.Save(ms);
            return ms.ToArray();
        }
    }
}
