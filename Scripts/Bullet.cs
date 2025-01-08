	using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export] float speed;
	[Export] float damage = 30;
	float shiftedHue = 1;
	CollisionShape2D collider;
    public override void _Ready()
    {
		BodyEntered += bulletHit;
    }


    public override void _Process(double delta)
	{

		float Xpos = (float)(speed * delta * Math.Sin((double)Rotation)); 
		float Ypos = -(float)(speed * delta *  Math.Cos((double)Rotation));
		Position += new Vector2(Xpos, Ypos);
	}

	public void bulletHit(Node2D body) {

		if (!body.GetParent().IsInGroup("Enemy")) {
			GD.Print(body.GetType());
			QueueFree();
			return;
		}
		Enemy enemy = (Enemy)body.GetParent();
		enemy.HP -= damage;
		if (enemy.HP < 0) {
			enemy.QueueFree();
		}
		ChangeHue(enemy.HP, enemy);
		QueueFree();
	}
	public void ChangeHue(float hue, Enemy enemy) {
		//enemy.material.
		//enemy.GetChild<Sprite2D>(0)
	}
}
