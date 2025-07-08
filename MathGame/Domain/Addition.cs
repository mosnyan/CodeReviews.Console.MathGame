namespace MathGame.Domain;

/// <summary>
/// An addition expression.
/// </summary>
/// <param name="augend">The left operand.</param>
/// <param name="addend">The right operand.</param>
public class Addition(int augend, int addend) : ArithmeticExpression(augend, addend)
{
    public override int Result => LeftOperand + RightOperand;

    public override string ToString()
    {
        return $"{LeftOperand} + {RightOperand}";
    }
}