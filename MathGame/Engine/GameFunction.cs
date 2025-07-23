namespace MathGame.Engine;

public enum GameFunction
{
    None,
    Play,
    History,
    Quit
}

/// <summary>
/// Validation class for the above enum.
/// </summary>
class GameFunctionFactory
{
    public static GameFunction Create(int number)
    {
        var t = (GameFunction) number;
        
        if (!Enum.IsDefined(t))
        {
            throw new ArgumentOutOfRangeException($"The number {number} does not correspond to any function.");
        }

        return t;
    }
}