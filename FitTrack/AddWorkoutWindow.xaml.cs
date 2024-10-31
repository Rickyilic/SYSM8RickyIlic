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

            if (!int.TryParse(CaloriesBurnedInput.Text, out int caloriesBurned))
            {
                MessageBox.Show("Please enter a valid number for calories burned.");
                return;
            }

            
            string notes = NotesInput.Text;

            Workout workout;
            if (workoutType == "Cardio")
            {
                workout = new CardioWorkout(DateTime.Now.ToString("yyyy-MM-dd"), (int)duration.TotalMinutes, caloriesBurned, notes, currentUser.Username, distance: 0);
            }
            else 
            {
                workout = new StrengthWorkout(DateTime.Now.ToString("yyyy-MM-dd"), (int)duration.TotalMinutes , caloriesBurned, notes, currentUser.Username, sets: 3, repetitions: 10);
            }

            // Lägg till träningspasset i användarens workout-lista
            userManager.AddWorkout(workout);

            WorkoutAdded?.Invoke(workout);
            MessageBox.Show("Workout saved successfully!");

            Close();
        }
    }
}

