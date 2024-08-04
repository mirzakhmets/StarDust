
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarDust.Units
{
  public class Soldier : Unit
  {
    public static Texture2D StaticView = (Texture2D) null;
    public static int Cost = 75;

    public Soldier(Player Player, int Row, int Col)
      : base(Player, Row, Col)
    {
      this.View = Soldier.StaticView;
      this.HealthPoints = 80;
      this.Radius = 2.0;
      this.Damage = 2;
      this.Speed = 1.5f;
    }

    public override UnitType Type() {
    	return UnitType.SOLDIER;
    }

    public new static void LoadContent(StarDust StarDust)
    {
      Soldier.StaticView = StarDust.Content.Load<Texture2D>("Unit\\Soldier");
    }

    public override void Move(int NewTime)
    {
      bool flag = false;
      List<Unit> unitList = new List<Unit>();
      foreach (Player player in this.Player.Map.Players.Values)
      {
        if (player != this.Player)
        {
          foreach (Unit unit in player.Units.Values)
          {
            if (Math.Sqrt((double) ((unit.Row - this.Row) * (unit.Row - this.Row) + (unit.Col - this.Col) * (unit.Col - this.Col))) <= this.Radius)
            {
              unit.HealthPoints -= this.Damage;
              if (unit.HealthPoints <= 0)
                unitList.Add(unit);
              flag = true;
            }
          }
        }
      }
      if (flag)
      {
        foreach (Unit unit in unitList)
        {
          if (unit.IsSelected())
            unit.Player.SelectedUnits.Remove(unit.UnitId);
          unit.Player.Units.Remove(unit.UnitId);
          this.Player.Map.Cells[unit.Row, unit.Col].Units.Remove(unit.UnitId);
        }
      }
      else
        base.Move(NewTime);
    }
  }
}
