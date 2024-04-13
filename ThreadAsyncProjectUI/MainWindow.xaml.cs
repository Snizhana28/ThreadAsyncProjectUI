using System.Windows;
using System.Windows.Input;

namespace ThreadAsyncProjectUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool start;
        private readonly Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            start = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                start = !start;
                if (start)
                {
                    _ = GenerateNumbersAsync();
                }
            }
        }

        private async Task GenerateNumbersAsync()
        {
            while (start)
            {
                await Dispatcher.InvokeAsync(() => textBlock.Text = rnd.Next().ToString());
                await Task.Delay(1000);
            }
        }
    }
}
