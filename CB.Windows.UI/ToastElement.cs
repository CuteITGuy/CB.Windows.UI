using Windows.Data.Xml.Dom;


namespace CB.Windows.UI
{
    public abstract class ToastElement
    {
        #region Abstract
        public abstract void AddToToastContent(XmlDocument toastContent);
        #endregion


        #region Implementation
        protected virtual XmlElement GetParentElement(XmlDocument toastContent, string parentName)
        {
            var root = toastContent.DocumentElement;

            var parentElement = root.SelectSingleNode(parentName) as XmlElement;
            if (parentElement == null)
            {
                parentElement = toastContent.CreateElement(parentName);
                root.AppendChild(parentElement);
            }
            return parentElement;
        }
        #endregion
    }
}