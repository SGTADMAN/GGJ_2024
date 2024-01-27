using Godot;
using System;

public partial class DropzoneItem : RigidBody3D
{
    [Export]
    public float damageAmount { get; set; }
    public void BodyEntered(Node3D body)
    {
        if (body.Name.ToString().Contains("Player"))
        {
            Vector3 dir = body.Transform.Basis.Y.Normalized();
            float dotProd = dir.Dot((Position - body.Position).Normalized());
            GD.Print(dotProd);
            if (dotProd > 0.08f)
            {
                player playerScript = body as player;
                playerScript.playerHealth -= damageAmount;
            }            
        }
    }
}
