using Godot;
using System;
using System.Collections;
using System.Threading.Tasks;

public partial class Arena_Pit : Node3D
{
    [Export]
    public MeshInstance3D pitLid { get; set; }
    [Export]
    public float loweringSpeed { get; set; } = 10f;
    [Export]
    public AudioStreamPlayer3D alarmSound { get; set; }
    bool lowered= false;


    public void OnPitEntered(Node3D body)
    {
        //Decrease player health to 0
        player playerScript = body as player;
        playerScript.playerHealth = 0;
    }

    public async void LowerLid(Node3D body)
    {
        if (!lowered)
        {
            alarmSound.Play();
            while (pitLid.Position.Y > -2.5f)
            {
                pitLid.Position -= new Vector3(0, loweringSpeed * (float)GetPhysicsProcessDeltaTime(), 0);
                await Task.Delay(10);
            }
            pitLid.Position = new Vector3(0, -2.5f, 0);
            lowered = true;
        }
    }
}
