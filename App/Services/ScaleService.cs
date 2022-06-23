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
        
        if (_scaleWeight == 0 || weight < 3)
        {
            _scaleWeight = weight;
            _countAt = 0;
            Array.Clear(avgList, 0, avgList.Length);
            return _countAt;
        }

        if (_countAt <= Count)
        {
            if (weight - _scaleWeight < 2 && weight - _scaleWeight > -2 || weight < 8)
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
                Array.Clear(avgList, 0, avgList.Length);
                return 999999;
            }
        }
        else if (_countAt > 10)
        {
            double avg = Queryable.Average(avgList.AsQueryable());
            _countAt = 0;
            _scaleWeight = 0;
            Array.Clear(avgList, 0, avgList.Length);
            using (var client = new SocketIO("ws://ws.rthia.hbo-ict.com:8082"))
            {
                await client.ConnectAsync();
                await client.EmitAsync("data", new {weight = avg});
            }
            System.Diagnostics.Debug.WriteLine("test");
            Array.Clear(avgList, 0, avgList.Length);
            return _countAt;


        }

        return _countAt;
    }
}