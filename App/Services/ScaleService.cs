using System.Net.WebSockets;
using System.Text;
using Core.Entities;
using MySqlX.XDevAPI;

namespace App.Services;

public class ScaleService 
{
    private const int Count = 300;
    private static int _scaleWeight = 0;
    private static int _countAt = 0;
    private static int[] avgList = new int[300];
    public int GetScaleData(int weight)
    {
        return GetData(weight);
    }

    private int GetData(int weight)
    {
        if (_scaleWeight == 0)
        {
            _scaleWeight = weight;
            return weight;
        }

        if (_countAt<= Count)
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
            try
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                var exitEvent = new ManualResetEvent(false);
                var url = new Uri("ws://websocketserver.rthia.hbo-ict.com:80");

                using (var client = new ClientWebSocket())
                {
                    client.ConnectAsync(url, token);
                    var bytes = Encoding.ASCII.GetBytes($@"\{{weight: {avg}\}}");
                    ArraySegment<Byte> byteSegment = new ArraySegment<byte>(bytes);
                    client.SendAsync(byteSegment, WebSocketMessageType.Binary, WebSocketMessageFlags.EndOfMessage,
                        token);
                }

                return Int32.Parse(avg.ToString());
            }
            catch
            {
                return Int32.Parse(avg.ToString());
            }
        }

        return weight;

    }
}