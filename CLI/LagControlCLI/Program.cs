namespace LagControlCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Message.OnStart();

            var command = new Command();
            command.Exec(args);
        }
    }
}