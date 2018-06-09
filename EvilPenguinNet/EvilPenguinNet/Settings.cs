using System.Configuration;

namespace EvilPenguinNet
{
    public class Settings
    {
        /// <summary>
        /// トークン
        /// </summary>
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }

        public Settings()
        {
            ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            AccessSecret = ConfigurationManager.AppSettings["AccessSecret"];
        }
    }
}
