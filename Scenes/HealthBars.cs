using Godot;
using System;

public partial class HealthBars : Control
{
    [Export]
    public Node playerContainer { get; set; }
    Node3D[] players;
    TextureProgressBar[] healthBars;
    public override void _Ready()
    {
        players = new Node3D[playerContainer.GetChildCount()];
        healthBars = new TextureProgressBar[playerContainer.GetChildCount()];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = (Node3D)playerContainer.GetChild(i);
            healthBars[i] = GetChild<TextureProgressBar>(i);
        }        
    }
    public override void _Process(double delta)
    {
        for (int i = 0;i < healthBars.Length;i++)
        {
            healthBars[i].Value = playerContainer.GetChild<player>(i).playerHealth;
        }
    }
}
