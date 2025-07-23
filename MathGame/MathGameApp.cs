using MathGame.Domain;

namespace MathGame;

using MathGame.Engine;

/// <summary>
/// The MathGameApp is the game's controller/orchestrator.
/// </summary>
public class MathGameApp
{
    private View _view;
    private GameEngine _engine = null!;
    private List<GameRecord> _history = [];

    public MathGameApp(View view)
    {
        _view = view;
    }

    public void Initialize()
    {
        _view.ShowHeader();
    }

    public void Run()
    {
        var gameFunction = GameFunction.None;
        while (gameFunction != GameFunction.Quit)
        {
            _view.ShowAvailableFunctions();
            gameFunction = SetupGameFunction();
            switch (gameFunction)
            {
                case GameFunction.Play:
                    SetupGame();
                    PlayGame();
                    break;
                case GameFunction.History:
                    ShowHistory();
                    break;
                case GameFunction.Quit:
                    _view.Quit();
                    break;
            } 
        }
    }

    private void SetupGame()
    {
        _view.ShowAvailableGameTypes();
        var gameType = SetupGameType();
        _view.ShowAvailableDifficulties();
        var difficulty = SetupDifficulty();
        _view.ShowRoundsMessage();
        var numberOfRounds = SetupRounds();

        var strategy = GameStrategy.Create(gameType, difficulty);
        _engine = new GameEngine(strategy, numberOfRounds);
    }

    private void PlayGame()
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
        _history.Add(_engine.Record);
    }

    private GameFunction SetupGameFunction()
    {
        GameFunction gameFunction = GameFunction.None;
        while (gameFunction == GameFunction.None)
        {
            var selection = _view.GetNumberFromPlayer();
            try
            {
                gameFunction = GameFunctionFactory.Create(selection);
                if (gameFunction == GameFunction.None)
                {
                    _view.Display($"The number {selection} does not correspond to any game type.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _view.Display($"The number {selection} does not correspond to any game type.");
            }
        }
        return gameFunction;
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
                if (gameType == GameType.None)
                {
                    _view.Display($"The number {selection} does not correspond to any game type.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _view.Display($"The number {selection} does not correspond to any game type.");
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
                if (difficulty == Difficulty.None)
                {
                    _view.Display($"The number {selection} does not correspond to any difficulty.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _view.Display($"The number {selection} does not correspond to any difficulty.");
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

    private void ShowHistory()
    {
        if (_history.Count == 0)
        {
            _view.Display("No games to show.");
        }
        else
        {
            int i = 0;
            foreach (var record in _history)
            {
                _view.Display($"Game {++i}\n" + record);
            }
        }
    }
}