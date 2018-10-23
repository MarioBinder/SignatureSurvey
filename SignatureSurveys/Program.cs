using System;

namespace SignatureSurveys
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("type your path: (press CTRL-V) ");

            ConsoleKeyInfo ki = Console.ReadKey(true);
            if ((ki.Key == ConsoleKey.V) && (ki.Modifiers == ConsoleModifiers.Control))
            {
                var cb = ClipBoard.PasteTextFromClipboard();
                Console.WriteLine("type your extensions comma seperated like: js,cs,cshtml");
                var readline = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readline))
                {
                    Console.WriteLine("abort..");
                    return;
                }

                string[] extensions = readline.Split(',');
                var path = cb.Remove(cb.Length - 1, 1);

                var survey = new Survey();

                var files = survey.ReadFiles(path, extensions);
                int locSum = 0;
                foreach (var file in files)
                {
                    var loc = survey.LinesOfCode(file);
                    locSum += loc;
                    var fileName = survey.GetClassName(file);
                    Console.WriteLine($"{fileName} | {loc} | {survey.GetSignature(file)}");
                }

                Console.Write($"Gesamtanzahl Code-Zeilen: {locSum}");
            }

            Console.ReadLine();
        }
    }
}
