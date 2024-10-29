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
        private UserManager userManager = new UserManager();
        public MainWindow()
        {
            InitializeComponent();
            userManager = new UserManager();

            User testUser = new User("testuser", "Test1234!", "Sweden");
            userManager.RegisterUser(testUser);

            User adminUser = new User("admin", "Admin1234!", "Sweden", true); // IsAdmin är satt till true
            userManager.RegisterUser(adminUser); 

        }

        public MainWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(userManager);

            registerWindow.Show();
            this.Close();
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
    }
}