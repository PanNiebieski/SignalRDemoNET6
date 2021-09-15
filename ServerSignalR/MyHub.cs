using Microsoft.AspNetCore.SignalR;

class MyHub : Hub
{
    public async IAsyncEnumerable<string> Streaming
        (CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

            if (_random.Next(0, 10) < 5)
                yield return DateTime.UtcNow.
                    ToString("hh:mm:ss");

            try
            {
                await Task.Delay(1000,
                    stoppingToken);
            }
            catch (OperationCanceledException)
            {
                yield break;
            }
        }
    }

    private Random _random = new Random();


}
