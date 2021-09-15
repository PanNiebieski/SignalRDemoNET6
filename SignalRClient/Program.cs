using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

var uri = "http://localhost:5000/chat";

await using var connection = new HubConnectionBuilder()
    .WithUrl(uri)
    .Build();

await connection.StartAsync();

await foreach (var item in
    connection.StreamAsync<string>("Streaming"))
{
    Console.WriteLine(item);
}


