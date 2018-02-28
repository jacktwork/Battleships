namespace Battleships
{
  public class StandardGrid : Grid
  {
    public StandardGrid() : base(10, new StandardLocationFormat())
    {
    }
  }
}

