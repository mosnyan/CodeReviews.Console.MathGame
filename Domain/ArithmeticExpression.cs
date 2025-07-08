namespace MathGame.Domain;

/// <summary>
/// Abstract class for arithmetic expression.
/// </summary>
/// <param name="leftOperand">The left operand.</param>
/// <param name="rightOperand">The right operand.</param>
public abstract class ArithmeticExpression(int leftOperand, int rightOperand)
{
    protected int LeftOperand { get; } = leftOperand;
    protected int RightOperand { get; } = rightOperand;
    public abstract int Result { get; }
    public abstract override string ToString(); // Derived classes must override ToString() in turn.
}