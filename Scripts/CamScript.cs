using Godot;
using System;

public partial class CamScript : Camera3D
{
	[Export]
	public Node3D[] players;
	[Export]
	public float minFOV { get; set; } = 60f;
	[Export]
	public float maxFOV { get; set; } = 120f;
	Vector3 midPoint;
	float playerDist;
	[Export]
	public float minDist { get; set; } = 2f;
    [Export]
    public float maxDist { get; set; } = 40f;
    public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{
		midPoint = (players[0].Position + players[1].Position) * 0.5f;
		midPoint.Y = 0f;
		LookAt(midPoint);

        //playerDist = players[1].Position.DistanceTo(players[0].Position);
		Vector2 player1Unprojected = UnprojectPosition(players[0].Position);
        Vector2 player2Unprojected = UnprojectPosition(players[1].Position);
		playerDist = player1Unprojected.DistanceTo(player2Unprojected);
        float distanceRange = maxDist - minDist;
		float fovRange = maxFOV - minFOV;
        Fov = Mathf.Clamp(Mathf.Lerp(Fov, minFOV + (fovRange * (playerDist / distanceRange)), 10f * (float)delta), minFOV, maxFOV);

    }
}
