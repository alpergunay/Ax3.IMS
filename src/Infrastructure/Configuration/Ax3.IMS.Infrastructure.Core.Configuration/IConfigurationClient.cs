using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ax3.IMS.Infrastructure.Configuration.SettingsImplementation;
using System.Collections.Generic;

namespace Ax3.IMS.Infrastructure.Configuration
{
    public interface IConfigurationClient
    {
        List<SettingsSection> SettingsSections { get; }

        T GetSettings<T>()
            where T : new();

        ApplicationSettings GetApplicationSettings();

        string GetConfigurationFolderPath();
    }
}