using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MVVMExampleApp.Frontend.ViewModels;

namespace MVVMExampleApp.Frontend;

public partial class AddView : Window
{
    public AddView()
    {
        InitializeComponent();
    }

    public AddView(AddViewModel addViewModel) : this()
    {
        DataContext = addViewModel;
    }
}