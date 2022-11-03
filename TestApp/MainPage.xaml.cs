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
		
		//var byteArray = Preferences.Get("SavedBytes", "");
		try
		{

			if (!File.Exists("ImageData.txt"))
			{
				File.Create("ImageData.txt");
				//FileAccess.ReadWrite
				File.SetAttributes("ImageData.txt", File.GetAttributes("ImageData.txt"));/////////////////////////////////////
			}
            var byteArray = File.ReadAllText("ImageData.txt").ToString();
            var ByteString = ByteConverter.StringToByte(byteArray);
			var NewStream = ByteConverter.ByteArrayToStream(ByteString);
			Bot.Source = ImageSource.FromStream(() => NewStream);
        }
		catch(Exception ex)
		{
			HelloThing.Text = $"{ex}";
		}
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
			byte[] ConvertedStream = ByteConverter.StreamToByteArray(stream);
			try
			{
				File.WriteAllText("ImageData.txt", ByteConverter.ByteToString(ConvertedStream));
                //Preferences.Set("SavedBytes", ByteConverter.ByteToString(ConvertedStream));
            }
			catch(Exception ex)
			{
				await DisplayAlert("a", $"{ex}", "a");
			}
			var newStream = ByteConverter.ByteArrayToStream(ConvertedStream);
			Bot.Source = ImageSource.FromStream(() => newStream);
			Bot.IsAnimationPlaying = true;
		}
	}
}