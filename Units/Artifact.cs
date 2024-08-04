
using Microsoft.Xna.Framework.Graphics;

namespace StarDust.Units
{
  public class Artifact : Unit
  {
    public static Texture2D StaticView;

    public Artifact(Player Player, int Row, int Col)
      : base(Player, Row, Col)
    {
      this.View = Artifact.StaticView;
      this.HealthPoints = 1000;
    }

    public override UnitType Type() {
    	return UnitType.ARTIFACT;
    }

    public override bool Moveable() {
    	return false;
    }

    public new static void LoadContent(StarDust StarDust)
    {
      Artifact.StaticView = StarDust.Content.Load<Texture2D>("Unit\\Artifact");
    }
  }
}
