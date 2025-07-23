using System.Text;
using MathGame.Engine;

namespace MathGame.Domain;

public record GameRecord(string Type, Difficulty Difficulty, int RightAnswers, int Rounds)
{
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"Type: {Type}\n");
        sb.Append($"Difficulty: {Difficulty}\n");
        sb.Append($"Score: {RightAnswers}/{Rounds}");
        return sb.ToString();
    }
}