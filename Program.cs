using System;
using System.Threading.Tasks;

public class Program
{
    public static int RandomlyRecreate(string word)
    {
        Random random = new Random();
        int attempts = 0;
        string recreatedWord = "";

        while (recreatedWord != word)
        {
            recreatedWord = GenerateRandomWord(word.Length, random);
            attempts++;
        }

        return attempts;
    }

    public static Task<int> RandomlyRecreateAsync(string word)
    {
        return Task.Run(() => RandomlyRecreate(word));
    }

    private static string GenerateRandomWord(int length, Random random)
    {
        char[] wordChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            wordChars[i] = (char)('a' + random.Next(26));
        }

        return new string(wordChars);
    }

    public static async Task Main()
    {
        Console.WriteLine("Enter a word: ");
        string word = Console.ReadLine();

        DateTime startTime = DateTime.Now;
        int attempts = await RandomlyRecreateAsync(word);
        DateTime endTime = DateTime.Now;

        Console.WriteLine($"It took {attempts} attempts to randomly recreate the word \"{word}\".");
        Console.WriteLine($"Time Elapsed: {endTime - startTime}");
    }
}
