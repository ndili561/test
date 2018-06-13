using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace InCoreLib.DAL.Migrations
{
    public static class Files
    {
        public static Stream Get(string filename)
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name + "." + filename;
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var file = resources.FirstOrDefault(x => x.Contains(filename));
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(file);
        }

        public static string ReadAllText(string file)
        {
            var stream = Get(file);
            if (stream == null) return string.Empty;
            TextReader reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }
    }

    public static class Folder
    {
        public static List<string> GetFiles(string folder)
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name + "." + folder + ".";
            var list = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(f => f.StartsWith(name)).ToList();
            return list;
        }
    }


}
