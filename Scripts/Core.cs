using Godot;
using System;
using System.Runtime.InteropServices;

public partial class Core : Node2D
{
	[Export] float rotateSpeed = 0;
	[Export] float speed = 0;
	[Export] float reloadTime = 0;
	PackedScene bullet = GD.Load<PackedScene>("res://Prefabs/Bullet.tscn");
	
	Timer bulletTimer;
	
	public override void _Ready()
	{
		bulletTimer = new Timer();
		bulletTimer.OneShot = true;
		AddChild(bulletTimer);
		bulletTimer.Start(reloadTime);
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.A)) {
			RotationDegrees -= (float)(rotateSpeed * delta);
		}
		if (Input.IsKeyPressed(Key.D)) {
			RotationDegrees += (float)(rotateSpeed * delta);
		}
		if (Input.IsKeyPressed(Key.W)) {
			float Xpos = Position.X + (float)(speed * delta * Math.Sin((double)Rotation)); 
			float Ypos = Position.Y - (float)(speed * delta *  Math.Cos((double)Rotation));
			Position = new Vector2(Xpos, Ypos);
		}

		if (Input.IsKeyPressed(Key.S)) {
			float Xpos = Position.X - (float)(speed * delta * Math.Sin((double)Rotation)); 
			float Ypos = Position.Y + (float)(speed * delta *  Math.Cos((double)Rotation));
			Position = new Vector2(Xpos, Ypos);
		}
		
		if (Input.IsKeyPressed(Key.Space) && (bulletTimer.TimeLeft == 0)) {
			GD.Print("pew");
			Shoot();
		}
	}
	void Shoot() {
		Area2D instance = bullet.Instantiate<Area2D>();
		instance.Position = Position;
		instance.Rotation = Rotation;
		GetParent().AddChild(instance);

		bulletTimer.Start(reloadTime);
	}
}
