using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Dictionary {

    static void Main(string[] args) {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        Dictionary<char, int> letters = new Dictionary<char, int>();
        Dictionary<int, int> wordLength = new Dictionary<int, int>();
        string line;
        int longWord = 15, totalLetters = 0, keyVal;
        System.IO.StreamReader file = new System.IO.StreamReader(
            @"C:\Users\Spaminal\Desktop\WordList.txt");
        while ((line = file.ReadLine()) != null) {
            if (line.Length <= longWord) {
                dict.Add(line, line);
                if (wordLength.ContainsKey(line.Length)) {
                    keyVal = wordLength[line.Length];
                    wordLength[line.Length] = keyVal + 1;
                } else {
                    wordLength.Add(line.Length, 1);
                }
                foreach (char ch in line) {
                    if (letters.ContainsKey(ch)) {
                        keyVal = letters[ch];
                        letters[ch] = keyVal + 1;
                    } else {
                        letters.Add(ch, 1);
                    }
                    totalLetters++;
                }
            }
        } // end while
        file.Close();

        Console.WriteLine("There are {0} Words", dict.Count);
        Console.WriteLine("There are {0} total letters", totalLetters);
        Console.WriteLine("The longest word is {0} letters long", longWord);

        foreach(KeyValuePair<int, int> entry in wordLength) {
            Console.WriteLine("There are {0} words of length {1}", entry.Value, entry.Key);
        }

        foreach(KeyValuePair<char, int> entry in letters) {
            int keyValue = entry.Value;
            Console.WriteLine("Frequenchy of '{0}':  {1}%", entry.Key, 
                Convert.ToDouble(entry.Value) / totalLetters * 100); 
        }

        Console.ReadKey();
    }
}