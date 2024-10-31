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

namespace FitTrack
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window

  
    {
        private UserManager userManager;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            PopulateComboBox();
        }

        //Lägger in alla länder i Combobox genom en array och en foreach loop
        private void PopulateComboBox()
        {
            string[] europeanCountries = new string[]
            {
            "Albania", "Andorra", "Austria", "Belarus", "Belgium", "Bosnia and Herzegovina",
            "Bulgaria", "Croatia", "Cyprus", "Czech Republic", "Denmark", "Estonia", "Finland",
            "France", "Germany", "Greece", "Hungary", "Iceland", "Ireland", "Italy", "Kosovo",
            "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta", "Moldova", "Monaco",
            "Montenegro", "Netherlands", "North Macedonia", "Norway", "Poland", "Portugal",
            "Romania", "Russia", "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain",
            "Sweden", "Switzerland", "Ukraine", "United Kingdom", "Vatican City"
            };


            foreach (string countryName in europeanCountries)
            {
                CountryComboBox.Items.Add(countryName);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;


            //Logik för att registrera sig och ifall användarnamn och lösenord inte matchar eller ifall man inte valt land

            if (password != confirmPassword)
            {
                MessageBox.Show("Password doesn't match.");
                return;
            }

            if (userManager.UserExists(username))
            {
                MessageBox.Show("Username already taken.");
                return;
            }
            if (CountryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please choose a country.");
                return;
            }


            User newUser = new User(username, password, country);
            userManager.RegisterUser(newUser);
            MessageBox.Show("Registration successfull!");
            Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

    }
}


