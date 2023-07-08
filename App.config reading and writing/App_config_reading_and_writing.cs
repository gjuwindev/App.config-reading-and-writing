using System.Configuration;

namespace App.config_reading_and_writing
{
    internal class App_config_reading_and_writing
    {
        // Prepared for you by Predrag Gjuro Kladarić, 2023-07-08

        // first, use "Manage NuGet Packages" to install "System.Configuration.ConfigurationManager"

        // to add App.config file to project root folder, use
        //          Add ->
        //          New Item -> 
        //          Installed ->
        //          C# Items ->
        //          Application Configuration File
        // 
        // if you add it, this config file will be copied to runtime folder (bin/Debug/net7.0) on first run
        // if you don't, SaveAppSettings() will create one (but on runtime folder)
        //
        // beware, SaveAppSettings() creates/updates App.config file on the runtime folder

        static void Main(string[] args)
        {
            (Configuration configFile, KeyValueConfigurationCollection appSettings) = OpenAppSettings();

            Console.WriteLine(GetValue(appSettings, "userName"));

            SetValue(appSettings, "userName", "George");

            Console.WriteLine(GetValue(appSettings, "userName"));

            SaveAppSettings(configFile);

            Console.WriteLine("FINISHED!!!");
            Console.ReadLine();
        }

        internal static (Configuration configFile, KeyValueConfigurationCollection appSettings) OpenAppSettings()
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection appSettings = configFile.AppSettings.Settings;

            return (configFile, appSettings);
        }

        private static void SaveAppSettings(Configuration configFile)
        {
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public static string GetValue(KeyValueConfigurationCollection settings, string key)
        {
            if (settings[key] == null)
                return "**NULL**";
            else
                return settings[key].Value;
        }

        public static void SetValue(KeyValueConfigurationCollection settings, string key, string value)
        {
            if (settings[key] == null)
                settings.Add(key, value);
            else
                settings[key].Value = value;
        }
    }
}