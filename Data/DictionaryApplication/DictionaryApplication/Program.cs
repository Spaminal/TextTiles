using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class Dictionary {

	private static List<string> wordList = new List<string>();
	private static List<string> alphaList = new List<string>();
	
	static void Main(string[] args) {

		List<string> parsedList = new List<string>();
		initAlpha();
		initWordList();
		displayMenuOptions();

		while (true) {
			int length, count;
			double freq;
			char ch;
			string line = Console.ReadLine();
			if (line == "exit") {
				break;
			} else if (line == "1") {
				printListInfo();
			} else if (line == "2") {
				Console.WriteLine("Enter word length: ");
				length = int.Parse(Console.ReadLine());
				parsedList = parseWordsByLength(length, parsedList);
				Console.WriteLine("There are {0} words of length {1}", parsedList.Count, length);
			} else if (line == "3") {
				Console.WriteLine("Enter word Length: ");
				length = int.Parse(Console.ReadLine());
				//Console.WriteLine("Enter letter to filter by: ");
				//ch = char.Parse(Console.ReadLine());
				foreach (string word in alphaList) {
					ch = char.Parse(word);
					parsedList = parseWordsByLength(length, parsedList);
					count = getWordsWithChar(ch, parsedList);
					Console.WriteLine("There are {0} words that contain the letter {1}", count, ch);
				}
			} else if (line == "4") {
				Console.WriteLine("Enter letter: ");
				ch = char.Parse(Console.ReadLine());
				freq = getLetterFrequency(ch, wordList);
				Console.WriteLine("Frequency of {0} in all words is: {1:0.00}%", ch, freq);
			} else if(line == "5") {
				Console.WriteLine("Enter letter: ");
				ch = char.Parse(Console.ReadLine());
				Console.WriteLine("Enter word length: ");
				length = int.Parse(Console.ReadLine());
				parsedList = parseWordsByLength(length, parsedList);
				freq = getLetterFrequency(ch, parsedList);
				Console.WriteLine("Frequency of {0} in words of length {1} is: {2:0.00}%", ch, length, freq);
			}
		}
	}

	// Populates wordList with complete list of English words
	static void initWordList() {
		string line;
			System.IO.StreamReader file = new System.IO.StreamReader(@"D:\UnityRepository\TextTiles\Data\DictionaryApplication\DictionaryApplication\WordList.txt");
		while ((line = file.ReadLine()) != null) {
			wordList.Add(line);
		}
		file.Close();
	}

	// Populates list with words of length n
	static List<string> parseWordsByLength(int length, List<string> list) {
		list.Clear();
		foreach (string word in wordList) {
			if (word.Length == length) {
				list.Add(word.ToLower());
			}
		}
		return list;
	}

	// Gets the number of words that contain the letter ch
	static int getWordsWithChar(char ch, List<string> list) {
		int count = 0;
		foreach (string word in list) {
			if (word.Contains(ch)) {
				count++;
			}
		}
		return count;
	}

	// Gets the frequency of the letter ch of the wordlist list
	static double getLetterFrequency(char ch, List<string> list) {
		double charCount = 0, totalLetters = 0;
		foreach (string word in list) {
			foreach (char letter in word) {
				if (letter == ch) {
					charCount++;
				}
				totalLetters++;
			}
		}
		return charCount / totalLetters * 100;
	}

	static void printListInfo() {
		Console.WriteLine("There are {0} words in the dictionary", wordList.Count);
	}

	static void displayMenuOptions() {
		Console.WriteLine("Dictoinary Database for TextTiles\n");
		Console.WriteLine("1) Get total word count");
		Console.WriteLine("2) Get count of words of length 'n'");
		Console.WriteLine("3) Get count of words of length n containing the letter 'ch'");
		Console.WriteLine("4) Get total frequency of letter 'ch' in all words");
		Console.WriteLine("5) Get frequency of letter 'ch' found in words of length 'n'");
		Console.WriteLine("Type 'exit' to quit");
	}

	static void initAlpha() {
		alphaList.Add("a");
		alphaList.Add("b");
		alphaList.Add("c");
		alphaList.Add("d");
		alphaList.Add("e");
		alphaList.Add("f");
		alphaList.Add("g");
		alphaList.Add("h");
		alphaList.Add("i");
		alphaList.Add("j");
		alphaList.Add("k");
		alphaList.Add("l");
		alphaList.Add("m");
		alphaList.Add("n");
		alphaList.Add("o");
		alphaList.Add("p");
		alphaList.Add("q");
		alphaList.Add("r");
		alphaList.Add("s");
		alphaList.Add("t");
		alphaList.Add("u");
		alphaList.Add("v");
		alphaList.Add("w");
		alphaList.Add("x");
		alphaList.Add("y");
		alphaList.Add("z");
	}
}