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
using System.Windows.Shapes;

namespace Project_Airline
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        Airline NewAirline = new Airline();
        public AddWindow()
        {
            InitializeComponent();
            AddNewAirlineGrid.DataContext = NewAirline;
        }


        string imageSource = "";
        string imgsource = "";

        static string PathOfImage = null;
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(fileDialog.FileName);
                fileDialog.Filter = "png files(*.png)|*.png|JPG files(*.JPG)|*.JPG";

                imageSource = fileDialog.FileName.ToString();
                MyImage1.Source = new BitmapImage(fileUri);


                string FileName2 = fileDialog.FileName;
                string file = System.IO.Path.GetFileName(fileDialog.FileName);
            }
        }
        RegularExpression_Pattern regular = new RegularExpression_Pattern();
        private void AddAirline(object s, RoutedEventArgs e)
        {
            using (AirlineDbContext _context = new AirlineDbContext())
            {


                NewAirline.Logo = PathOfImage;

                string name = NewAirline.Name;
                string email = NewAirline.Email;
                string website = NewAirline.Website;
                string phone = NewAirline.Phone;
                if (name != null || email != null || website != null || phone != null)
                {
                    Match m1 = Regex.Match(name, regular.patterns["NamePattern"], RegexOptions.IgnoreCase);
                    Match m2 = Regex.Match(email, regular.patterns["EmailPattern"], RegexOptions.IgnoreCase);
                    Match m3 = Regex.Match(website, regular.patterns["WebsitePattern"], RegexOptions.IgnoreCase);
                    Match m4 = Regex.Match(phone, regular.patterns["PhonePattern"], RegexOptions.IgnoreCase);

                    if (m1.Success && m2.Success && m3.Success && m4.Success && NewAirline.Logo != null)
                    {
                        NewAirline.Logo = PathOfImage;
                        _context.Airlines.Add(NewAirline);
                        _context.SaveChanges();
                        //GetProducts();
                        NewAirline = new Airline();
                        AddNewAirlineGrid.DataContext = NewAirline;

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }
                    else
                    {
                        if (m1.Success == false) MessageBox.Show("name is invalid");
                        if (m2.Success == false) MessageBox.Show("email is invalid");
                        if (m3.Success == false) MessageBox.Show("website is invalid");
                        if (m4.Success == false) MessageBox.Show("phone Number is invalid");
                        if (NewAirline.Logo == null) MessageBox.Show("please enter your logo");
                    }
                }
                else
                    MessageBox.Show("Make sure all data is entered ");
                
            }
            


        }
        private void BackHome(object s, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        string filepath;
        //browse Button
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; // Stores Original Path in Textbox    
              

                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
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
    }
}
