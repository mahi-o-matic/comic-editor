using System.Collections.Generic;
using System.IO;

/// <summary>
/// ComicChapter ist ein XML-Root, der alle Pages eines Kapitels als Knoten beinhaltet.
/// Jede Page hat einen Index, der für die Reihenfolge im Comic gedacht ist.
/// </summary>
public class ComicChapter
{
    List<ComicPage> comicPages = new List<ComicPage>();

    #region Functions

    public void LoadFile()
    {
        throw new System.NotImplementedException();
    }

    public void SaveFile()
    {
        throw new System.NotImplementedException();
    }

    #endregion Functions

    public class ComicPage
    {
        #region Fields

        public List<ContentHolder> speechBubbles = new List<ContentHolder>();
        public List<ContentHolder> soundEffects = new List<ContentHolder>();

        public string picture;

        #endregion Fields

        #region Classes

        /// <summary>
        /// Ein ContentHolder kann entweder eine Dialog-Sprechblase beinhalten oder einen Sound-Effect (*Wwwuschhhhh*). 
        /// </summary>
        public class ContentHolder
        {
            #region Fields
            public List<DialogLine> dialogLines = new List<DialogLine>();
            public List<DialogAudio> dialogAudios = new List<DialogAudio>();
            private float positonX;
            private float positionY;
            private float maxHeight;
            private float maxWidth;

            #endregion Fields

            #region Propertys

            public float PositionX
            {
                get
                {
                    return positonX;
                }

                set
                {
                    positonX = value;
                }
            }

            public float PositonY
            {
                get
                {
                    return positionY;
                }

                set
                {
                    positionY = value;
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

            #endregion Propertys
        }

        /// <summary>
        /// Falls Dialogline als Soundeffect verwendet wird, wird der Valuestring als Pfad verwendet.
        /// </summary>
        public class DialogLine
        {
            private Dictionary<string, string> lines = new Dictionary<string, string>();
        }

        public class DialogAudio
        {
            private string audioClips;
        }

        #endregion Classes
    }

}

