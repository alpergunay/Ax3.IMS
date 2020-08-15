using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Ax3.IMS.Infrastructure.Configuration.SettingsImplementation
{
    public static class SettingsParser
    {
        public static T GetSettings<T>(IList<SettingsSection> parsedSections)
            where T : new()
        {
            var resultSettings = new T();

            foreach (var resultSettingsProperty in typeof(T).GetProperties())
            {
                var matchedSection = parsedSections.FirstOrDefault(s => s.Name.Equals(resultSettingsProperty.Name, StringComparison.OrdinalIgnoreCase));
                if (matchedSection == null)
                {
                    continue;
                }

                var innerSetting = Activator.CreateInstance(resultSettingsProperty.PropertyType);

                foreach (var innerProperty in resultSettingsProperty.PropertyType.GetProperties())
                {
                    var parsedSetting =
                        matchedSection.Settings.FirstOrDefault(s => s.Name.Equals(innerProperty.Name, StringComparison.OrdinalIgnoreCase));
                    if (parsedSetting == null)
                    {
                        continue;
                    }

                    var converter = TypeDescriptor.GetConverter(innerProperty.PropertyType);
                    if (!converter.CanConvertFrom(typeof(string)))
                    {
                        continue;
                    }

                    object value;
                    try
                    {
                        value = converter.ConvertFrom(parsedSetting.Value);
                    }
                    catch (Exception)
                    {
                        value = innerProperty.PropertyType.IsValueType ? Activator.CreateInstance(innerProperty.PropertyType) : null;
                    }

                    innerProperty.SetValue(innerSetting, value);
                }

                resultSettingsProperty.SetValue(resultSettings, innerSetting);
            }

            return resultSettings;
        }
    }
}