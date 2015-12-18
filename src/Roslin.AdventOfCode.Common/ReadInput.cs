using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Roslin.AdventOfCode.Common
{
    public static class Input
    {
        public static IEnumerable<string> Read(string path, Assembly assembly)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
