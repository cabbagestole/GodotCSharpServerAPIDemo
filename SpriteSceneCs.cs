using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class SpriteSceneCs : Node2D
{
	[Export] private bool spawn = false;
	private double angle = 0.0;
	private List<SpriteCS> sprites = new List<SpriteCS>();


	//func _process(_delta: float) -> void:
	public override void _Process(double delta)
	{
		if(spawn) {
			foreach(int i in Enumerable.Range(0, 10)) {
				SpriteCS sprite = new SpriteCS();
				sprite.Texture = ResourceLoader.Load("res://icon.svg") as Texture2D;
				sprite.Scale *= (float)0.25;
				float speed = 200;
				float direction = (float)(angle + i * (Mathf.DegToRad(360)) / 10);
				sprite.Position = new Vector2(640, 360);
				sprite.velocity = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction)) * speed;
				AddChild(sprite);
				sprites.Add(sprite);
			}
			angle += Mathf.DegToRad(2);
		}
	}

	//func clear() -> void:
	public void clear()
	{
		foreach(SpriteCS sprite in sprites)
			sprite.QueueFree();
		sprites.Clear();
	}


//	func get_count() -> int:
	public int get_count()
	{
		return sprites.Count;
	}
	
}






