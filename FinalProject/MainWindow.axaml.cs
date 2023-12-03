using Avalonia.Controls;
using Avalonia.Interactivity;

namespace FinalProject;

public partial class MainWindow : Window
{
    private DB db = new DB();
    public MainWindow()
    {
        InitializeComponent();
        db.CloseConnection();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        CheckingWindow win = new CheckingWindow();
        win.Show();
        this.Close();
    }
}