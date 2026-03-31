using MediaElementTest.ViewModels;

namespace MediaElementTest;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is MainPageVM vm)
        {
            vm.Initialize();
        }
    }
}
