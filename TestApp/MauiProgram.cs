using Syncfusion.Maui.Core.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using CommunityToolkit.Maui;

namespace TestApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.UseMauiCommunityToolkit();
        //
        builder.ConfigureSyncfusionCore();
        // AppSettings.json \\
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("TestApp.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

        builder.Configuration.AddConfiguration(config);

        builder.Services.AddTransient<MainPage>();


        // end \\
        return builder.Build();
	}
    public static IServiceProvider Services { get; private set; }

}
