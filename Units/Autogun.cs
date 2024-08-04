
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarDust.Units
{
  public class Autogun : Unit
  {
    public static Texture2D StaticView = (Texture2D) null;
    public static int Cost = 150;

    public Autogun(Player Player, int Row, int Col)
      : base(Player, Row, Col)
    {
      this.View = Autogun.StaticView;
      this.HealthPoints = 150;
      this.Radius = 6.0;
      this.Damage = 10;
      this.Speed = 2f;
    }

    public override UnitType Type() {
    	return UnitType.AUTOGUN;
    }

    public new static void LoadContent(StarDust StarDust)
    {
      Autogun.StaticView = StarDust.Content.Load<Texture2D>("Unit\\Autogun");
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
