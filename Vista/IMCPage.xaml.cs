using CalcularIMC_MAUI;
namespace MVVM.Vista;

public partial class IMCPage : ContentPage
{
	public IMCPage()
	{
		InitializeComponent();
        BindingContext = new IMCViewModel();
    }
}