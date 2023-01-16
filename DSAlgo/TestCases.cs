using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo
{
    internal class TestCases
    {
        public static void Save()
        {
            var directoryPaths = Path.GetTempPath().Split("\\").Take(3);
            List<string> lines = new List<string>();
            var filepath = string.Join("\\",directoryPaths)+ @"\Downloads\fileInput (2).txt";
            if(File.Exists(filepath))
            {
                lines =File.ReadAllLines(filepath).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i] = lines[i].Replace(" ", ", ");
                }
            }
            File.WriteAllLines(filepath, lines);
        }
    }
}
