
using StarDust.Units;

namespace StarDust.Players
{
  public class Computer : Player
  {
    public Computer(Map Map)
      : base(Map)
    {
      this.Artifact = (Unit) new Units.Artifact((Player) this, Map.CellRowCount - 1, Map.CellColCount - 1);
      Gate gate = new Gate((Player) this, Map.CellRowCount - 1, Map.CellColCount - 2);
      Worker worker = new Worker((Player) this, Map.CellRowCount - 2, Map.CellColCount - 1);
      int num1 = Utils.RandomNumber(10);
      int num2 = Utils.RandomNumber(20);
      for (int index = 0; index < 1000000; ++index)
      {
        int Row = Utils.RandomNumber(Map.CellRowCount / 2, Map.CellRowCount);
        int Col = Utils.RandomNumber(Map.CellColCount / 2, Map.CellColCount);
        if (Map.Cells[Row, Col].Type() == CellType.DUST && Map.Cells[Row, Col].Units.Count == 0)
        {
          if (num1 > 0)
          {
            --num1;
            Autogun autogun = new Autogun((Player) this, Row, Col);
          }
          else if (num2 > 0)
          {
            --num2;
            Soldier soldier = new Soldier((Player) this, Row, Col);
          }
        }
      }
    }

    public override PlayerType Type() {
    	return PlayerType.COMPUTER;
    }
  }
}
