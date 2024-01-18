using Godot;
using System;

public partial class player : VehicleBody3D
{
    [Export]
    public int playerNo { get; set; }
    [Export]
    public Label3D label { get; set; }
    [Export]
    public float speed { get; set; } = 200;
    [Export]
    public float turnSpeed { get; set; } = 20;

    public override void _Ready()
    {
        label.Text = "Player " + (playerNo + 1);
    }
    public override void _PhysicsProcess(double delta)
    {
        EngineForce = (Input.GetJoyAxis(playerNo, JoyAxis.RightY)) * speed * (float)delta;
        Steering = (-Input.GetJoyAxis(playerNo, JoyAxis.LeftX)) * turnSpeed * (float)delta;      
    }
}
