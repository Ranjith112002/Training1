var mode = GetMode();
Console.WriteLine(mode);
int max = getMax(mode);
int secret = Random.Shared.Next(1, max + 1);

Console.WriteLine($"I've thought of a number between 1 to {max}.");
Console.WriteLine("Try to guess it");

for (int tries = 1; ; tries++) {
    int guess = ReadInt("> ");
    var result = CheckGuess(secret, guess);
    if (result == Guess.Exact)
    {
        Console.WriteLine($"You guessed in {tries} tries.");
        break;
    }
    Console.WriteLine($"Your guess is too {result}.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey(true);

Guess CheckGuess (int secret, int guess) {
    if (guess == secret) return Guess.Exact;
    if (guess < secret) return Guess.Low;
    return Guess.High;
}

int ReadInt (string prompt) {
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int result))
            return result;
    }
}

int getMax (Mode mode) {
    switch (mode)
    {
        case Mode.Easy: return 10;
        case Mode.Medium: return 100;
        default: return 1000;
    }
}

Mode GetMode () {
    Console.Write("Select a Mode (E)asy, (M)edium, (H)ard: ");
    while (true)
    {
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.E: return Mode.Easy;
            case ConsoleKey.M: return Mode.Medium;
            case ConsoleKey.H: return Mode.Hard;
        }
    }
}

enum Mode { Easy, Medium, Hard }
enum Guess { Low, High, Exact }