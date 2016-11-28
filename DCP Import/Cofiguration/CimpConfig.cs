using System.Configuration;

namespace JLR.CFM.DCP.Import
{
    public class CimpConfig : ConfigurationSection
    {
        private static CimpConfig _cimpconfig = (CimpConfig)ConfigurationManager.GetSection("cimplicity");
        public static CimpConfig Settings { get { return _cimpconfig; } }

        //**************************************************************************************

        [ConfigurationProperty("project")]
        public string Project { get { return (string)base["project"]; } }

        [ConfigurationProperty("username")]
        public string User { get { return (string)base["username"]; } }

        [ConfigurationProperty("password")]
        public string Password { get { return (string)base["password"]; } }

        [ConfigurationProperty("path")]
        public string Path { get { return (string)base["path"]; } }

        [ConfigurationProperty("database")]
        public CimpDatabase Database { get { return (CimpDatabase)base["database"]; } }

        [ConfigurationProperty("classes")]
        public CimpClasses Classes { get { return (CimpClasses)base["classes"]; } }

        [ConfigurationProperty("params")]
        public CimpParams GlobalParams { get { return (CimpParams)base["params"]; } }
    }

    public class CimpDatabase : ConfigurationElement
    {
        [ConfigurationProperty("DSN", IsRequired = true)]
        public string DSN { get { return (string)base["DSN"]; } }

        [ConfigurationProperty("uid", IsRequired = true)]
        public string User { get { return (string)base["uid"]; } }

        [ConfigurationProperty("pwd", IsRequired = true)]
        public string Password { get { return (string)base["pwd"]; } }
    }
}