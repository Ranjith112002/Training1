string[] wordslist = File.ReadAllLines ("C:\\Users\\shanmugamra1\\Downloads\\words (1).txt");
char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
char requiredLetter = letters[0];
Dictionary<string, int> wordPoints = new Dictionary<string, int> ();
foreach (string word in wordslist)
   if (word.Length >= 4 && word.Contains (requiredLetter) && word.All (letters.Contains))
      wordPoints[word] = GetWordScore (word, letters);
foreach (var item in wordPoints.OrderByDescending (item => item.Value).ThenBy (item => item.Key)) {
   bool isPangram = IsPangram (item.Key, letters);
   if (isPangram) Console.ForegroundColor = ConsoleColor.Green;
   Console.WriteLine ($"{item.Value,3}. {item.Key}");
   if (isPangram) Console.ResetColor ();
}
Console.WriteLine ($"{wordPoints.Values.Sum ()} total");
int GetWordScore (string word, char[] letters) {
   int score = word.Length == 4 ? 1 : word.Length;
   return IsPangram (word, letters) ? score + 7 : score;
}
bool IsPangram (string word, char[] letters) => letters.All (word.Contains);