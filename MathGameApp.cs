namespace MathGame;

using MathGame.Engine;

/// <summary>
/// The MathGameApp is the game's controller/orchestrator.
/// </summary>
public class MathGameApp
{
    private View _view;
    private GameEngine _engine = null!;

    public MathGameApp(View view)
    {
        _view = view;
    }

    public void SetupGame()
    {
        _view.ShowHeader();
        _view.ShowAvailableGameTypes();
        var gameType = SetupGameType();
        _view.ShowAvailableDifficulties();
        var difficulty = SetupDifficulty();
        _view.ShowRoundsMessage();
        var numberOfRounds = SetupRounds();

        var strategy = GameStrategy.Create(gameType, difficulty);
        _engine = new GameEngine(strategy, numberOfRounds);
    }

    public void PlayGame()
    {
        while (!_engine.GameOver)
        {
            var expression = _engine.GenerateExpression();
            _view.ShowProblem(_engine.CurrentRound, expression);
            _view.ShowEnterGuessMessage();
            var guess = _view.GetNumberFromPlayer();
            var success = _engine.EvaluateGuess(expression, guess);
            _view.ShowRoundResult(success, expression.Result);
        }
        _view.ShowGameResult(_engine.RightAnswers, _engine.CurrentRound);
        _view.Quit();
    }

    private GameType SetupGameType()
    {
        GameType gameType = GameType.None;
        while (gameType == GameType.None)
        {
            var selection = _view.GetNumberFromPlayer();
            try
            {
                gameType = GameTypeFactory.Create(selection);
            }
            catch (ArgumentOutOfRangeException e)
            {
                _view.Display(e.Message);
            }
        }
        return gameType;
    }

    private Difficulty SetupDifficulty()
    {
        Difficulty difficulty = Difficulty.None;
        while (difficulty == Difficulty.None)
        {
            var selection = _view.GetNumberFromPlayer();
            try
            {
                difficulty = DifficultyFactory.Create(selection);
            }
            catch (ArgumentOutOfRangeException e)
            {
                _view.Display(e.Message);
            }
        }
        return difficulty;
    }

    private int SetupRounds()
    {
        var selection = _view.GetNumberFromPlayer();
        while (selection <= 0)
        {
            _view.Display("Please enter a positive integer for the number of rounds.");
            selection = _view.GetNumberFromPlayer();
        }
        return selection;
    }
}