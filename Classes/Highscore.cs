using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Garbage.Classes
{
    public static class Highscore
    {
        public static string[] Name = new string[5];
        public static int[] Score = new int[5];

        public static void LoadHighschores()
        {
            if (!File.Exists("Highscores.xml"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Name[i] = "None";
                    Score[i] = 0;
                }
                SaveHighscores();
            }

            XmlReader xmlReader = XmlReader.Create("Highscores.xml");
            xmlReader.ReadToFollowing("FirstName");
            Name[0] = xmlReader.ReadElementContentAsString();
            xmlReader.ReadToFollowing("FirstScore");
            Score[0] = xmlReader.ReadElementContentAsInt();
            xmlReader.ReadToFollowing("SecondName");
            Name[1] = xmlReader.ReadElementContentAsString();
            xmlReader.ReadToFollowing("SecondScore");
            Score[1] = xmlReader.ReadElementContentAsInt();
            xmlReader.ReadToFollowing("ThirdName");
            Name[2] = xmlReader.ReadElementContentAsString();
            xmlReader.ReadToFollowing("ThirdScore");
            Score[2] = xmlReader.ReadElementContentAsInt();
            xmlReader.ReadToFollowing("FourthName");
            Name[3] = xmlReader.ReadElementContentAsString();
            xmlReader.ReadToFollowing("FourthScore");
            Score[3] = xmlReader.ReadElementContentAsInt();
            xmlReader.ReadToFollowing("FifthName");
            Name[4] = xmlReader.ReadElementContentAsString();
            xmlReader.ReadToFollowing("FifthScore");
            Score[4] = xmlReader.ReadElementContentAsInt();
            xmlReader.Close();
        }

        public static void SaveHighscores()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true
            };

            XmlWriter xmlWriter = XmlWriter.Create("Highscores.xml", xmlWriterSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Highscores");
            xmlWriter.WriteElementString("FirstName", Name[0]);
            xmlWriter.WriteElementString("FirstScore", Score[0].ToString());
            xmlWriter.WriteElementString("SecondName", Name[1]);
            xmlWriter.WriteElementString("SecondScore", Score[1].ToString());
            xmlWriter.WriteElementString("ThirdName", Name[2]);
            xmlWriter.WriteElementString("ThirdScore", Score[2].ToString());
            xmlWriter.WriteElementString("FourthName", Name[3]);
            xmlWriter.WriteElementString("FourthScore", Score[3].ToString());
            xmlWriter.WriteElementString("FifthName", Name[4]);
            xmlWriter.WriteElementString("FifthScore", Score[4].ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
