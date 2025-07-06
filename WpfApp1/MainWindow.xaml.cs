using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
// MainWindow.xaml.cs
{
   public partial class MainWindow : Window
    {
        double firstNumber, secondNumber;
        string currentOperator = "";
        bool isWaitingForClear = false;
        public MainWindow()
        {
            InitializeComponent();  
        }

        // 숫자 패드 눌렀을떄
        private void OnNumberClicked(object sender, RoutedEventArgs e)
        {
            if (isWaitingForClear) ClearMainPanel();
            if (MainPanel.Text == "0" && !((Button)sender).Content.Equals(".")) OnRemoveClicked(sender, e); // 0 입력후 .아닌 숫자 입력시 0 삭제
            MainPanel.Text += ((Button)sender).Content.ToString();
        }

        // 연산자 눌렀을 때
        private void OnOperatorClicked(object sender, RoutedEventArgs e)
        {
            currentOperator = ((Button) sender).Content.ToString();
            firstNumber = double.Parse(MainPanel.Text);
            SubPanel.Text = firstNumber + " " + currentOperator;
            isWaitingForClear = true;
            

        }

        // 계산 버튼 눌렀을 떄
        private void OnEqualClick(object sender, RoutedEventArgs e)
        {
            if (MainPanel.Text == "") return;

            secondNumber = double.Parse(MainPanel.Text);
            double result;

            switch (currentOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "×":
                    result = firstNumber * secondNumber;
                    break;
                case "÷":
                    result = secondNumber != 0 ? firstNumber / secondNumber : 0;
                    break;
                case "%":
                    result = firstNumber % secondNumber;
                    break;
                default:
                    return;
            }


            SubPanel.Text = firstNumber +" "+ currentOperator +" "+ secondNumber;
            MainPanel.Text = result.ToString();
        }

        // 백스페이스 눌렀을 때
        private void OnRemoveClicked(object sender, RoutedEventArgs e)
        {
            string text = MainPanel.Text;
            MainPanel.Text = text.Length > 0 ? text.Remove(text.Length - 1) : text;
        }


        private void OnClearEntryClicked(object sender, RoutedEventArgs e)
        {
            MainPanel.Text = "";
            SubPanel.Text = "";
        }

        private void OnClearClicked(object sender, RoutedEventArgs e)
        {
            MainPanel.Text = "";
        }

        private void ClearMainPanel()
        {
            MainPanel.Text = "";
            isWaitingForClear = false;
        }

        // 부호버튼 눌렀을 때
        private void OnToggleSignClicked(object sender, RoutedEventArgs e)
        {
            if (isWaitingForClear) ClearMainPanel();
            if (MainPanel.Text.Contains("-")) MainPanel.Text = MainPanel.Text.Replace("-", "");
            else MainPanel.Text = "-" + MainPanel.Text;
        }
    }
}
