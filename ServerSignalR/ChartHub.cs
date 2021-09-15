using Microsoft.AspNetCore.SignalR;

public class ChartHub : Hub
{
    public async IAsyncEnumerable<List<ChartModel>> Streaming
    (CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {


            yield return DataManager.GetData();

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