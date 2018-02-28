using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public interface IHit
  {
    bool Hit { get; }
    bool Sunk { get; }

    Type ShipType { get;  }
  }
}
