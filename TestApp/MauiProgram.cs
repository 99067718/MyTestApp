
/* Unmerged change from project 'TestApp (net6.0-ios)'
Before:
using Syncfusion.Maui.Core.Hosting;
After:
using Syncfusion.Maui;
using Microsoft.Extensions.Configuration;
*/

/* Unmerged change from project 'TestApp (net6.0-windows10.0.19041.0)'
Before:
using Syncfusion.Maui.Core.Hosting;
After:
using Syncfusion.Maui;
using Microsoft.Extensions.Configuration;
*/

/* Unmerged change from project 'TestApp (net6.0-maccatalyst)'
Before:
using Syncfusion.Maui.Core.Hosting;
After:
using Syncfusion.Maui;
using Microsoft.Extensions.Configuration;
*/
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;

/* Unmerged change from project 'TestApp (net6.0-ios)'
Before:
using Microsoft.Extensions.Configuration;
After:
using Syncfusion.Maui.Core.Configuration;
*/

/* Unmerged change from project 'TestApp (net6.0-windows10.0.19041.0)'
Before:
using Microsoft.Extensions.Configuration;
After:
using Syncfusion.Maui.Core.Configuration;
*/

/* Unmerged change from project 'TestApp (net6.0-maccatalyst)'
Before:
using Microsoft.Extensions.Configuration;
After:
using Syncfusion.Maui.Core.Configuration;
*/
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;

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
