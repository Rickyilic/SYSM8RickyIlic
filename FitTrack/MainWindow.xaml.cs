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
        public static UserManager userManager = new UserManager();
        public MainWindow()

        {
            InitializeComponent();

            User testUser = new User("user", "password", "Sweden");
            userManager.RegisterUser(testUser);


            // Lägg till två träningspass för testUser
            userManager.AddWorkout(new CardioWorkout(
                date: DateTime.Now.ToString("yyyy-MM-dd"),
                duration: 30,
                caloriesBurned: 0,
                notes: "test",
                username: testUser.Username,
                distance: 5));

            userManager.AddWorkout(new StrengthWorkout(
                date: DateTime.Now.ToString("yyyy-MM-dd"),
                duration: 45,
                caloriesBurned: 0,
                notes: "test",
                username: testUser.Username,
                sets: 4,
                repetitions: 12));

            // Skapa och registrera en adminanvändare för test
            AdminUser adminUser = new AdminUser("admin", "password", "Sweden");
            userManager.RegisterUser(adminUser);
            

            //även lagt till ett träningspass till admin för att testa
            userManager.AddWorkout(new StrengthWorkout(
                date: DateTime.Now.ToString("yyyy-MM-dd"),
                duration: 45,
                caloriesBurned: 0,
                notes: "test",
                username: adminUser.Username,
                sets: 4,
                repetitions: 12));

        }

        public MainWindow(UserManager userManager) : this() { }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();

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