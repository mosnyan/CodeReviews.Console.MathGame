using MathGame.Domain;

namespace MathGame.Engine;

/// <summary>
/// Abstract class for different game modes.
/// </summary>
public abstract class GameStrategy
{
    private Random _rng = new Random();
    protected int LowerRange { private get; init; } = 1;
    protected int UpperRange { private get; init; } = 1;

    protected GameStrategy()
    {
        
    }

    protected int GetRandomOperand()
    {
        return _rng.Next(LowerRange, UpperRange);
    }

    public abstract ArithmeticExpression GenerateExpression();
    
    public static GameStrategy Create(GameType type, Difficulty difficulty)
    {
        switch (type)
        {
            case GameType.Addition:
                return new AdditionStrategy(difficulty);
            case GameType.Subtraction:
                return new SubtractionStrategy(difficulty);
            case GameType.Multiplication:
                return new MultiplicationStrategy(difficulty);
            case GameType.Division:
                return new DivisionStrategy(difficulty);
            case GameType.None:
                throw new ArgumentOutOfRangeException(nameof(type), "Game type cannot be None.");
            default:
                throw new ArgumentException("Error creating the game instance");
        }
    }
}