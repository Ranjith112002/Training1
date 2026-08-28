int secret = Random.Shared.Next (1, 101);
Console.WriteLine ("Think of a number between 1 and 100");
for (int tries = 1; tries <= 7; tries++) {
   int guess;
   while (!int.TryParse (Console.ReadLine (), out guess)) {
   }
   Guess result = CheckGuess (secret, guess);
   if (result == Guess.Exact) {
      Console.WriteLine ($"You guessed in {tries} tries.");
      break;
   }
   Console.WriteLine ($"Your guess is too {result}.");
   if (tries == 7) {
      Console.WriteLine ($"Game over! You couldn't guess the number. It was {secret}.");
   }
}
Guess CheckGuess (int secret, int guess) {
   if (guess == secret) return Guess.Exact;
   if (guess < secret) return Guess.Low;
   return Guess.High;
}
enum Guess { Low,High,Exact}