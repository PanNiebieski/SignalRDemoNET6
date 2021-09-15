using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

var uri = "http://localhost:5000/chart";

await using var connection = new HubConnectionBuilder()
    .WithUrl(uri)
    .Build();

await connection.StartAsync();

await foreach (var item in
    connection.StreamAsync<List<ChartModel>>("Streaming"))
{
    Console.Clear();

    for (int i = 0; i < item.Count(); i++)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(item[i].Label + " : ");
        foreach (var number in item[i].Data)
        {
            Console.Write(number + "%");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string str = new string('=', number);
            Console.WriteLine(str);
        }
        Console.WriteLine("");
        Console.WriteLine("");
    }
}

public class ChartModel
{
    public List<int> Data { get; set; }
    public string Label { get; set; }
    public ChartModel()
    {
        Data = new List<int>();
    }
}
