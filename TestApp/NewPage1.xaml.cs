using System.Collections.ObjectModel;
namespace TestApp;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
        InitializeComponent();
        ShowTime.Text = DateTime.Now.AddMinutes(20).ToString();
    }

}