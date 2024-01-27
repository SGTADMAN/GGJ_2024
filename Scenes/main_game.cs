using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class main_game : Node
{
    [Export]
    public Node playerContainer { get; set; }
    player[] players;
    [Export]
    public Control winScreen { get; set; }
    [Export]
    public Label playerWinText { get; set; }
    bool gameOver = false;

    public override void _Ready()
    {        
        players = new player[playerContainer.GetChildCount()];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = (player)playerContainer.GetChild(i);
            players[i].GetTree().Paused = true;
        }
    }

    public override void _Process(double delta)
    {        
        List<player> list = new List<player>();
        list.Clear();
        for (int i = 0;i < players.Length;i++)
        {
            if (players[i].playerHealth > 0)
            {
                list.Add(players[i]);
            }
        }
        if (list.Count == 1)
        {
            gameOver = true;
            GetTree().Paused = true;
            winScreen.Visible = true;
            playerWinText.Text = String.Format("Player {0} Wins!", list.ElementAt(0).playerNo+1);
        }
    }
    public override void _UnhandledInput(InputEvent @event)
    {
        if (gameOver)
        {
            if (@event.IsActionPressed("ui_accept") || Input.IsJoyButtonPressed(0,JoyButton.Start))
            {
                //Load character select
                GetTree().ReloadCurrentScene();

            }
            if (@event.IsActionPressed("ui_cancel"))
            {
                GetTree().Quit();
            }
        }
    }
    public void SetUpGame(int p1Body, int p1Weapon, int p2body, int p2Weapon)
    {
        players[0].SetupModelAndWeapon(p1Body, p1Weapon);
        players[0].GetTree().Paused = false;
        players[1].SetupModelAndWeapon(p2body, p2Weapon);
        players[1].GetTree().Paused = false;
    }
}
