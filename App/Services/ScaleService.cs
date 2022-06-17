using System.Net.WebSockets;
using System.Text;
using Core.Entities;
using MySqlX.XDevAPI;
using SocketIOClient;
using Ubiety.Dns.Core;

namespace App.Services;

public class ScaleService 
{
    private const int Count = 10;
    private static int _scaleWeight = 0;
    private static int _countAt = 0;
    private static int[] avgList = new int[11];
    public async Task<int> GetScaleData(int weight)
    {
        return await GetData(weight);
    }

    private async Task<int> GetData(int weight)
    {
        if (_scaleWeight == 0)
        {
            _scaleWeight = weight;
            return _countAt;
        }

        if (_countAt <= Count)
        {
            if (weight - _scaleWeight < 10 && weight - _scaleWeight > -10)
            {
                avgList[_countAt] = weight;
                _countAt++;
                _scaleWeight = weight;
                return _countAt;
            }
            else
            {
                _countAt = 0;
                _scaleWeight = 0;
                return 999999;
            }
        }
        else if (_countAt > 10)
        {
            double avg = Queryable.Average(avgList.AsQueryable());
            _countAt = 0;
            _scaleWeight = 0;
            using (var client = new SocketIO("ws://10.110.0.2:8082"))
            {
                await client.ConnectAsync();
                await client.EmitAsync("data", new {weight = avg});
            }
            System.Diagnostics.Debug.WriteLine("test");

            return _countAt;


        }

        return _countAt;
    }
}