using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project1.Library
{
    public static class Serialize
    {
        public static void SerializeToFile(string fileName, DataList people)
        {
            var serializer = new XmlSerializer(typeof(DataList));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, people);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path {fileName} was too long! {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Some other error with file I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw; // re-throws the same exception
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        public async static Task<DataList> DeserializeFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(DataList));


            // we CAN do try/finally like this, but the using statement is easier
            //FileStream fileStream = null;
            //try
            //{
            //    fileStream = new FileStream(fileName, FileMode.Open);

            //    var result = (List<Person>)serializer.Deserialize(fileStream);
            //    return result;
            //}
            //finally
            //{
            //    fileStream.Dispose();
            //}

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0; // reset "cursor" of stream to beginning
                return (DataList)serializer.Deserialize(memoryStream);
            }
        }
    }
}
