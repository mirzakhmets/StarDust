
using Microsoft.Xna.Framework.Graphics;

namespace StarDust.Cells
{
  public class CellFerrum : Cell
  {
    public static Texture2D StaticView;

    public int Resources = 100;

    public override CellType Type() {
    	return CellType.FERRUM;
    }

    public CellFerrum(Map Map, int Row, int Col)
      : base(Map, Row, Col)
    {
      this.View = CellFerrum.StaticView;
    }

    public static void LoadContent(StarDust StarDust)
    {
      CellFerrum.StaticView = StarDust.Content.Load<Texture2D>("Cell\\Ferrum");
    }
  }
}
