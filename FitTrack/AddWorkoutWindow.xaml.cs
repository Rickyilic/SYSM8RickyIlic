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
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window
    {
        private User currentUser;
        private UserManager userManager;
        public AddWorkoutWindow(User currentUser, UserManager userManager)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userManager = userManager;
        }

        public event Action<Workout>? WorkoutAdded;
        private void SaveWorkout_Click(object sender, RoutedEventArgs e)
        {
            // Hämta värden från inputfälten
            string workoutType = ((ComboBoxItem)WorkoutTypeComboBox.SelectedItem)?.Content.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(workoutType))
            {
                MessageBox.Show("Please select a workout type.");
                return;
            }

            // Parsar varaktighet från TimeSpan
            if (!TimeSpan.TryParse(DurationInput.Text, out TimeSpan duration))
            {
                MessageBox.Show("Please enter a valid duration (HH:MM:SS).");
                return;
            }

            if (!int.TryParse(SetsInput.Text, out int sets))
                sets = 0;

            if (!int.TryParse(RepetitionsInput.Text, out int repetitions))
                repetitions = 0;

            if (!int.TryParse(DistanceInput.Text, out int distance))
                distance = 0;

            string notes = NotesInput.Text;

            Workout workout;
            if (workoutType == "Cardio")
            {
                workout = new CardioWorkout(DateTime.Now.ToString("yyyy-MM-dd"), (int)duration.TotalMinutes, 0, notes, currentUser.Username, distance);
            }
            else 
            {
                workout = new StrengthWorkout(DateTime.Now.ToString("yyyy-MM-dd"), (int)duration.TotalMinutes, 0, notes, currentUser.Username, sets, repetitions);
            }


            workout.CalculateCaloriesBurned(); // Kalkylera kalorier och uppdatera fältet
            CaloriesBurnedInput.Text = workout.CaloriesBurned.ToString(); // Visa i inputfältet
                                                                          
            userManager.AddWorkout(workout); // Lägg till träningspasset i användarens workout-lista
            WorkoutAdded?.Invoke(workout);
            MessageBox.Show("Workout saved successfully!");

            Close();
        }
    }
}

