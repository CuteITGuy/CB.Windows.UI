using Windows.Data.Xml.Dom;


namespace CB.Windows.UI
{
    public class ToastAudio
    {
        #region Fields
        private const string TOAST_AUDIO_NAMESPACE = "ms-winsoundevent:Notification";
        #endregion


        #region  Properties & Indexers
        public ToastAudioType AudioType { get; set; }

        public bool Loop { get; set; }

        public bool Silent { get; set; }
        #endregion


        #region Methods
        public void AddToToastContent(XmlDocument toastContent)
        {
            var audioElement = toastContent.SelectSingleNode("audio") as XmlElement;
            if (audioElement == null)
            {
                audioElement = toastContent.CreateElement("audio");
                toastContent.DocumentElement.AppendChild(audioElement);
            }
            audioElement.SetAttribute("src", ToString());
            if (Loop)
            {
                audioElement.SetAttribute("loop", "true");
                toastContent.DocumentElement.SetAttribute("duration", "long");
            }
            if (Silent)
            {
                audioElement.SetAttribute("silent", "true");
            }
        }
        #endregion


        #region Override
        public override string ToString()
        {
            var audioName = AudioType.ToString();
            return audioName.StartsWith("Call") || audioName.StartsWith("Alarm")
                       ? $"{TOAST_AUDIO_NAMESPACE}.Looping.{audioName}" : $"{TOAST_AUDIO_NAMESPACE}.{audioName}";
        }
        #endregion
    }
}