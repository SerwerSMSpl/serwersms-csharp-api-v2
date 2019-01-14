using System.Xml;

namespace SerwerSMS
{
    /// <summary>
    /// Provides extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts XML string to XML document.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns>XmlDocument object</returns>
        public static XmlDocument ToXmlDocument(this string s)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(s);
            return xmlDoc;
        }
    }
}
