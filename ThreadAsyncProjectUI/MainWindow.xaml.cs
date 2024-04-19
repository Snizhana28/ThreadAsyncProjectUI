using System.Windows;

namespace ThreadAsyncProjectUI;

public partial class MainWindow : Window
{
    private int[] array = new int[10];

    public MainWindow()
    {
        InitializeComponent();
        InitializeArray();
    }

    private void InitializeArray()
    {
        Random rnd = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(0, 50);
        }

        foreach (int i in array)
        {
            arr.Text += i.ToString() + " ";
        }
    }

    private async void button_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(tb.Text, out int value))
        {
            await SortArray();
            await SearchArray(value);
        }
        else
            MessageBox.Show("Please enter a valid number.");
    }

    private async Task SortArray()
    {
        await Task.Run(() =>
        {
            Array.Sort(array);
        });
        sortedArr.Text += "Sorted array: ";
        foreach (int i in array)
        {
            sortedArr.Text += i.ToString() + " ";
        }
    }

    private async Task SearchArray(int value)
    {
        int index = await Task.Run(() =>
        {
            return Array.BinarySearch(array, value);
        });

        if (index >= 0)
            sortedArr.Text += $"\nIndex: {index}";
        else
            sortedArr.Text += "\nNumber not found in the sorted array.";
    }
}
