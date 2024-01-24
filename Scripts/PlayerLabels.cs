using Godot;
using System;

public partial class PlayerLabels : Node
{
    [Export]
    public Label[] playerNames;
    [Export]
    public Node playersContainer;
    [Export]
    public Camera3D camera;

    public override void _Ready()
    {
        playerNames = new Label[playersContainer.GetChildCount()];
        for (int i = 0; i < playerNames.Length; i++)
        {
            var scene = GD.Load<PackedScene>("res://Game Objects/player_label.tscn");
            var instance = scene.Instantiate();
            playerNames[i] = (Label)instance;
            playerNames[i].Text = string.Format("Player " + (playersContainer.GetChild<player>(i).playerNo + 1));
            playerNames[i].Name = "Player" + i + "Label";
            AddChild(playerNames[i]);
        }        
    }
    public override void _Process(double delta)
    {
        for (int i = 0; i < playerNames.Length; i++)
        {
            playerNames[i].Position = camera.UnprojectPosition(playersContainer.GetChild<player>(i).Position);
        }
    }
}
