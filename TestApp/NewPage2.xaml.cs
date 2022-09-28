using Android.Webkit;

namespace TestApp;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			var translator = new Dictionary<string, string>();
			translator.Add(" ", " ");
            translator.Add("A", ". -");
            translator.Add("B", "- . . .");
            translator.Add("C", "– · – ·");
            translator.Add("D", "– · ·");
            translator.Add("E", "·");
            translator.Add("F", "· · – ·");
            translator.Add("G", "– – ·");
            translator.Add("H", "· · · ·");
            translator.Add("I", "· ·");
            translator.Add("J", "· – – –");
            translator.Add("K", "– · –");
            translator.Add("L", "· – · ·");
            translator.Add("M", "– –");
            translator.Add("N", "– ·");
            translator.Add("O", "– – –");
            translator.Add("P", "· – – ·");
            translator.Add("Q", "– – · –");
            translator.Add("R", "· – ·");
            translator.Add("S", "· · ·");
            translator.Add("T", "–");
            translator.Add("U", "· · –");
            translator.Add("V", "· · · –");
            translator.Add("W", "· – –");
            translator.Add("X", "– · · –");
            translator.Add("Y", "– · – –");
            translator.Add("Z", "– – · ·");
            translator.Add("0", "– – – – –");
            translator.Add("1", "· – – – –");
            translator.Add("2", "· · – – –");
            translator.Add("3", "· · · – –");
            translator.Add("4", "· · · · –");
            translator.Add("5", "· · · · ·");
            translator.Add("6", "– · · · ·");
            translator.Add("7", "– – · · ·");
            translator.Add("8", "– – – · ·");
            translator.Add("9", "– – – – ·");
            translator.Add(",", "– – · · – –");

            PermissionStatus status = await Permissions.RequestAsync<Permissions.Flashlight>();
            var morse = string.Empty;

            foreach(var c in Text.Text)
            {
                morse += translator[c.ToString().ToUpper()] + " ";
            }
            await DisplayAlert("title", $"{morse}", "ok");
            await Task.Delay(2000);
            while (true)
            {
                foreach (var b in morse)
                {
                    if (b.ToString() == ".")
                    {
                        await Flashlight.TurnOnAsync();
                        await Task.Delay(200);
                    }
                    else if (b.ToString() == "–")
                    {
                        await Flashlight.TurnOnAsync();
                        await Task.Delay(500);
                    }
                    else if (b.ToString() == " " || b.ToString() == " ")
                    {
                        await Task.Delay(200);
                    }
                    await Flashlight.TurnOffAsync();
                }
                if (!IsLooping.IsChecked)
                {
                    break;
                }
                await Task.Delay(1000);
            }
            await DisplayAlert("Finished", "Sending code is complete", "ok");
        }
		catch
		{
			await DisplayAlert("Error", "Check if you accepted all permissions and try to not use anything other then letters or numbers", "ok");
		}
        
	}
}