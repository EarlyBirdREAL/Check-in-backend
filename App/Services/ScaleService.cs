using System.Net.WebSockets;
using System.Text;
using Core.Entities;
using MySqlX.XDevAPI;
using SocketIOClient;

namespace App.Services;

public class ScaleService 
{
    private const int Count = 10;
    private static int _scaleWeight = 0;
    private static int _countAt = 0;
    private static int[] avgList = new int[11];
    public async Task<int> GetScaleData(int weight)
    {
        await GetData(weight);
        return weight;
    }

    private async Task<int> GetData(int weight)
    {
        if (_scaleWeight == 0)
        {
            _scaleWeight = weight;
            return _scaleWeight;
        }

        if (_countAt <= Count)
        {
            if (weight - _scaleWeight < 10 && weight - _scaleWeight > -10)
            {
                avgList[_countAt] = weight;
                _countAt++;
                _scaleWeight = weight;
                return _scaleWeight;
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
            using (var client = new SocketIO("http://ws.rthia.hbo-ict.com:8082"))
            {
                await client.ConnectAsync();
                await client.EmitAsync("data", new {weight = avg});
            }

            return weight;


        }

        return weight;
    }
}