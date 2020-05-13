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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeeGray_s00188181
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Phone db = new Phone();
        List<PhoneData> AllPhones = new List<PhoneData>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Phones
                        select p;

            AllPhones = query.ToList();
            LBXPhones.ItemsSource = AllPhones;

        }

        private void LBXPhones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhoneData selectedPhone = LBXPhones.SelectedItem as PhoneData;

            if (selectedPhone != null)
            {
                string Price = $"Phone Price: {selectedPhone.Price}";
                TXBPrice.Text = Price;

                ImageBX.Source = new BitmapImage(new Uri(selectedPhone.Phone_Image,UriKind.Relative));
            }
        }
    }
}
