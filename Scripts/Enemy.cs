using Godot;
using System;
using System.Runtime.ExceptionServices;


public partial class Enemy : Node2D
{
	[Export] public float speed = 0;
	public float HP;
	public Node2D aiToFollow;
	public float maxDistance = float.MaxValue;
	public Vector2 spawnLocation;
	public CanvasItemMaterial material;
	//public Material material = ResourcePreloader.get


    public override void _Ready()
    {
		material = GD.Load<CanvasItemMaterial>("res://Materials/Hurt.tres");
	}

    public override void _Process(double delta)
	{
		Move(delta);
	}

	

	public void Move(double delta) {
		Vector2 newLocation = GlobalPosition.MoveToward(aiToFollow.Position, (float)(speed * delta));
		float distanceToSpawn = newLocation.DistanceTo(spawnLocation);
		//GD.Print("InCircle:" + distanceToSpawn);
		if (distanceToSpawn < maxDistance) {
			GlobalPosition = newLocation;
		} else { // try to move to closest point on circle
			newLocation = spawnLocation.MoveToward(aiToFollow.Position, maxDistance);
			//GD.Print("Closest:" + newLocation.DistanceTo(spawnLocation));
			GlobalPosition = GlobalPosition.MoveToward(newLocation, (float)(speed * delta));
		}
	}
}
