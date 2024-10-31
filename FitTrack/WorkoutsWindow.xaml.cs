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
    /// Interaction logic for WorkoutsWindow.xaml
    /// </summary>
    public partial class WorkoutsWindow : Window
    {
        private User currentUser;
        private UserManager userManager;

        public WorkoutsWindow(User user, UserManager userManager)
        {
            InitializeComponent();
            currentUser = user;
            this.userManager = userManager;

            // Visa det inloggade användarnamnet
            UsernameTextBlock.Text = $"Logged in as: {currentUser.Username}";

            // Ladda träningspassen i listan
            LoadWorkouts();
            

        }
        private void LoadWorkouts()
        {
            WorkoutListBox.Items.Clear();

            // Kontrollera om currentUser är av typen AdminUser
            if (currentUser is AdminUser)
            {
                // Om det är en admin, hämta alla träningspass
                List<Workout> workouts = userManager.ManageAllWorkouts();
                foreach (Workout workout in workouts)
                {
                    WorkoutListBox.Items.Add(workout);
                }
            }
            else
            {
                // Om det är en vanlig användare, hämta bara användarens träningspass
                List<Workout> workouts = userManager.GetUserWorkouts(currentUser);
                foreach (Workout workout in workouts)
                {
                    WorkoutListBox.Items.Add(workout);
                }
            }
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new UserDetailsWindow(currentUser, userManager);
            userDetailsWindow.ShowDialog();

            UsernameTextBlock.Text = $"Logged in as: {currentUser.Username}";

            LoadWorkouts(); // Uppdatera listan om ändringar har skett
        }

        private void AddWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow(currentUser, userManager);

            addWorkoutWindow.WorkoutAdded += (workout) =>
            {
                // Lägg till det nya träningspasset i WorkoutListBox
                WorkoutListBox.Items.Add(workout);
            };
            addWorkoutWindow.ShowDialog();
            LoadWorkouts(); // Uppdatera listan efter att ett nytt träningspass har lagts till

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("FitTrack is a place for anyone who wants an effective and helpful path through their fitness journey!");
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            // Logga ut och återgå till huvudfönstret
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();   

        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutListBox.SelectedItem is Workout selectedWorkout)
            {
                // Öppna WorkoutDetailsWindow för det markerade träningspasset
                WorkoutDetailsWindow detailsWindow = new WorkoutDetailsWindow(selectedWorkout, userManager);
                detailsWindow.ShowDialog();
                LoadWorkouts(); 
            }
            else
            {
                MessageBox.Show("Please select a workout to view details.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkoutListBox.SelectedItem is Workout selectedWorkout)
            {
                // Ta bort det markerade träningspasset
                userManager.RemoveWorkout(selectedWorkout);
                LoadWorkouts(); 
            }
            else
            {
                MessageBox.Show("Please select a workout to remove.");
            }
        }
    }
}
