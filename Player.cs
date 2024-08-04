
using Microsoft.Xna.Framework;
using StarDust.Units;
using System.Collections.Generic;

namespace StarDust
{
  public class Player
  {
    public static int CurrentPlayerId;

    public Map Map;

    public Dictionary<int, Unit> Units = new Dictionary<int, Unit>();

    public Dictionary<int, Unit> SelectedUnits = new Dictionary<int, Unit>();

    public int PlayerId = -1;

    public Color Color = new Color(Utils.RandomNumber(256), Utils.RandomNumber(256), Utils.RandomNumber(256));

    public Unit Artifact;

    public int Deposited;

    public Player(Map Map)
    {
      this.Map = Map;
      this.PlayerId = Player.CurrentPlayerId++;
      this.Map.Players.Add(this.PlayerId, this);
    }

    public virtual PlayerType Type() {
    	return PlayerType.EMPTY;
    }

    public virtual void Step()
    {
    }

    public bool Lost()
    {
      if (this.Artifact.HealthPoints <= 0)
        return true;
      int deposited = this.Deposited;
      int num1 = 0;
      int num2 = 0;
      for (int index1 = 0; index1 < this.Map.CellRowCount; ++index1)
      {
        for (int index2 = 0; index2 < this.Map.CellColCount; ++index2)
        {
          foreach (Unit unit in this.Map.Cells[index1, index2].Units.Values)
          {
            if (unit.Type() == UnitType.WORKER && unit.Player == this)
              ++num1;
            if ((unit.Type() == UnitType.AUTOGUN || unit.Type() == UnitType.SOLDIER) && unit.Player == this)
              ++num2;
          }
        }
      }
      return deposited < Worker.Cost && num1 == 0 && num2 == 0;
    }
  }
}
