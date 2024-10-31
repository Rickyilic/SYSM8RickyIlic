using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitTrack
{
    
    //push test
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();
            userManager = new UserManager();

            User testUser = new User("user", "password", "Sweden");
            userManager.RegisterUser(testUser);

            // Skapa och registrera en adminanvändare för test
            AdminUser adminUser = new AdminUser("admin", "password", "Sweden");
            userManager.RegisterUser(adminUser);


        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(userManager);

            registerWindow.Show();
            Close();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (userManager.TryLoginUser(username, password, out User user))
            {
                MessageBox.Show($"Welcome {user.Username}!");
                // Navigera till WorkoutsWindow
                WorkoutsWindow workoutsWindow = new WorkoutsWindow(user, userManager);
                workoutsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
    }
}