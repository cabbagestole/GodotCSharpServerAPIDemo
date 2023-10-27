using Godot;
using System;

public partial class SpriteCS : Sprite2D
{
	
	public Vector2 velocity = Vector2.Zero;

	public override void _Process(double delta)
	{
		Position += velocity * (float)delta;
		if (Position.X < 0.0){
			velocity.X = -velocity.X;
		}else if(Position.X > 1280.0){
			velocity.X = -velocity.X;
		}
		if(Position.Y < 0.0){
			velocity.Y = -velocity.Y;
		}else if(Position.Y > 720.0){
			velocity.Y = -velocity.Y;
		}
	}
	
}
