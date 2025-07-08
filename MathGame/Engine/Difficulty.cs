namespace MathGame.Engine;

/// <summary>
/// Possible game difficulties. Influences the ranges of the operands given.
/// </summary>
public enum Difficulty
{
    None,
    Easy,
    Medium,
    Hard
}

/// <summary>
/// Validation class for the above enum.
/// </summary>
class DifficultyFactory
{
    public static Difficulty Create(int number)
    {
        var d = (Difficulty)number;
        
        if (!Enum.IsDefined(d))
        {
            throw new ArgumentOutOfRangeException($"The number {number} does not correspond to any difficulty.");
        }

        return d;
    }
}