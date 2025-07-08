namespace MathGame.Domain;

/// <summary>
/// A subtraction expression.
/// </summary>
/// <param name="minuend">The left operand.</param>
/// <param name="subtrahend">The right operand.</param>
public class Subtraction(int minuend, int subtrahend) : ArithmeticExpression(minuend, subtrahend)
{
    public override int Result => LeftOperand - RightOperand;

    public override string ToString()
    {
        return $"{LeftOperand} - {RightOperand}";
    }
}