using MathGame.Domain;

namespace MathGame.Engine;

/// <summary>
/// This is the model of the game.
/// </summary>
/// <param name="strategy">A GameStrategy object representing the game mode.</param>
/// <param name="totalRounds">The total number of rounds to play.</param>
public class GameEngine(GameStrategy strategy, int totalRounds)
{
    public int CurrentRound { get; private set; }
    public int RightAnswers { get; private set; }
    
    public ArithmeticExpression GenerateExpression()
    {
        CurrentRound++;
        return strategy.GenerateExpression();
    }

    public bool EvaluateGuess(ArithmeticExpression expr, int guess)
    {
        if (expr.Result == guess)
        {
            RightAnswers++;
            return true;
        }

        return false;
    }

    public bool GameOver => CurrentRound == totalRounds;
    public GameRecord Record => new GameRecord(strategy.Type, strategy.Difficulty, RightAnswers, CurrentRound);
}