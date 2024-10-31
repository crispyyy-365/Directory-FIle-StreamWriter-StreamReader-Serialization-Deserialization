using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\User\OneDrive\Desktop\StreamReader\ConsoleApp1\ConsoleApp1\names.json";
            List<string> list = new List<string> {"alma", "armud", "heyva", "nar"};

            void Add(string name)
            {
                GetJson(path, list);
                list.Add(name);
                string result = JsonConvert.SerializeObject(list);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(result);
                }
            }
            bool Search(string name, List<string> list)
            {
                Predicate<string> predicate = x => x == name;

                foreach(string item in list)
                {
                    return predicate(item);
                }
                return false;
            }
            void Delete(int index)
            {
                GetJson(path, list);
                string name = list.Find(x => x == list[index]);
                list.Remove(name);
                string result = JsonConvert.SerializeObject(list);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(result);
                }
            }
            void GetJson(string path, List<string> names)
            {
                string result;
                using (StreamReader sr = new StreamReader(path)) 
                {
                    result = sr.ReadToEnd();
                }
                names = JsonConvert.DeserializeObject<List<string>>(result);
            }
            string name = "qarpiz";
            Add(name);
            Delete(3);
            Search(name, list);
        }
    }
}