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
            ExerciseTypeTextBox.Text = workout.Type;
            DurationTextBox.Text = workout.Duration.ToString();
            CaloriesBurnedTextBox.Text = workout.CaloriesBurned.ToString();
            NotesTextBox.Text = workout.Notes;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Återgå från redigeringsläget och stäng fönstret
            if (isEditing)
            {
                isEditing = false;
                SetEditingMode(isEditing);
                LoadWorkoutDetails(); // Återställ ursprungliga värden
            }
            else
            {
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Uppdatera träningspassets detaljer om redigeringsläget är aktivt
            if (isEditing)
            {
                workout.Date = DateTextBox.Text;
                workout.Type = ExerciseTypeTextBox.Text;
                workout.Duration = int.Parse(DurationTextBox.Text);
                workout.CaloriesBurned = int.Parse(CaloriesBurnedTextBox.Text);
                workout.Notes = NotesTextBox.Text;

                // Bekräfta ändringar och stäng fönstret
                MessageBox.Show("Workout details updated successfully.");
                DialogResult = true;
                this.Close();
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
            ExerciseTypeTextBox.IsReadOnly = !enableEditing;
            DurationTextBox.IsReadOnly = !enableEditing;
            CaloriesBurnedTextBox.IsReadOnly = !enableEditing;
            NotesTextBox.IsReadOnly = !enableEditing;

            // Aktivera/sinaktivera Spara-knappen
            SaveButton.IsEnabled = enableEditing;
        }
    }
}
