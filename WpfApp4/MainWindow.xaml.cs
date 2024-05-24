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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFindDuplicates_Click(object sender, RoutedEventArgs e)
        {
            string inputString = txtInput.Text;
            List<char> duplicateChars = FindDuplicateChars(inputString);

            if (duplicateChars.Count > 0)
            {
                txtResult.Text = $"Удвоенные буквы: {string.Join(", ", duplicateChars)}";
            }
            else
            {
                txtResult.Text = "Удвоенных букв нет.";
            }
        }

        private List<char> FindDuplicateChars(string inputString)
        {
            List<char> duplicates = new List<char>();
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in inputString.ToLower()) // Преобразуем в нижний регистр для учета регистра
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts.Add(c, 1);
                }
            }
            foreach (KeyValuePair<char, int> pair in charCounts)
            {
                if (pair.Value > 1)
                {
                    duplicates.Add(pair.Key);
                }
            }

            return duplicates;
        }
    }
}

