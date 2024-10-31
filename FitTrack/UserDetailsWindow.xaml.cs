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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        private User currentUser;
        public UserDetailsWindow(User currentUser, UserManager userManager)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userManager = userManager;
            PopulateComboBox();

            CurrentUsernameTextBlock.Text = currentUser.Username;
            CurrentCountryTextBlock.Text = currentUser.Country;

            UsernameTextBox.Text = currentUser.Username;
            CountryComboBox.SelectedItem = currentUser.Country;
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = UsernameTextBox.Text;
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string selectedCountry = CountryComboBox.SelectedItem as string;


            // validerar namnet
            if (newUsername.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.");
                return;
            }

            if (newUsername != currentUser.Username && userManager.UserExists(newUsername))
            {
                MessageBox.Show("Username is already taken.");
                return;
            }

            // validera lösenordet
            if (newPassword.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters long.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Uppdaterar användarens information
            currentUser.Username = newUsername;
            currentUser.Password = newPassword;
            currentUser.Country = selectedCountry;

            CurrentCountryTextBlock.Text = selectedCountry;

            MessageBox.Show("User details updated successfully!");
            Close();

        }
    }
}
