namespace Battleships
{
  public interface IGrid
  {
    int Size { get; set; }
    ShotReport Shot(string location);
  }
}
