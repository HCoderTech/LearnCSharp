using System.IO;
using System.Xml.Serialization;

namespace RegEx
{
    public class User
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string UserName { get; set; }
        private string UserID { get; set; }
        public void SetUserID(string id)
        {
            UserID = id;
        }

        public  void Serialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using(TextWriter writer = new StreamWriter(@fileName))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static User Deserialze(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            FileStream stream = new FileStream(fileName, FileMode.Open);
            return (User)serializer.Deserialize(stream);
        }
    }
}
