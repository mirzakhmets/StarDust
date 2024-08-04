
using Microsoft.Xna.Framework.Graphics;

namespace StarDust.Cells
{
  public class CellPlate : Cell
  {
    public static Texture2D StaticView;

    public override CellType Type() {
    	return CellType.PLATE;
    }

    public CellPlate(Map Map, int Row, int Col)
      : base(Map, Row, Col)
    {
      this.View = CellPlate.StaticView;
    }

    public static void LoadContent(StarDust StarDust)
    {
      CellPlate.StaticView = StarDust.Content.Load<Texture2D>("Cell\\Plate");
    }
  }
}
