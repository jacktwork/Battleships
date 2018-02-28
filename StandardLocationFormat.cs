using System.Text.RegularExpressions;

namespace Battleships
{
  public class StandardLocationFormat : ILocationFormat
  {
    private Regex _rgx;

    public StandardLocationFormat()
    {
      // this could be a config setting?
      string pattern = "^[a-j]{1}[0-9]{1}$";
      _rgx = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public bool IsValidLocation(string location)
    {
      return _rgx.Matches(location).Count > 0;
    }

    public string Convert2DToKey(int x, int y)
    {
      return (char)(x + 97) + y.ToString();
    }
  }
}
