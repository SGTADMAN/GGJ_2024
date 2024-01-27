using Godot;
using System;
using System.Linq;

public partial class player : VehicleBody3D
{
    [Export]
    public int playerNo { get; set; }
    [Export]
    public float speed { get; set; } = 200;
    [Export]
    public float turnSpeed { get; set; } = 20;
    public enum modelType {CheeseWheel, toilet, RiggedDude, cardboard_box}
    public enum weaponType {Knife, Rake}
    [Export]
    public modelType model { get; set; }
    [Export]
    public weaponType weapon { get; set; }

    public float playerHealth = 100f;
    Node3D weaponsContainer;

    public void SetupModelAndWeapon(int inBody, int inWeapon)
    {
        model = (modelType)inBody;
        weapon = (weaponType)inWeapon;
        var model_string = "res://Game Objects/" + model.ToString() + ".tscn";
        var modelObj = GD.Load<PackedScene>(model_string);        
        AddChild(modelObj.Instantiate());
        (GetChild(-1).GetChild(-1)).Reparent(this);

        for (int i = 0; i < GetChild(-2).GetNode("WeaponPlacements").GetChildCount(); i++)
        {
            GetChild(-2).GetNode("WeaponPlacements").GetChild(i).AddChild(GD.Load<PackedScene>("res://Game Objects/Weapons/"+ weapon.ToString() +".tscn").Instantiate());
        }
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

        Node3D[] cols = GetCollidingBodies().ToArray();
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].Name.ToString().Contains("Player"))
            {
                
            }                
        }
    }
}
