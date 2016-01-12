using System;
using System.IO;
using System.Windows;
using CB.Windows.UI;


namespace TestToast
{
    public partial class MainWindow
    {
        #region Fields
        private readonly string _imageSource = "file:///" + Path.GetFullPath("image.png");
        private Toast _toast;
        #endregion


        #region  Constructors & Destructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Event Handlers
        private void CmdHideToast_OnClick(object sender, RoutedEventArgs e)
        {
            _toast.Hide();
        }

        private void CmdShowToast_OnClick(object sender, RoutedEventArgs e)
        {
            _toast = new Toast
            {
                Audio = new ToastAudio
                {
                    AudioType = ToastAudioType.SMS,
                    Loop = true
                },
                Commands = new[]
                {
                    new ToastCommand
                    {
                        CommandId = ToastCommandId.Snooze,
                        Arguments = "Snooze"
                    },
                    new ToastCommand
                    {
                        CommandId = ToastCommandId.Video,
                        Arguments = "Video"
                    },
                    new ToastCommand
                    {
                        CommandId = ToastCommandId.Decline,
                        Arguments = "Decline"
                    },
                    new ToastCommand
                    {
                        CommandId = ToastCommandId.Dismiss,
                        Arguments = "Dismiss"
                    },
                    new ToastCommand
                    {
                        CommandId = ToastCommandId.Voice,
                        Arguments = "Voice"
                    }
                },
                ExpirationTime = new DateTimeOffset(DateTime.Now.Add(TimeSpan.FromMinutes(1))),
                Image = new ToastImage
                {
                    Alt = "Calculator",
                    Path = "image.png",
                    SourceType = SourceType.LocalImage
                },
                Lines = new[] { "Test toast", "This is to test toast only. Test whether it can show a long long string. I doubt it. How about you?", "Now I believed. It can do out of my expectation. I love it!" }
            };
            _toast.Show();
        }
        #endregion
    }
}