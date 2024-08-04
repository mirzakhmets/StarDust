
using System;

namespace StarDust
{
  public class Utils
  {
    public static Random Random = new Random();

    public static int RandomNumber() {
    	return Utils.Random.Next();
    }

    public static int RandomNumber(int MaxValue) {
    	return Utils.Random.Next(MaxValue);
    }

    public static int RandomNumber(int MinValue, int MaxValue)
    {
      return Utils.Random.Next(MinValue, MaxValue);
    }

    public static int Sign(float f)
    {
      if ((double) f == 0.0)
        return 0;
      return (double) f >= 0.0 ? 1 : -1;
    }

    public static int Sign(int i)
    {
      if (i == 0)
        return 0;
      return i >= 0 ? 1 : -1;
    }
  }
}
