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
    /// Interaction logic for WorkoutDetailsWindow.xaml
    /// </summary>
    public partial class WorkoutDetailsWindow : Window
    {
        private Workout workout;
        private bool isEditing = false;
        public WorkoutDetailsWindow(Workout workout, UserManager userManager)
        {
            InitializeComponent();
            this.workout = workout;
            

            LoadWorkoutDetails();
        }

        private void LoadWorkoutDetails()
        {
            DateTextBox.Text = workout.Date;
            ExerciseTypeComboBox.Text = workout.Type;
            DurationTextBox.Text = workout.Duration.ToString();
            CaloriesBurnedTextBox.Text = workout.CaloriesBurned.ToString();
            NotesTextBox.Text = workout.Notes;

            if (workout is StrengthWorkout strengthWorkout)
            {
                SetsTextBox.Text = strengthWorkout.Sets.ToString();
                RepetitionsTextBox.Text = strengthWorkout.Repetitions.ToString();
                DistanceTextBox.IsEnabled = false;
            }
            else if (workout is CardioWorkout cardioWorkout)
            {
                DistanceTextBox.Text = cardioWorkout.Distance.ToString();
                SetsTextBox.IsEnabled = false;
                RepetitionsTextBox.IsEnabled = false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Återgå från redigeringsläget och stäng fönstret
            if (isEditing)
            {
                isEditing = false;
                SetEditingMode(isEditing);
                LoadWorkoutDetails(); 
            }
            else
            {
                Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Uppdatera träningspassets detaljer om redigeringsläget är aktivt
            if (isEditing)
            {
                workout.Date = DateTextBox.Text;
                workout.Type = ExerciseTypeComboBox.Text;
                workout.Duration = int.Parse(DurationTextBox.Text);
                workout.Notes = NotesTextBox.Text;

                if (workout is StrengthWorkout strengthWorkout)
                {
                    strengthWorkout.Sets = int.Parse(SetsTextBox.Text);
                    strengthWorkout.Repetitions = int.Parse(RepetitionsTextBox.Text);
                }
                else if (workout is CardioWorkout cardioWorkout)
                {
                    cardioWorkout.Distance = int.Parse(DistanceTextBox.Text);
                }

                workout.CalculateCaloriesBurned();
                CaloriesBurnedTextBox.Text = workout.CaloriesBurned.ToString();

                MessageBox.Show("Workout details updated successfully.");
                DialogResult = true;
                Close();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Aktivera redigering
            isEditing = true;
            SetEditingMode(isEditing);
        }

        private void SetEditingMode(bool enableEditing)
        {
            DateTextBox.IsReadOnly = !enableEditing;
            ExerciseTypeComboBox.IsEnabled = enableEditing;
            DurationTextBox.IsReadOnly = !enableEditing;
            NotesTextBox.IsReadOnly = !enableEditing;

            // sätter endast "CaloriesBurnedTextBox" som read-only eftersom det automatiskt räknas ut.
            CaloriesBurnedTextBox.IsReadOnly = true;

            SetsTextBox.IsReadOnly = !enableEditing;
            RepetitionsTextBox.IsReadOnly = !enableEditing;
            DistanceTextBox.IsReadOnly = !enableEditing;

            // Aktivera eller inaktivera Spara-knappen
            SaveButton.IsEnabled = enableEditing;
        }
    }
}
