int secret = Random.Shared.Next(1, 101);
Console.WriteLine("Think of a number between 1 and 100");
for (int tries = 1; tries <= 7; tries++) {
    int guess;
    while (!int.TryParse(Console.ReadLine(), out guess)) { }
    Guess result = guess switch {
        _ when guess == secret => Guess.Exact,
        _ when guess < secret => Guess.Low,
        _ when guess > secret => Guess.High
    };
    if (result == Guess.Exact) {
        Console.WriteLine($"You guessed in {tries} tries.");
        break;
    }
    Console.WriteLine($"Your guess is too {result}.");
    if (tries == 7) Console.WriteLine($"Game over! You couldn't guess the number. It was {secret}.");
}
enum Guess { Low, High, Exact }


