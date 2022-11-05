namespace Lab6Starter;

/**
 * 
 * Name: Brady Braun and James Last
 * Date: 2022/11/5
 * Description: And this?
 * Bugs: None that can be found! This is just what builds the app, WHAT gets built and how is determined more by the actual classes, after all.
 * Reflection: See MainPage reflection.
 * 
 */


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

