int max = 100;
int maxTries = 7;
int secret = Random.Shared.Next (1, max + 1);
Console.WriteLine ($"I've thought of a number between 1 to {max}.");
Console.WriteLine ($"Try to guess it in {maxTries} tries or less.");
bool guessed = false;
for (int tries = 1; tries <= maxTries; tries++) {
   int guess = ReadInt ("> ");
   var result = CheckGuess (secret, guess);
   if (result == Guess.Exact) {
      Console.WriteLine ($"You guessed in {tries} tries.");
      guessed = true;
      break;
   }
   Console.WriteLine ($"Your guess is too {result}.");
}
if (!guessed) {
   Console.WriteLine ($"Game over! You couldn't guess the number. It was {secret}.");
}
Console.WriteLine ("\nPress any key to exit...");
Console.ReadKey (true);

Guess CheckGuess (int secret, int guess) {
   if (guess == secret) return Guess.Exact;
   if (guess < secret) return Guess.Low;
   return Guess.High;
}
int ReadInt (string prompt) {
   while (true) {
      Console.Write (prompt);
      if (int.TryParse (Console.ReadLine (), out int result))
         return result;
   }
}
enum Guess { Low, High, Exact }