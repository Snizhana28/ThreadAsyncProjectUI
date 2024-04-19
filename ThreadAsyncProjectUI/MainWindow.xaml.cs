using System.Windows;
namespace ThreadAsyncProjectUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await RunRaceAsync();
    }

    private async Task RunRaceAsync()
    {
        Random random1 = new Random();
        Random random2 = new Random();

        horse1.Value = 0;
        horse2.Value = 0;

        while (horse1.Value < 100 && horse2.Value < 100)
        {
            int step1 = random1.Next(1, 10);
            int step2 = random2.Next(1, 10);

            horse1.Value += step1;
            horse2.Value += step2;

            await Task.Delay(1000);
        }

        if (horse1.Value >= 100 && horse2.Value >= 100)
            lb_1.Content = "The winner: Horse 1!";
        else if (horse1.Value >= 100)
            lb_1.Content = "Horse #1 wins!";
        else
            lb_1.Content = "Horse #2 wins!";
    }
}


