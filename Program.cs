
using System;

namespace StarDust
{
  public static class Program
  {

    [STAThread]
    private static void Main()
    {
      using (StarDust starDust = new StarDust())
        starDust.Run();
    }
  }
}
