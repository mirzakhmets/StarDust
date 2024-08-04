
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarDust.Cells
{
  public class CellDust : Cell
  {
    public static List<Texture2D> StaticViews = new List<Texture2D>();

    public override CellType Type() {
    	return CellType.DUST;
    }

    public CellDust(Map Map, int Row, int Col)
      : base(Map, Row, Col)
    {
      this.View = CellDust.StaticViews[Utils.RandomNumber(CellDust.StaticViews.Count)];
    }

    public static void LoadContent(StarDust StarDust)
    {
      int num = 1;
      while (true)
      {
        try
        {
          Texture2D texture2D = StarDust.Content.Load<Texture2D>("Cell\\Dust" + (object) num);
          CellDust.StaticViews.Add(texture2D);
        }
        catch (Exception ex)
        {
          break;
        }
        ++num;
      }
    }

    public override bool MoveableTo() {
    	return true;
    }
  }
}
