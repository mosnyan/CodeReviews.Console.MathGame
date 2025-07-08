namespace MathGame.Domain;

/// <summary>
/// A division expression. No division by zero check is made here.
/// </summary>
/// <param name="dividend">The left operand.</param>
/// <param name="divisor">The right operand.</param>
public class Division(int dividend, int divisor) : ArithmeticExpression(dividend, divisor)
{
    public override int Result => LeftOperand / RightOperand;

    public override string ToString()
    {
        return $"{LeftOperand} / {RightOperand}";
    }
}