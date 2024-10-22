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
        public RegisterWindow()
        {
            InitializeComponent();
            PopulateComboBox();

        }
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
                comboBox.Items.Add(countryName);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}


