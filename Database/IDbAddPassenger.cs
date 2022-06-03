using Core.Entities;

namespace Database;

public interface IDbAddPassenger
{
    BoardingPass GetData(BoardingPass boardingPass);
    void PutPassenger(BoardingPass boardingPass);
}