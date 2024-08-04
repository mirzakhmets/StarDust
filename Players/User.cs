
using StarDust.Units;

namespace StarDust.Players
{
  public class User : Player
  {
    public User(Map Map)
      : base(Map)
    {
      this.Artifact = (Unit) new Units.Artifact((Player) this, 0, 0);
      Gate gate = new Gate((Player) this, 0, 1);
      Worker worker = new Worker((Player) this, 1, 0);
    }

    public override PlayerType Type() {
    	return PlayerType.USER;
    }
  }
}
