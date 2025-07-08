namespace MathGame.Engine;

using MathGame.Domain;

/// <summary>
/// Multiplication game mode.
/// </summary>
public class MultiplicationStrategy : GameStrategy
{
    internal MultiplicationStrategy(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                LowerRange = 0;
                UpperRange = 13;
                break;
            case Difficulty.Medium:
                LowerRange = -50;
                UpperRange = 51;
                break;
            case Difficulty.Hard:
                LowerRange = -500;
                UpperRange = 501;
                break;
            case Difficulty.None:
                throw new ArgumentOutOfRangeException(nameof(difficulty), "Difficulty cannot be None.");
        }
    }
    
    public override ArithmeticExpression GenerateExpression()
    {
        return new Multiplication(GetRandomOperand(), GetRandomOperand());
    }
}