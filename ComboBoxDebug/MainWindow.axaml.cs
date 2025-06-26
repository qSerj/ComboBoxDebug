using Avalonia.Controls;
using ComboBoxDebug.ViewModel;

namespace ComboBoxDebug;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new BasketsViewModel();
    }
}