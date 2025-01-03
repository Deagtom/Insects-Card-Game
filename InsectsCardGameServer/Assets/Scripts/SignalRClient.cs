using Microsoft.AspNetCore.SignalR.Client;
using System;
using UnityEngine;

public class SignalRClient : MonoBehaviour
{
    private HubConnection connection;

    private async void Start()
    {
        connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5225/gamehub") // URL вашего SignalR-сервера
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Debug.Log($"Message from {user}: {message}");
        });

        try
        {
            await connection.StartAsync();
            Debug.Log("Connected to SignalR server.");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error connecting to SignalR server: {ex.Message}");
        }
    }

    private async void OnApplicationQuit()
    {
        await connection.StopAsync();
        await connection.DisposeAsync();
    }
}