using System;

namespace Battleships
{
  public static class ObjectFactory
  {
    public static AShip CreateShip(Type type)
    {
      if (type == typeof(Battleship))
        return new Battleship();
      if (type == typeof(Destroyer))
        return new Destroyer();

      throw new Exception("Invalid type");
    }
  }
}
