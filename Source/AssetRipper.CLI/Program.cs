using AssetRipper.Export.UnityProjects;
using AssetRipper.Export.UnityProjects.Configuration;
using AssetRipper.Processing;

internal class Program
{
	public static LibraryConfiguration Settings { get; } = LoadSettings();
	private static GameData? GameData { get; set; }
	static ExportHandler exportHandler = new(Settings);
	public static ExportHandler ExportHandler
	{
		private get
		{
			return exportHandler;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(value);
			value.ThrowIfSettingsDontMatch(Settings);
			exportHandler = value;
		}
	}

	private static void Main(string[] args)
	{
		LoadAndExport(args[0], args[1]);
	}

	static void LoadAndExport(string path, string exportPath)
	{
		Settings.LogConfigurationValues();
		GameData = ExportHandler.LoadAndProcess([path]);
		if (!Directory.Exists(exportPath))
			Directory.CreateDirectory(exportPath);
		ExportHandler.Export(GameData, exportPath);
	}

	private static LibraryConfiguration LoadSettings()
	{
		LibraryConfiguration settings = new();
		settings.LoadFromDefaultPath();
		return settings;
	}
}
