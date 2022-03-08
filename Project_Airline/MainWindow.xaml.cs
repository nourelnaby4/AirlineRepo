using Microsoft.Win32;
using Project_Airline.Vaildation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Project_Airline
{

    public partial class MainWindow : Window
    {
        public List<Airline> Airlines { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GetAirlines();
        }
        private void GetAirlines()
        {
            using (AirlineDbContext _context = new AirlineDbContext())
            {
                Airlines = _context.Airlines.ToList();
            }
            AirlineDataGrid.ItemsSource = Airlines;
        }

        private void ShowDetails(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var row = e.Source as DataGridRow;
                DetailsWindow detailsWindow = new DetailsWindow(row.Item);
                detailsWindow.Owner = this;
                detailsWindow.Show();
            }

        }
        private void AddPage(object s, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
            this.Close();
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var DeletedItem = (s as FrameworkElement).DataContext as Airline;
            using(AirlineDbContext _context=new AirlineDbContext())
            {
                _context.Airlines.Remove(DeletedItem);
                _context.SaveChanges();
            }
            GetAirlines();
        }

        string filepath;
        static string PathOfImage=null;
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; 
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); 
                MyImage1.Source = imgsource;
            }


            string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath(name, "Images");

           PathOfImage = destinationPath;

            if(filepath!=null)
              File.Copy(filepath, destinationPath, true);
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\Images\\" + filename, foldername);
            return appStartPath;
        }
        RegularExpression_Pattern regular = new RegularExpression_Pattern();


        Airline selectAireline = new Airline();
        private void UpdateAirlineForEdit(object s, RoutedEventArgs e)
        {
            selectAireline = (s as FrameworkElement).DataContext as Airline;
            UpdateAirlineGrid.DataContext = selectAireline;
        }
        private void UpdateAirline(object s, RoutedEventArgs e)
        {
            using(AirlineDbContext _context=new AirlineDbContext())
            {
                string name = selectAireline.Name;
                string email = selectAireline.Email;
                string website = selectAireline.Website;
                string phone = selectAireline.Phone;

                selectAireline.Logo = PathOfImage;
                if (name != null || email != null || website != null || phone != null)
                {
                    Match m1 = Regex.Match(name, regular.patterns["NamePattern"], RegexOptions.IgnoreCase);
                    Match m2 = Regex.Match(email, regular.patterns["EmailPattern"], RegexOptions.IgnoreCase);
                    Match m3 = Regex.Match(website, regular.patterns["WebsitePattern"], RegexOptions.IgnoreCase);
                    Match m4 = Regex.Match(phone, regular.patterns["PhonePattern"], RegexOptions.IgnoreCase);
                    if (m1.Success && m2.Success && m3.Success && m4.Success && selectAireline.Logo != null)
                    {
                        
                        _context.Airlines.Update(selectAireline);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (m1.Success == false) MessageBox.Show("name is invalid");
                        if (m2.Success == false) MessageBox.Show("email is invalid");
                        if (m3.Success == false) MessageBox.Show("website is invalid");
                        if (m4.Success == false) MessageBox.Show("phone Number is invalid");
                        if (selectAireline.Logo == null) MessageBox.Show("please enter your logo");
                    }
                    GetAirlines();
                }
                else
                    MessageBox.Show("Make sure all data is entered ");
                GetAirlines();

            }
           
        }

    }
}
