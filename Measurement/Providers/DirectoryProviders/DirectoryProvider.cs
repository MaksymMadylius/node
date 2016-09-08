using System;
using System.Configuration;
using System.IO;

namespace Measurement.Providers.DirectoryProviders
{
    public static class DirectoryProvider
    {
        public static string GetFullPath(string configPathKey)
        {
            var filePath = ConfigurationSettings.AppSettings[configPathKey];
            var appPath = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(appPath, filePath);
        }
    }
}
