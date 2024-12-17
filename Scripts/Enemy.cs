using Godot;
using System;

public partial class Enemy : Node2D
{
	[Export] public float speed = 0;
	public Node2D aiToFollow;
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Vector2 vector2 = GlobalPosition.MoveToward(aiToFollow.Position, (float)(speed * delta));
		GlobalPosition = vector2;

	}
}
