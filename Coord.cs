namespace Battleships
{
  public class Coord
  {
    public Coord(AShip ship)
    {
      Hit = false;
      Ship = ship;
    }
    public bool Hit { get; set; }
    public AShip Ship { get; }
  }
}
