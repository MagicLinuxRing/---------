using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ForKids.Util
{
    public class ConfigOper
    {
        /// <summary>
        /// 获取AppSeting配置值
        /// </summary>
        /// <param name="key">AppSeting关键字</param>
        /// <returns>AppSeting配置值</returns>
        public static string GetAppSetting(string key, string configName = "ForKids\\Config\\app.Config")
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            return config.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// 设置AppSeting配置值
        /// </summary>
        /// <param name="key">AppSeting关键字</param>
        /// <param name="value">AppSeting配置值</param>
        public static void SetAppSetting(string key, string value, string configName = "ForKids\\Config\\app.Config")
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }

        public static string SqlConnString
        {
            get
            {
                //return DBMana.Properties.Settings.Default.CQWSDBConnectionString;
                string connString=GetAppSetting("ConnectionString");
                return connString.Replace("Data Source=", "Data Source=" + AppDomain.CurrentDomain.BaseDirectory);
            }
        }
    }
}
