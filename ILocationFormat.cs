namespace Battleships
{
  public interface ILocationFormat
  {
    bool IsValidLocation(string location);

    string Convert2DToKey(int x, int y);
  }
}
