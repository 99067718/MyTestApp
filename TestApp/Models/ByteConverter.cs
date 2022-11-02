using System.Text;

namespace TestApp.Models
{
    public class ByteConverter
    {
        public static byte[] StringToByte(string OldString)
        {
            //byte[] byteArray = Encoding.ASCII.GetBytes(OldString);
            byte[] byteArray = Convert.FromBase64String(OldString);
            return byteArray;
        }
        public static string ByteToString(byte[] ByteString)
        {
            return Convert.ToBase64String(ByteString);
            //return Encoding.ASCII.GetString(ByteString);
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static Stream ByteArrayToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public static void StreamToString(Stream stream)
        {
            
        }
    }
}