# App.config reading and writing

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
