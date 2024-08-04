
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarDust.Cells
{
  public class CellSpace : Cell
  {
    public static List<Texture2D> StaticViews = new List<Texture2D>();

    public override CellType Type() {
    	return CellType.SPACE;
    }

    public CellSpace(Map Map, int Row, int Col)
      : base(Map, Row, Col)
    {
      this.View = CellSpace.StaticViews[Utils.RandomNumber(CellSpace.StaticViews.Count)];
    }

    public static void LoadContent(StarDust StarDust)
    {
      int num = 1;
      while (true)
      {
        try
        {
          Texture2D texture2D = StarDust.Content.Load<Texture2D>("Cell\\Space" + (object) num);
          CellSpace.StaticViews.Add(texture2D);
        }
        catch (Exception ex)
        {
          break;
        }
        ++num;
      }
    }
  }
}
