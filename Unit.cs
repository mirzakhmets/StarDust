
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StarDust
{
  public class Unit
  {
    public static Texture2D SelectedView;
    public static int UnitsCurrentId;

    public Texture2D View;

    public int Row = -1;

    public int Col = -1;

    public int HealthPoints = 100;

    public float Speed = 1f;

    public int UnitId = -1;

    public Player Player;

    public Cell Cell;

    public int TargetCellRow = -1;

    public int TargetCellCol = -1;

    public int LastTime = -1;

    public double Radius = -1.0;

    public int Damage = -1;

    public virtual UnitPositionType Position() {
    	return UnitPositionType.GROUND;
    }

    public virtual UnitType Type() {
    	return UnitType.EMPTY;
    }

    public virtual bool Moveable() {
    	return true;
    }

    public Unit(Player Player, int Row, int Col)
    {
      this.Player = Player;
      this.UnitId = Unit.UnitsCurrentId++;
      this.Row = Row;
      this.Col = Col;
      this.Player.Units.Add(this.UnitId, this);
      this.Player.Map.Cells[Row, Col].Units.Add(this.UnitId, this);
    }

    public virtual bool IsSelected() {
    	return this.Player.SelectedUnits.ContainsKey(this.UnitId);
    }

    public void Select()
    {
      if (this.IsSelected())
        this.Player.SelectedUnits.Remove(this.UnitId);
      else
        this.Player.SelectedUnits.Add(this.UnitId, this);
    }

    public virtual void Move(int NewTime)
    {
      int lastTime = this.LastTime;
      this.LastTime = NewTime;
      if (!this.Moveable())
        return;
      double num1 = 0.0;
      if (this.TargetCellCol == -1 || this.TargetCellRow == -1)
        return;
      if (lastTime != -1)
        num1 = Math.Round((double) (NewTime - lastTime) * (double) this.Speed / 1000000.0);
      double num2 = 0.0;
      while (this.Row != this.TargetCellRow || this.Col != this.TargetCellCol)
      {
        int num3 = Utils.Sign(this.TargetCellRow - this.Row);
        int num4 = Utils.Sign(this.TargetCellCol - this.Col);
        int index1 = this.Row + num3;
        int index2 = this.Col + num4;
        if (index1 < 0 || index1 >= this.Player.Map.CellRowCount || index2 < 0 || index2 >= this.Player.Map.CellColCount || !this.Player.Map.Cells[index1, index2].MoveableTo() || !this.Player.Map.Cells[index1, index2].IsEmpty())
          return;
        this.Player.Map.Cells[this.Row, this.Col].Units.Remove(this.UnitId);
        this.Row = index1;
        this.Col = index2;
        this.Player.Map.Cells[this.Row, this.Col].Units.Add(this.UnitId, this);
        num2 += Math.Sqrt((double) (num3 * num3 + num4 * num4));
        if (num2 > num1)
          return;
      }
      this.TargetCellCol = this.TargetCellRow = -1;
    }

    public static void LoadContent(StarDust StarDust)
    {
      Unit.SelectedView = StarDust.Content.Load<Texture2D>("Unit\\Selected");
    }
  }
}
