using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export] float downTime = 0;
	[Export] PackedScene mob;
	[Export] Node2D aiToFollow;
	[Export] float speed = 1;
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
		if (spawnTimer.TimeLeft == 0) {
			SpawnMob();
			spawnTimer.Start(downTime);
		}
	}
	void SpawnMob() {
		Enemy enemy = mob.Instantiate<Enemy>();
		enemy.aiToFollow = aiToFollow;
		enemy.speed = speed;
		AddChild(enemy);
	}
}
