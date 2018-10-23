using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SignatureSurveys
{
    public class Survey
    {
        public List<string> ReadFiles(string path, string[] extension)
        {
            List<string> result = new List<string>();
            foreach (var ext in extension)
            {
                result.AddRange(Directory.GetFiles(path, "*." + ext, SearchOption.AllDirectories).ToList());
            }
            return result;
        }

        public int LinesOfCode(string classname)
        {
            var loc = File.ReadAllLines(classname);
            return loc.Length;
        }

        public string GetClassName(string path)
        {
            return Path.GetFileName(path);
        }

        public string GetSignature(string path)
        {
            var code = File.ReadAllText(path);

            var regEx = new Regex("[^{ } ; ]");
            return regEx.Replace(code, "").Replace("\t", "").Replace(" ", "");
        }

    }
}