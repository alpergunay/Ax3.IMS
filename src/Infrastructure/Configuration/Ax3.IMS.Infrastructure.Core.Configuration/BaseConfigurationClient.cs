using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ax3.IMS.Infrastructure.Configuration.SettingsImplementation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Ax3.IMS.Infrastructure.Configuration
{
    public abstract class BaseConfigurationClient : IConfigurationClient
    {
        private readonly ConcurrentDictionary<Type, object> settings;

        private List<SettingsSection> settingSections;

        public List<SettingsSection> SettingsSections => settingSections ?? (settingSections = ReadConfig());

        protected BaseConfigurationClient()
        {
            settings = new ConcurrentDictionary<Type, object>();
        }

        public T GetSettings<T>()
            where T : new()
        {
            return (T)settings.GetOrAdd(typeof(T), type => LoadSettings<T>());
        }

        public ApplicationSettings GetApplicationSettings()
        {
            return GetSettings<ApplicationSettings>();
        }

        public abstract string GetConfigurationFolderPath();

        protected abstract List<SettingsSection> ReadConfig();

        private object LoadSettings<T>()
            where T : new()
        {
            return SettingsParser.GetSettings<T>(SettingsSections);
        }
    }
}