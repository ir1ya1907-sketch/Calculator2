using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnOperateClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputA.Text, out double a) &&
                double.TryParse(InputB.Text, out double b))
            {
                string op = (sender as FrameworkElement).Tag.ToString();
                double res = 0;

                switch (op)
                {
                    case "+": res = a + b; break;
                    case "-": res = a - b; break;
                    case "*": res = a * b; break;
                    case "/":
                        if (b == 0) { MessageBox.Show("Деление на 0!"); return; }
                        res = a / b; break;
                }

                ResultLabel.Text = $"Результат: {res}";
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }
    }
}
