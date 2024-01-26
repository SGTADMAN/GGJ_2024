using Godot;
using System;

public partial class DropZone : Area3D
{
	public enum DropObjects { Cube}
	[Export]
	public float dropTime { get; set; } = 3f;
    bool playerIn;
    float timer;
    [Export]
    public Node3D spawnPoint { get; set; }

    public override void _Ready()
    {
        timer = dropTime;
    }

    public void BodyEntered(Node3D body)
	{
		if (body.Name.ToString().Contains("Player"))
		{
            GD.Print(body.Name.ToString() + " Entered Dropzone");
            playerIn =true;

        }
	}
    public void BodyExited(Node3D body)
    {
        if (body.Name.ToString().Contains("Player"))
        {
            GD.Print(body.Name.ToString() + " Exited Dropzone");
            playerIn =false;
            timer = dropTime;
        }
    }
    public override void _Process(double delta)
    {
        if (playerIn)
        {
            timer -= (float)delta;
        }
        if (timer <= 0)
        {            
            RandomNumberGenerator rng = new RandomNumberGenerator();
            int no = rng.RandiRange(0, Enum.GetNames(typeof(DropObjects)).Length-1);
            var model_string = "res://Game Objects/Dropzone/" + (DropObjects)no + ".tscn";
            
            RigidBody3D obj = (RigidBody3D)GD.Load<PackedScene>(model_string).Instantiate();
            obj.Position = spawnPoint.Position;
            AddChild(obj);
            GD.Print("Spawning " + obj.Name.ToString() + " @ Position: " + obj.Position.ToString());
            timer = dropTime;
        }
    }
}
