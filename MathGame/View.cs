using MathGame.Domain;

namespace MathGame;

using MathGame.Engine;

/// <summary>
/// The View classes manages the interaction with the player through the console.
/// </summary>
public class View
{
    public void ShowHeader()
    {
        Console.WriteLine("<><><> CLI Math Game <><><><><><><><><><><><><><><><><><><><><><><><><>");
        Console.WriteLine("\nThis game challenges you to find the answer to arithmetic operations.");
    }

    public void ShowAvailableGameTypes()
    {
        Console.WriteLine("\nPlease select the type of the game you want to play:");
        ShowMenuChoices(new GameType());
    }
    
    public void ShowAvailableDifficulties()
    {
        Console.WriteLine("\nPlease select the difficulty setting of the game:");
        ShowMenuChoices(new Difficulty());
    }

    public void ShowRoundsMessage()
    {
        Console.WriteLine("\nEnter the number of rounds to play:");
    }

    public void ShowEnterGuessMessage()
    {
        Console.WriteLine("Enter your guess:");
    }
    
    public void ShowProblem(int problemNumber, ArithmeticExpression expression)
    {
        Console.WriteLine($"\n<><><> Problem #{problemNumber} <><><><><><><><><><><><>");
        Console.WriteLine($"{expression} = ???");
    }

    public void ShowRoundResult(bool playerResult, int exprResult)
    {
        if (playerResult)
        {
            Console.WriteLine($"Good job! Answer was {exprResult}.");
        }
        else
        {
            Console.WriteLine($"Sorry! Answer was {exprResult}.");
        }
    }

    public void ShowGameResult(int goodGuesses, int totalGuesses)
    {
        Console.WriteLine("\nEnd of the game!");
        Console.WriteLine($"You've guessed {goodGuesses} problems correctly out of {totalGuesses}.");
        Console.WriteLine($"Result : {goodGuesses * 100.0 / totalGuesses:F2} %");
    }

    public void Quit()
    {
        Console.WriteLine("Press Enter to quit...");
        Console.ReadLine();
    }
    
    public int GetNumberFromPlayer()
    {
        do
        {
            var success = Int32.TryParse(Console.ReadLine(), out var selection);
            if (!success)
            {
                Console.WriteLine("Please enter a number.");
            }
            else
            {
                return selection;
            }
        } while (true);
    }
    
    public void Display(string message)
    {
        Console.WriteLine(message);
    }
    
    private void ShowMenuChoices(Enum e)
    {
        var names = Enum.GetNames(e.GetType());
        for (int i = 1; i < names.Length; i++)
        {
            Console.WriteLine($"{i}. {names[i]}");
        }
        
    }
}