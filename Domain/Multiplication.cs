namespace MathGame.Domain;

/// <summary>
/// A multiplication expression.
/// </summary>
/// <param name="multiplicand">The left operand.</param>
/// <param name="multiplier">The right operand.</param>
public class Multiplication(int multiplicand, int multiplier) : ArithmeticExpression(multiplicand, multiplier)
{
    public override int Result => LeftOperand * RightOperand;

    public override string ToString()
    {
        return $"{LeftOperand} * {RightOperand}";
    }
}