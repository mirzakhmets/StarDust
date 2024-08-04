
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarDust.Cells;
using StarDust.Units;

namespace StarDust
{
  public class StarDust : Game
  {
    public GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;

    public Map Map;

    public Player User;

    public Player Computer;

    public StarDust()
    {
      this.graphics = new GraphicsDeviceManager((Game) this);
      this.Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
      this.IsMouseVisible = true;
      base.Initialize();
    }

    protected override void LoadContent()
    {
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
      CellDust.LoadContent(this);
      CellSpace.LoadContent(this);
      CellFerrum.LoadContent(this);
      CellPlate.LoadContent(this);
      Artifact.LoadContent(this);
      Autogun.LoadContent(this);
      Gate.LoadContent(this);
      Soldier.LoadContent(this);
      Worker.LoadContent(this);
      Unit.LoadContent(this);
      this.Map = new Map(this, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight, 32);
      this.User = (Player) new Players.User(this.Map);
      this.Computer = (Player) new Players.Computer(this.Map);
    }

    protected override void UnloadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        this.Exit();
      if (this.User.Lost() || this.Computer.Lost())
        return;
      MouseState state1 = Mouse.GetState(this.Window);
      KeyboardState state2 = Keyboard.GetState();
      int index1 = state1.Y / this.Map.CellSize;
      int index2 = state1.X / this.Map.CellSize;
      if (state1.LeftButton == ButtonState.Pressed)
      {
        foreach (Unit unit in this.Map.Cells[index1, index2].Units.Values)
        {
          if (unit.Player == this.User)
            unit.Select();
        }
        base.Update(gameTime);
      }
      else
      {
        if (state1.RightButton == ButtonState.Pressed)
        {
          foreach (Unit unit in this.User.SelectedUnits.Values)
          {
            unit.TargetCellCol = index2;
            unit.TargetCellRow = index1;
          }
        }
        foreach (Unit unit in this.User.Units.Values)
          unit.Move(gameTime.ElapsedGameTime.Milliseconds);
        foreach (Unit unit in this.Computer.Units.Values)
          unit.Move(gameTime.ElapsedGameTime.Milliseconds);
        foreach (Unit unit in this.User.SelectedUnits.Values)
        {
          if (unit.Type() == UnitType.GATE)
          {
            if (state2.IsKeyDown(Keys.W) && unit.Col + 1 < this.Map.CellColCount && this.Map.Cells[unit.Row, unit.Col + 1].IsEmpty() && this.User.Deposited >= Worker.Cost)
            {
              Worker worker = new Worker(this.User, unit.Row, unit.Col + 1);
              this.User.Deposited -= Worker.Cost;
              break;
            }
            if (state2.IsKeyDown(Keys.A) && unit.Col + 1 < this.Map.CellColCount && this.Map.Cells[unit.Row, unit.Col + 1].IsEmpty() && this.User.Deposited >= Autogun.Cost)
            {
              Autogun autogun = new Autogun(this.User, unit.Row, unit.Col + 1);
              this.User.Deposited -= Autogun.Cost;
              break;
            }
            if (state2.IsKeyDown(Keys.S) && unit.Col + 1 < this.Map.CellColCount && this.Map.Cells[unit.Row, unit.Col + 1].IsEmpty() && this.User.Deposited >= Soldier.Cost)
            {
              Soldier soldier = new Soldier(this.User, unit.Row, unit.Col + 1);
              this.User.Deposited -= Soldier.Cost;
              break;
            }
          }
        }
        base.Update(gameTime);
      }
    }

    protected override void Draw(GameTime gameTime)
    {
      this.GraphicsDevice.Clear(Color.Black);
      this.spriteBatch.Begin();
      SpriteFont spriteFont = this.Content.Load<SpriteFont>("Arial");
      if (this.User.Lost())
        this.spriteBatch.DrawString(spriteFont, "YOU LOST", new Vector2(100f, 100f), Color.White);
      else if (this.Computer.Lost())
        this.spriteBatch.DrawString(spriteFont, "YOU WON", new Vector2(100f, 100f), Color.Red);
      else
        this.Map.Draw();
      this.spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
