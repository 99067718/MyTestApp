using Microsoft.Extensions.Configuration;
using TestApp.Models;

namespace TestApp;
public partial class MainPage : ContentPage
{
	IConfiguration configuration;
	public MainPage(IConfiguration config)
	{
		InitializeComponent();
		configuration = config;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var settings = configuration.GetRequiredSection("Settings").Get<Settings>();
		//await DisplayAlert("Config", $"{nameof(settings.KeyOne)}: {settings.KeyOne}" +
		//  $"{nameof(settings.KeyTwo)}: {settings.KeyTwo}" +
		//$"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}", "OK");
		var gifsOnly =
			new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
			{
				{DevicePlatform.iOS, new[] {"com.adobe.gif"} },
				{DevicePlatform.Android, new[] { "image/gif" } },
				{DevicePlatform.WinUI, new[] {".gif"} }
			});
		var result = await FilePicker.PickAsync(new PickOptions
		{
			PickerTitle = "open a gif"
		});
		if (result != null)
		{
			Stream stream = await result.OpenReadAsync();
			Bot.Source = ImageSource.FromStream(() => stream);
			Bot.IsAnimationPlaying = true;
		}
	}
}