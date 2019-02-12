#region References

using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Timeliner.Configuration;

#endregion

namespace Timeliner.Helpers
{
    public static class ConfigHelper
    {
        private const string CONST_configFileName = "Timeliner.config";

        public static TimelinerConfig ReadConfig()
        {
            using (FileStream fileStream = new FileStream(GetConfigFilePath(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimelinerConfig));
                TimelinerConfig config = (TimelinerConfig)xmlSerializer.Deserialize(fileStream);
                fileStream.SetLength(0);
                xmlSerializer.Serialize(fileStream, config);
                return config;
            }
        }

        public static bool WriteConfig(TimelinerConfig config)
        {
            bool changedValue = true;

            lock (CONST_configFileName)
            {
                using (FileStream fileStream = new FileStream(GetConfigFilePath(), FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimelinerConfig));

                    try
                    {
                        xmlSerializer.Serialize(fileStream, config);
                    }
                    catch (Exception)
                    {
                        changedValue = false;
                    }
                }
            }

            return changedValue;
        }

        private static string GetConfigFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CONST_configFileName);
        }
    }
}