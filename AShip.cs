namespace Battleships
{
  public abstract class AShip : IShip
  {
    public int Size { get; set; }
    public string Description { get; set; }

    public AShip()
    {
      Size = 0;
      Description = string.Empty;
    }
  }
}
