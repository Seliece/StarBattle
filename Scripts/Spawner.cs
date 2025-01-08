using Godot;
using System;
using System.Diagnostics;

public partial class Spawner : Node2D
{
	[Export] PackedScene mob;
	[Export] Node2D aiToFollow;
	[Export] float downTime = 0;
	[Export] float speed;
	[Export] int mobLimit;
	[Export] float maxDistance;
	[Export] float startHP;
	[Export] bool debug = false;
	Timer spawnTimer;
	public override void _Ready()
	{
		spawnTimer = new Timer();
		spawnTimer.OneShot = true;
		AddChild(spawnTimer);
		spawnTimer.Start(downTime);
	}

	
	public override void _Process(double delta)
	{
		if (spawnTimer.TimeLeft == 0 && GetChildCount() <= mobLimit + 1) {
			SpawnMob();
			spawnTimer.Start(downTime);
		}
	}
	void SpawnMob() {
		Enemy enemy = mob.Instantiate<Enemy>();
		enemy.aiToFollow = aiToFollow;
		enemy.speed = speed;
		enemy.spawnLocation = Position;
		enemy.maxDistance = maxDistance;
		enemy.HP = startHP;
		AddChild(enemy);
	}

    public override void _Draw()
    {
		if (debug == true) {
			GD.Print(GlobalPosition);
        	DrawCircle(new Vector2(0,0),maxDistance,new Color(1,0,0, 0.2f));
		}
		base._Draw();
    }
}
