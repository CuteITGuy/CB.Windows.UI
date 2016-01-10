using Windows.Data.Xml.Dom;


namespace CB.Windows.UI
{
    public class ToastAudio
    {
        #region Fields
        private const string TOAST_AUDIO_NAMESPACE = "ms-winsoundevent:Notification";
        private static ToastAudio _alarm;
        private static ToastAudio _alarm10;
        private static ToastAudio _alarm2;
        private static ToastAudio _alarm3;
        private static ToastAudio _alarm4;
        private static ToastAudio _alarm5;
        private static ToastAudio _alarm6;
        private static ToastAudio _alarm7;
        private static ToastAudio _alarm8;
        private static ToastAudio _alarm9;
        private static ToastAudio _call;
        private static ToastAudio _call10;
        private static ToastAudio _call2;
        private static ToastAudio _call3;
        private static ToastAudio _call4;
        private static ToastAudio _call5;
        private static ToastAudio _call6;
        private static ToastAudio _call7;
        private static ToastAudio _call8;
        private static ToastAudio _call9;
        private static ToastAudio _default;
        private static ToastAudio _im;
        private static ToastAudio _mail;
        private static ToastAudio _reminder;
        private static ToastAudio _sms;
        private readonly string _audioName;
        #endregion


        #region  Constructors & Destructor
        private ToastAudio(string audioName)
        {
            _audioName = audioName;
        }
        #endregion


        #region  Properties & Indexers
        public static ToastAudio Alarm => _alarm ?? (_alarm = new ToastAudio("Alarm"));

        public static ToastAudio Alarm10 => _alarm10 ?? (_alarm10 = new ToastAudio("Alarm10"));

        public static ToastAudio Alarm2 => _alarm2 ?? (_alarm2 = new ToastAudio("Alarm2"));

        public static ToastAudio Alarm3 => _alarm3 ?? (_alarm3 = new ToastAudio("Alarm3"));

        public static ToastAudio Alarm4 => _alarm4 ?? (_alarm4 = new ToastAudio("Alarm4"));

        public static ToastAudio Alarm5 => _alarm5 ?? (_alarm5 = new ToastAudio("Alarm5"));

        public static ToastAudio Alarm6 => _alarm6 ?? (_alarm6 = new ToastAudio("Alarm6"));

        public static ToastAudio Alarm7 => _alarm7 ?? (_alarm7 = new ToastAudio("Alarm7"));

        public static ToastAudio Alarm8 => _alarm8 ?? (_alarm8 = new ToastAudio("Alarm8"));

        public static ToastAudio Alarm9 => _alarm9 ?? (_alarm9 = new ToastAudio("Alarm9"));

        public static ToastAudio Call => _call ?? (_call = new ToastAudio("Call"));

        public static ToastAudio Call10 => _call10 ?? (_call10 = new ToastAudio("Call10"));

        public static ToastAudio Call2 => _call2 ?? (_call2 = new ToastAudio("Call2"));

        public static ToastAudio Call3 => _call3 ?? (_call3 = new ToastAudio("Call3"));

        public static ToastAudio Call4 => _call4 ?? (_call4 = new ToastAudio("Call4"));

        public static ToastAudio Call5 => _call5 ?? (_call5 = new ToastAudio("Call5"));

        public static ToastAudio Call6 => _call6 ?? (_call6 = new ToastAudio("Call6"));

        public static ToastAudio Call7 => _call7 ?? (_call7 = new ToastAudio("Call7"));

        public static ToastAudio Call8 => _call8 ?? (_call8 = new ToastAudio("Call8"));

        public static ToastAudio Call9 => _call9 ?? (_call9 = new ToastAudio("Call9"));

        public static ToastAudio Default => _default ?? (_default = new ToastAudio("Default"));

        public static ToastAudio IM => _im ?? (_im = new ToastAudio("IM"));

        public static ToastAudio Mail => _mail ?? (_mail = new ToastAudio("Mail"));

        public static ToastAudio Reminder => _reminder ?? (_reminder = new ToastAudio("Reminder"));

        public static ToastAudio SMS => _sms ?? (_sms = new ToastAudio("SMS"));

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
            return _audioName.StartsWith("Call") || _audioName.StartsWith("Alarm")
                       ? $"{TOAST_AUDIO_NAMESPACE}.Looping.{_audioName}" : $"{TOAST_AUDIO_NAMESPACE}.{_audioName}";
        }
        #endregion
    }
}