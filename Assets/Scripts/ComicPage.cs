using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;

/// <summary>
/// ComicChapter ist ein XML-Root, der alle Pages eines Kapitels als Knoten beinhaltet.
/// Jede Page hat einen Index, der für die Reihenfolge im Comic gedacht ist.
/// </summary>
/// 
[XmlRoot("ComicChapter")]
public class ComicChapter
{
    [XmlArray("ComicPages"), XmlArrayItem("ComicPage")]
    List<ComicPage> comicPages = new List<ComicPage>();

    #region Functions

    public static ComicChapter LoadFromFile(string fileName)
    {
        XmlSerializer xS = new XmlSerializer(typeof(ComicChapter));

        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            return (ComicChapter)xS.Deserialize(fs);
        }
    }

    public void SaveToFile(string fileName)
    {
        XmlSerializer xS = new XmlSerializer(typeof(ComicChapter));

        using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            xS.Serialize(sw, this);
        }
    }

    #endregion Functions

    public class ComicPage
    {
        #region Fields

        [XmlArray("SpeechBubbles"), XmlArrayItem("SpeechBubble")]
        public List<ContentHolder> SpeechBubbles = new List<ContentHolder>();

        [XmlArray("SoundEffects"), XmlArrayItem("SoundEffect")]
        public List<ContentHolder> SoundEffects = new List<ContentHolder>();

        [XmlAttribute("index")]
        public int index;

        [XmlAttribute("picture")]
        public string picture;

        #endregion Fields

        #region Classes

        /// <summary>
        /// Ein ContentHolder kann entweder eine Dialog-Sprechblase beinhalten oder einen Sound-Effect (*Wwwuschhhhh*). 
        /// </summary>
        public class ContentHolder
        {
            #region Fields
            [XmlArray("DialogLines"), XmlArrayItem("DialogLine")]
            public Dictionary<string, string> DialogLines = new Dictionary<string, string>();

            [XmlArray("DialogAudios"), XmlArrayItem("DialogAudio")]
            public Dictionary<string, string> DialogAudios = new Dictionary<string, string>();

            [XmlAttribute("posX")]
            private float posX;

            [XmlAttribute("posY")]
            private float posY;

            [XmlAttribute("maxHeight")]
            private float maxHeight;

            [XmlAttribute("maxWidth")]
            private float maxWidth;

            #endregion Fields

            #region Properties

            public float PosX
            {
                get
                {
                    return posX;
                }

                set
                {
                    posX = value;
                }
            }

            public float PosY
            {
                get
                {
                    return posY;
                }

                set
                {
                    posY = value;
                }
            }

            public float MaxHeight
            {
                get
                {
                    return maxHeight;
                }

                set
                {
                    if (value < 0)
                    {
                        maxHeight = 0;
                    }
                    else
                        maxHeight = value;
                }
            }

            public float MaxWidth
            {
                get
                {
                    return maxWidth;
                }

                set
                {
                    if (value < 0)
                    {
                        maxWidth = 0;
                    }
                    else
                        maxWidth = value;
                }
            }

            #endregion Properties
        }

        #endregion Classes
    }

}

