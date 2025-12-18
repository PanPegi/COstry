
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        List<string> Items = GetItems("Data");
        Zkouseni(Items);
    }

    public static List<String> GetItems(string path)
    {
        List<String> Data = new List<String>();
        var directories = Directory.GetDirectories(path);
        foreach (string d in directories)
        {
            Data.AddRange(GetItems(d));
        }

        string[] contents = Directory.GetFiles(path);
        List<string> tmp = new List<string>();

        foreach (string c in contents)
        {
            Data.Add(c);
        }
        return Data;
    }

    public static void Zkouseni(List<string> Items)
    {
        Console.WriteLine("\n");

        Console.ReadLine();
        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(Items));

        foreach (string c in Items)
        {
            string path = Path.GetDirectoryName(c) + "\\x.jpg";
            File.Copy(c, path, true);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true
            };
            p.Start();

            Console.ReadLine();
            Console.WriteLine(c);
            Console.ReadLine();

            File.Delete(path);
        }
    }
}
