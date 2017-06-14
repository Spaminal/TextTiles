using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Dictionary {

	private static Dictionary<string, string> dict = new Dictionary<string, string>();
	private static Dictionary<char, int> letters = new Dictionary<char, int>();
	private static Dictionary<int, int> wordLength = new Dictionary<int, int>();
	private static int maxWordLength = 15, totalLetters = 0;

	// Fills dictionaries with unique words from external file
	static void fillDictionaries() {
		string line;
		int keyVal;
		System.IO.StreamReader file = new System.IO.StreamReader(
			@"C:\Users\Spaminal\Desktop\WordList.txt");
		while ((line = file.ReadLine()) != null) {
			if (line.Length <= maxWordLength) {
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
		}
		file.Close();
	}

	static void dictInfo() {
		Console.WriteLine("There are {0} Words", dict.Count);
		Console.WriteLine("There are {0} total letters", totalLetters);
		Console.WriteLine("The longest word is {0} letters long", maxWordLength);
	}

	static void letterFrequency() {
		foreach (KeyValuePair<char, int> entry in letters) {
			int keyValue = entry.Value;
			Console.WriteLine("Frequenchy of '{0}':  {1:0.00}%", entry.Key, Convert.ToDouble(entry.Value) / totalLetters * 100);
		}
	}

	static void wordCounts() {
		var items = from entry in wordLength
					orderby entry.Key ascending
					select entry;
		foreach (KeyValuePair<int, int> entry in wordLength) {
			Console.WriteLine("There are {0} words of length {1}", entry.Value, entry.Key);
		}
	}




	static void Main(string[] args) {

		fillDictionaries();
		dictInfo();
		//letterFrequency();
		wordCounts();

		Console.ReadKey();
	}
}