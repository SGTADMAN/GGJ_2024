using Godot;
using System;

public partial class HurtBox : Area3D
{
    [Export]
    public float damageAmount { get; set; } = 10f;
    [Export]
    public AudioStreamPlayer3D soundEffect { get; set; }
    public void BodyEntered(Node3D body)
    {
        //GD.Print("Hit: " + body.Name.ToString() + " | We are " + this.GetParent().GetParent().GetParent().GetParent().GetParent().Name.ToString());
        if (body.Name.ToString() != this.GetParent().GetParent().GetParent().GetParent().GetParent().Name.ToString())
        {
            player playerScript = body as player;
            playerScript.playerHealth -= damageAmount;
            soundEffect.Play();
        }
    }
}
