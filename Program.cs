using System;
using System.Collections.Generic;

namespace AlBhedTranslator
{
    internal class Translator
    {
        private static void Main(string[] args)
        {
            //by default, the translator will translate from English to Al Bhed
            bool ABtoEN = false;

            if (args.Length == 0 || args[0] == "-h")
            {
                Console.WriteLine("this program translates English into Al Bhed\n");
                Console.WriteLine("usage: AlBhedTranslator.exe [string] [-a]\n");
                Console.WriteLine("  -a: translate from Al Bhed to English\n");
                return;
            }

            if (args.Length == 1)
            {
                if (args[0][0] == '-')
                {
                    Console.WriteLine("a parameter, but nothing to translate");
                    return;
                }
            }

            if (args.Length > 1)
            {
                if (args[args.Length - 1][0] == '-')
                {
                    if (args[args.Length - 1] == "-a")
                    {
                        ABtoEN = true;
                        args = args.Take(args.Length - 1).ToArray(); //remove the last argument, which is "-a"
                    }
                    else
                    {
                        Console.WriteLine("did you mean -a?");
                        return;
                    }
                }

                foreach (string word in args)
                {
                    if (word[0] == '-')
                    {
                        if (word != args[args.Length - 1])
                        {
                            Console.WriteLine("parameter must go at the very end");
                            return;
                        }
                    }
                }
            }

            string inputString = string.Join(" ", args);

            //keys are English, values are Al Bhed
            var abMap = new Dictionary<char, char>(){
                {'a', 'y'},
                {'b', 'p'},
                {'c', 'l'},
                {'d', 't'},
                {'e', 'a'},
                {'f', 'v'},
                {'g', 'k'},
                {'h', 'r'},
                {'i', 'e'},
                {'j', 'z'},
                {'k', 'g'},
                {'l', 'm'},
                {'m', 's'},
                {'n', 'h'},
                {'o', 'u'},
                {'p', 'b'},
                {'q', 'x'},
                {'r', 'n'},
                {'s', 'c'},
                {'t', 'd'},
                {'u', 'i'},
                {'v', 'j'},
                {'w', 'f'},
                {'x', 'q'},
                {'y', 'o'},
                {'z', 'w'}
            };

            if (ABtoEN)
            {
                abMap = abMap.ToDictionary(x => x.Value, x => x.Key);
            }

            char[] workingChars = new char[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                char toTranslate = inputString[i];
                bool isUpperCase = char.IsUpper(toTranslate);

                if (isUpperCase)
                {
                    toTranslate = char.ToLower(toTranslate);
                }

                if (abMap.TryGetValue(toTranslate, out char value))
                {
                    if (isUpperCase)
                    {
                        workingChars[i] = char.ToUpper(value);
                        continue;
                    }
                    workingChars[i] = value;
                }
                else
                {
                    workingChars[i] = toTranslate;
                }
            }

            string converted = new string(workingChars);

            Console.WriteLine($"{converted}");
        }
    }
}