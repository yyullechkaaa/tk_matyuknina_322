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

namespace tk_matyuknina_322
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int task1 = GetValidScore(Task1.Text, 10, "Задание 1");
                int task2 = GetValidScore(Task2.Text, 50, "Задание 2");
                int task3 = GetValidScore(Task3.Text, 30, "Задание 3");
                int task4 = GetValidScore(Task4.Text, 10, "Задание 4");

                int total = task1 + task2 + task3 + task4;

                string grade = GetGrade(total);

                tbTotal.Text = $"Сумма баллов: {total}";
                tbGrade.Text = $"Оценка: {grade}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetValidScore(string input, int maxScore, string taskName)
        {
            if (!int.TryParse(input, out int score))
            {
                throw new ArgumentException($"{taskName}: введите целое число");
            }

            if (score < 0 || score > maxScore)
            {
                throw new ArgumentException($"{taskName}: баллы должны быть от 0 до {maxScore}");
            }

            return score;
        }

        private string GetGrade(int total)
        {
            if (total >= 70) return "5 (отлично)";
            if (total >= 40) return "4 (хорошо)";
            if (total >= 20) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }
    }
}
