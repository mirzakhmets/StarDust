
using StarDust.Cells;
using System.Collections.Generic;

namespace StarDust
{
  public class Map
  {
    public int Width = -1;

    public int Height = -1;

    public int CellSize = -1;

    public int CellColCount = -1;

    public int CellRowCount = -1;

    public Cell[,] Cells;

    public Dictionary<int, Player> Players = new Dictionary<int, Player>();

    public int SpacePercentage = 20;

    public int FerrumPercentage = 40;

    public StarDust StarDust;

    public Map(StarDust StarDust, int Width, int Height, int CellSize)
    {
      this.StarDust = StarDust;
      this.Width = Width;
      this.Height = Height;
      this.CellSize = CellSize;
      this.CellColCount = this.Width / CellSize;
      this.CellRowCount = this.Height / CellSize;
      this.Cells = new Cell[this.CellRowCount, this.CellColCount];
      for (int Row = 0; Row < this.CellRowCount; ++Row)
      {
        for (int Col = 0; Col < this.CellColCount; ++Col)
          this.Cells[Row, Col] = Utils.RandomNumber(100) <= 100 - this.SpacePercentage ? (Cell) new CellDust(this, Row, Col) : (Utils.RandomNumber(100) <= 100 - this.FerrumPercentage ? (Cell) new CellSpace(this, Row, Col) : (Cell) new CellFerrum(this, Row, Col));
      }
      this.Cells[0, 0] = (Cell) new CellDust(this, 0, 0);
      this.Cells[0, 1] = (Cell) new CellDust(this, 0, 1);
      this.Cells[1, 0] = (Cell) new CellDust(this, 1, 0);
      this.Cells[1, 1] = (Cell) new CellDust(this, 1, 1);
      this.Cells[this.CellRowCount - 1, this.CellColCount - 1] = (Cell) new CellDust(this, this.CellRowCount - 1, this.CellColCount - 1);
      this.Cells[this.CellRowCount - 1, this.CellColCount - 2] = (Cell) new CellDust(this, this.CellRowCount - 1, this.CellColCount - 2);
      this.Cells[this.CellRowCount - 2, this.CellColCount - 1] = (Cell) new CellDust(this, this.CellRowCount - 2, this.CellColCount - 1);
      this.Cells[this.CellRowCount - 2, this.CellColCount - 2] = (Cell) new CellDust(this, this.CellRowCount - 2, this.CellColCount - 2);
    }

    public virtual void Draw()
    {
      for (int index1 = 0; index1 < this.CellRowCount; ++index1)
      {
        for (int index2 = 0; index2 < this.CellColCount; ++index2)
          this.Cells[index1, index2].Draw();
      }
    }
  }
}
