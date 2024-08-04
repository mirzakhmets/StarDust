
using Microsoft.Xna.Framework.Graphics;
using StarDust.Cells;

namespace StarDust.Units
{
  public class Worker : Unit
  {
    public static Texture2D StaticView = (Texture2D) null;
    public static int Cost = 50;

    public int Mined;

    public Worker(Player Player, int Row, int Col)
      : base(Player, Row, Col)
    {
      this.View = Worker.StaticView;
      this.HealthPoints = 50;
      this.Speed = 1f;
    }

    public override UnitType Type() {
    	return UnitType.WORKER;
    }

    public override void Move(int NewTime)
    {
      base.Move(NewTime);
      for (int index1 = -1; index1 <= 1; ++index1)
      {
        for (int index2 = -1; index2 <= 1; ++index2)
        {
          int Row = this.Row + index1;
          int Col = this.Col + index2;
          if ((index1 != 0 || index2 != 0) && Row >= 0 && Row < this.Player.Map.CellRowCount && Col >= 0 && Col < this.Player.Map.CellColCount)
          {
            foreach (Unit unit in this.Player.Map.Cells[Row, Col].Units.Values)
            {
              if (unit.Type() == UnitType.GATE)
              {
                this.Player.Deposited += this.Mined;
                this.Mined = 0;
              }
            }
            if (this.Player.Map.Cells[Row, Col].Type() == CellType.FERRUM)
            {
              this.Mined += ((CellFerrum) this.Player.Map.Cells[Row, Col]).Resources;
              ((CellFerrum) this.Player.Map.Cells[Row, Col]).Resources = 0;
              this.Player.Map.Cells[Row, Col] = (Cell) new CellDust(this.Player.Map, Row, Col);
            }
          }
        }
      }
    }

    public new static void LoadContent(StarDust StarDust)
    {
      Worker.StaticView = StarDust.Content.Load<Texture2D>("Unit\\Worker");
    }
  }
}
