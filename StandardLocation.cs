using System.Text.RegularExpressions;

namespace Battleships
{
  public class StandardLocation
  {
    private Regex _rgx;

    public StandardLocation()
    {
      string pattern = "^[a-j]{1}[0-9]{1}$";
      _rgx = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public bool IsValidLocation(string location)
    {
      return _rgx.Matches(location).Count > 0;
    }
  }
}
