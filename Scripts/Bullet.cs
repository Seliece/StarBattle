using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export] float speed;
	public override void _Process(double delta)
	{
		float Xpos = Position.X + (float)(speed * delta * Math.Sin((double)Rotation)); 
		float Ypos = Position.Y - (float)(speed * delta *  Math.Cos((double)Rotation));
		Position = new Vector2(Xpos, Ypos);
	}
}
