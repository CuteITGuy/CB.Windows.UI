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
            var toastAudio = ToastAudio.Call4;
            toastAudio.Loop = true;

            _toast = new Toast
            {
                Audio = toastAudio,
                ExpirationTime = new DateTimeOffset(DateTime.Now.Add(TimeSpan.FromMinutes(1))),
                ImageSource = _imageSource,
                Lines = new[] { "Test _toast" }
            };
            _toast.Show();
        }
        #endregion
    }
}