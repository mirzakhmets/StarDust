
using Microsoft.Xna.Framework.Graphics;

namespace StarDust.Units
{
  public class Gate : Unit
  {
    public static Texture2D StaticView;

    public Gate(Player Player, int Row, int Col)
      : base(Player, Row, Col)
    {
      this.View = Gate.StaticView;
      this.HealthPoints = 200;
    }

    public override UnitType Type() {
    	return UnitType.GATE;
    }

    public override bool Moveable() {
    	return false;
    }

    public new static void LoadContent(StarDust StarDust)
    {
      Gate.StaticView = StarDust.Content.Load<Texture2D>("Unit\\Gate");
    }
  }
}
