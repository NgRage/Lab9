using System;
using System.Windows;

namespace Lab9
{
    public partial class MainWindow : Window
    {
        private LineSegment currentSegment;

        public MainWindow()
        {
            InitializeComponent();
        }

    
        private void PrintLog(string message)
        {
            tbResult.Text += message + "\n";
        }

        private bool TryGetValidSegment()
        {
            if (currentSegment == null)
            {
                MessageBox.Show("Сначала создайте отрезок!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double y = 0;
            try
            {
                x = double.Parse(tbX.Text);
                y = double.Parse(tbY.Text);

                currentSegment = new LineSegment(x, y);
                PrintLog($"[Успех] Создан отрезок: {currentSegment}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: Координаты X и Y должны быть " +
                    "вещественными числами.", "Ошибка формата",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnContains_Click(object sender, RoutedEventArgs e)
        {
            double num = 0;
            bool isInside = false;
            if (TryGetValidSegment())
            {
                try
                {
                    num = double.Parse(tbCheckNumber.Text);
                    isInside = currentSegment.Contains(num);
                    PrintLog($"Contains({num}): {isInside}");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректное число.", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnLength_Click(object sender, RoutedEventArgs e)
        {
            double length = 0;
            if (TryGetValidSegment())
            {
                length = !currentSegment;
                PrintLog($"Длина отрезка (!): {length}");
            }
        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (TryGetValidSegment())
            {
                currentSegment++;
                tbX.Text = currentSegment.X.ToString();
                tbY.Text = currentSegment.Y.ToString();
                PrintLog($"Инкремент (++): {currentSegment}");
            }
        }

        private void BtnCastInt_Click(object sender, RoutedEventArgs e)
        {
            int intCast = 0;
            if (TryGetValidSegment())
            {
                intCast = (int)currentSegment;
                PrintLog($"Явное приведение к int (целая часть X):" +
                    $" {intCast}");
            }
        }

        private void BtnCastDouble_Click(object sender, RoutedEventArgs e)
        {
            double doubleCast = 0;
            if (TryGetValidSegment())
            {
                doubleCast = currentSegment;
                PrintLog($"Неявное приведение к double (координата Y):" +
                    $" {doubleCast}");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int d = 0;
            if (TryGetValidSegment())
            {
                try
                {
                    d = int.Parse(tbAddNumber.Text);
                    currentSegment = currentSegment + d;
                    PrintLog($"Сложение с {d}: {currentSegment}");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Параметр 'd' должен быть целым числом.",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnOperatorLess_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            bool fallsInside = false;
            if (TryGetValidSegment())
            {
                try
                {
                    num = int.Parse(tbCheckNumber.Text);
                    fallsInside = currentSegment < num;
                    PrintLog($"Оператор {currentSegment} < {num}: {fallsInside}");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите целое число для оператора <.",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = string.Empty;
        }
    }
}