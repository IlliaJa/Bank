using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank
{
    public class Settings
    {
        public static Settings GetSettings()
        {
            Settings settings = null;
            string filename = Globals.SettingsFile;

            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(Settings));
                    settings = (Settings)xser.Deserialize(fs);
                    fs.Close();
                }
            }
            else
            {
                settings = new Settings();
            }

            return settings;
        }

        public void Save()
        {
            string filename = Globals.SettingsFile;

            if (File.Exists(filename)) File.Delete(filename);


            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Settings));
                xser.Serialize(fs, this);
                fs.Close();
            }
        }


        public string Name { get; set; }
        public string Password { get; set; }
        public string Secondname { get; set; }
        public string currencyKr { get; set; }
        public string amountKr { get; set; }
        public string percentKr { get; set; }
        public string currencyDp { get; set; }
        public string amountDp { get; set; }
        public string percentDp { get; set; }
    }
}
