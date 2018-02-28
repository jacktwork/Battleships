using System;

namespace Battleships
{
  public interface IShot
  {
    bool Hit { get; }
    bool Sunk { get; }
    string Description { get; }
  }
}
