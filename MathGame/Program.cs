namespace MathGame;

/// <summary>
/// Entry point for the app.
/// </summary>
class Program
{
    public static void Main(string[] args)
    {
        View view = new();
        MathGameApp app = new(view);
        app.Initialize();
        app.Run();
    }
}