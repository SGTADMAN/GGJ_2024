using Godot;
using System;

public partial class player : VehicleBody3D
{
    [Export]
    public int playerNo { get; set; }
    [Export]
    public float speed { get; set; } = 200;
    [Export]
    public float turnSpeed { get; set; } = 20;
    public enum modelType {CheeseWheel, toilet, RiggedDude, cardboard_box }
    [Export]
    public modelType model { get; set; }

    public override void _Ready()
    {
        var model_string = "res://Game Objects/" + model.ToString() + ".tscn";
        AddChild(GD.Load<PackedScene>(model_string).Instantiate());
        (GetChild(-1).GetChild(-1)).Reparent(this);
    }
    public override void _PhysicsProcess(double delta)
    {
        if (Input.GetConnectedJoypads().Count > 1)
        {
            EngineForce = (Input.GetJoyAxis(playerNo, JoyAxis.RightY)) * speed * (float)delta;
            Steering = (-Input.GetJoyAxis(playerNo, JoyAxis.LeftX)) * turnSpeed * (float)delta;
        }
        else
        {
            EngineForce = (-Input.GetAxis("p" + (playerNo + 1) + "_Backward", "p" + (playerNo + 1) + "_Forward")) * speed * (float)delta;
            Steering = (-Input.GetAxis("p" + (playerNo + 1) + "_Left", "p" + (playerNo + 1) + "_Right")) * turnSpeed * (float)delta;
        }
    }
}
