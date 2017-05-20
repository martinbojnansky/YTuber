using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using YTuber.IoC;

namespace YTuber.Helpers
{
    public class Json : IResolvable
    {
        public T FromJson<T>(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)ser.ReadObject(stream);
            }
        }

        public string ToJson<T>(T obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, obj);
                var jsonArray = ms.ToArray();
                return Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
            }
        }
    }
}
