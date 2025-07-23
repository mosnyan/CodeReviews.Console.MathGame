namespace MathGame.Engine;

using MathGame.Domain;

/// <summary>
/// Subtraction game mode.
/// 
/// </summary>
public class SubtractionStrategy : GameStrategy
{
    public override string Type { get; init; } = "Subtraction";
    internal SubtractionStrategy(Difficulty difficulty) : base(difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                LowerRange = 0;
                UpperRange = 21;
                break;
            case Difficulty.Medium:
                LowerRange = -100;
                UpperRange = 101;
                break;
            case Difficulty.Hard:
                LowerRange = -1000;
                UpperRange = 1001;
                break;
            case Difficulty.None:
                throw new ArgumentOutOfRangeException(nameof(difficulty), "Difficulty cannot be None.");
        }
    }

    public override ArithmeticExpression GenerateExpression()
    {
        return new Subtraction(GetRandomOperand(), GetRandomOperand());
    }
}