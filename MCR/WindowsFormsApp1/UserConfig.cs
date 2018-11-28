using MCR.adapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MCR
{
    /// <summary>
    /// A facade object managing all the user config (or preferences),
    /// saving the config on the disk in XML format.
    /// </summary>
    public class UserConfig
    {
        private const string CONFIG_FILE_NAME = "UserConfig.arping";
        private Encryptor encryptor = new RijndaelEncryptor();
        private static UserConfig instance = new UserConfig();

        public static UserConfig getInstance()
        {
            return instance;
        }

        private UserConfig()
        {
            if (!File.Exists(CONFIG_FILE_NAME))
                initXML();
        }

        private void initXML()
        {
            XDocument doc = 
                new XDocument(
                    new XElement("arping",
                        new XElement("users",
                            new XElement("account", ""),
                            new XElement("password", "")
                        ),
                        new XElement("resources",
                            new XElement("imageMatching",
                                /*彩蛋*/
                                new XElement("match", new XAttribute("studentId", "03360554" /*邱彥鈞*/), new XText("https://i.imgur.com/5kTPjsT.jpg")),
                                new XElement("match", new XAttribute("studentId", "03360296" /*潘冠辰*/), new XText("https://i.imgur.com/ZZEHg6K.png")),
                                new XElement("match", new XAttribute("studentId", "03361204" /*王甯*/), new XText("https://i.imgur.com/ITPcukc.jpg")),
                                new XElement("match", new XAttribute("studentId", "03360502" /*蔡勝豐*/), new XText("https://i.imgur.com/PJwJxVB.png")),
                                new XElement("match", new XAttribute("studentId", "04362481" /*張書瑄*/), new XText("https://i.imgur.com/dTPIkyO.jpg"))
                            )
                        ),
                        new XElement("server",
                            new XElement("port", 80)
                        )
                    )
                );
            var t = doc.ToString();
            doc.Save(CONFIG_FILE_NAME);
        }

        public string getAccount()
        {
            var value = XDocument
                .Load(CONFIG_FILE_NAME)
                .Descendants("account").First().Value;
            return encryptor.deparse(value);
        }

        public void setAccount(string account)
        {
            account = encryptor.parse(account);
            var doc = XDocument.Load(CONFIG_FILE_NAME);
            doc.Descendants("account").First().Value = account;
            doc.Save(CONFIG_FILE_NAME);
        }
        
        public string getPassword()
        {
            var value = XDocument
                .Load(CONFIG_FILE_NAME)
                .Descendants("password").First().Value;
            return encryptor.deparse(value);
        }

        public void setPassword(string password)
        {
            password = encryptor.parse(password);
            var doc = XDocument.Load(CONFIG_FILE_NAME);
            doc.Descendants("password").First().Value = password;
            doc.Save(CONFIG_FILE_NAME);
        }

        public Dictionary<string, string> getImageMatcingDict()
        {
            var dict = new Dictionary<string, string>();
            var matchElms = XDocument.Load(CONFIG_FILE_NAME)
                                    .Descendants("imageMatching").First()
                                    .Elements();
            foreach (var elm in matchElms)
                dict[(string) elm.Attribute("studentId")] = elm.Value;
            return dict;
        }

        public int getServerListeningPort()
        {
            var serverElm = XDocument.Load(CONFIG_FILE_NAME)
                                    .Descendants("server").Single();
            var portElm = serverElm.Elements("port").Single();
            return Convert.ToInt32(portElm.Value);
        }

        public void setServerListeningPort(int port)
        {
            var doc = XDocument.Load(CONFIG_FILE_NAME);
            var serverElm = doc.Descendants("server").Single();
            var portElm = serverElm.Elements("port").Single();
            portElm.Value = Convert.ToString(port);
            doc.Save(CONFIG_FILE_NAME);
        }
    }
}
