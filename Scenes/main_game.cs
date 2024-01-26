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

    public override void _Ready()
    {
        players = new player[playerContainer.GetChildCount()];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = (player)playerContainer.GetChild(i);
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
            GetTree().Paused = true;
            winScreen.Visible = true;
            playerWinText.Text = String.Format("Player {0} Wins!", list.ElementAt(0).playerNo+1);
        }
    }
}
