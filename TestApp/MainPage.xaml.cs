namespace TestApp;
public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
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
			var stream = await result.OpenReadAsync();
			Bot.Source = ImageSource.FromStream(() => stream);
            Bot.IsAnimationPlaying = true;
        }
	}
}