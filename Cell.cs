
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace StarDust
{
  public class Cell
  {
    public static int CellSelectionSize = 3;

    public int Row = -1;

    public int Col = -1;

    public int Width = -1;

    public int Height = -1;

    public Map Map;

    public Texture2D View;

    public Dictionary<int, Unit> Units = new Dictionary<int, Unit>();

    public virtual CellType Type() {
    	return CellType.EMPTY;
    }

    public Cell(Map Map, int Row, int Col)
    {
      this.Map = Map;
      this.Height = this.Map.CellSize;
      this.Width = this.Height;
      this.Row = Row;
      this.Col = Col;
    }

    public int PositionX() {
    	return this.Width * this.Col;
    }

    public int PositionY() {
    	return this.Height * this.Row;
    }

    public virtual void Draw()
    {
      if (this.View != null)
        this.Map.StarDust.spriteBatch.Draw(this.View, new Rectangle(this.PositionX(), this.PositionY(), this.Width, this.Height), Color.White);
      foreach (Unit unit in this.Units.Values)
      {
        if (unit.IsSelected() && Unit.SelectedView != null)
          this.Map.StarDust.spriteBatch.Draw(Unit.SelectedView, new Rectangle(this.PositionX(), this.PositionY(), this.Width, this.Height), Color.White);
        if (unit.View != null)
          this.Map.StarDust.spriteBatch.Draw(unit.View, new Rectangle(this.PositionX() + Cell.CellSelectionSize, this.PositionY() + Cell.CellSelectionSize, this.Width - 2 * Cell.CellSelectionSize, this.Height - 2 * Cell.CellSelectionSize), Color.White);
      }
    }

    public virtual bool MoveableTo() {
    	return false;
    }

    public bool IsEmpty() {
    	return this.Units.Count == 0;
    }
  }
}
