using System.Net.WebSockets;
using System.Text;
using Core.Entities;
using MySqlX.XDevAPI;
using SocketIOClient;

namespace App.Services;

public class ScaleService 
{
    private const int Count = 300;
    private static int _scaleWeight = 0;
    private static int _countAt = 0;
    private static int[] avgList = new int[300];
    public int GetScaleData(int weight)
    {
        GetData(weight);
        return weight;
    }

    private async void GetData(int weight)
    {
        if (_scaleWeight == 0)
        {
            _scaleWeight = weight;

        }

        if (_countAt <= Count)
        {
            if (weight - _scaleWeight < 1 && weight - _scaleWeight > -1)
            {
                avgList[_countAt] = weight;
                _countAt++;
                _scaleWeight = weight;
            }
            else
            {
                _countAt = 0;
                _scaleWeight = 0;
            }
        }
        else if (_countAt > 300)
        {
            double avg = Queryable.Average(avgList.AsQueryable());
            _countAt = 0;
            _scaleWeight = 0;
            using (var client = new SocketIO("http://ws.rthia.hbo-ict.com:8082"))
            {
                await client.ConnectAsync();
                await client.EmitAsync("data", new {weight = weight});
            }


        }
    }
}