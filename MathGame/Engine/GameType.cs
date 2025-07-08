namespace MathGame.Engine;

/// <summary>
/// Possible game types.
/// </summary>
public enum GameType
{
    None,
    Addition,
    Subtraction,
    Multiplication,
    Division
}

/// <summary>
/// Validation class for the above enum.
/// </summary>
class GameTypeFactory
{
    public static GameType Create(int number)
    {
        var t = (GameType)number;
        
        if (!Enum.IsDefined(t))
        {
            throw new ArgumentOutOfRangeException($"The number {number} does not correspond to any game type.");
        }

        return t;
    }
}