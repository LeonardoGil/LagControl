namespace LagControlCLI.Dialogs.Bases;

internal static class DialogCancellation
{
    private sealed class Scope(CancellationTokenSource? previous, CancellationTokenSource current) : IDisposable
    {
        private readonly CancellationTokenSource? previous = previous;
        private readonly CancellationTokenSource current = current;
        private int disposed;

        public void Dispose()
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
                return;

            Interlocked.CompareExchange(ref Current, previous, current);
            current.Dispose();
        }
    }

    private static CancellationTokenSource? Current;

    public static IDisposable SetCurrent(CancellationTokenSource cts) => new Scope(Interlocked.Exchange(ref Current, cts), cts);

    public static void CancelCurrent()
    {
        var cts = Volatile.Read(ref Current);
        
        if (cts is null)
            return;

        try
        {
            cts.Cancel();
        }
        catch { }
    }
}
