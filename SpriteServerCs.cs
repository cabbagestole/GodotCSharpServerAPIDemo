using Godot;
using System;
using System.Linq;
using System.Collections.Generic;


public partial class SpriteServerCs : Node2D
{
	public partial class ServerSpriteCS : RefCounted
	{
		public Rid rid;
		public Vector2 position;
		public Vector2 velocity;
	}

	[Export] private bool spawn = false;
	private double angle = 0.0;
	private Texture2D texture = ResourceLoader.Load("res://icon.svg") as Texture2D;
	private List<ServerSpriteCS> sprites = new List<ServerSpriteCS>();


	public override void _Process(double delta)
	{
		if(spawn) {
			// # Spawn phase
			foreach(int i in Enumerable.Range(0, 10)) {
// GDScript
//				var sprite = ServerSpriteGD.new()
//				sprite.rid = RenderingServer.canvas_item_create()
//				RenderingServer.canvas_item_set_parent(sprite.rid, get_canvas_item())
//				RenderingServer.canvas_item_set_draw_index(sprite.rid, len(sprites))
//				var rect = Rect2(0, 0, texture.get_width(), texture.get_height())
//				RenderingServer.canvas_item_add_texture_rect(sprite.rid, rect, texture.get_rid())
//				var speed = 200
//				var direction = angle + i * (deg_to_rad(360)) / 10
//				sprite.position = Vector2(640, 360)
//				sprite.velocity = Vector2(cos(direction), sin(direction)) * speed
//				sprites.append(sprite)

				ServerSpriteCS sprite = new ServerSpriteCS();
				sprite.rid = RenderingServer.CanvasItemCreate();
				RenderingServer.CanvasItemSetParent(sprite.rid, GetCanvasItem());
				RenderingServer.CanvasItemSetDrawIndex(sprite.rid, sprites.Count);
				Rect2 rect = new Rect2(0, 0, texture.GetWidth(), texture.GetHeight());
				RenderingServer.CanvasItemAddTextureRect(sprite.rid, rect, texture.GetRid());
				float speed = 200;
				float direction = (float)(angle + i * (Mathf.DegToRad(360)) / 10);
				sprite.position = new Vector2(640, 360);
				sprite.velocity = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction)) * speed;
				sprites.Add(sprite);
			}
			angle += Mathf.DegToRad(2);
		}
		//# Update phase

//		for sprite in sprites:
//			sprite.position += sprite.velocity * delta
//			if sprite.position.x < 0.0:
//				sprite.velocity.x = -sprite.velocity.x
//			elif sprite.position.x > 1280.0:
//				sprite.velocity.x = -sprite.velocity.x
//			if sprite.position.y < 0.0:
//				sprite.velocity.y = -sprite.velocity.y
//			elif sprite.position.y > 720.0:
//				sprite.velocity.y = -sprite.velocity.y
//
//			var sprite_transform = Transform2D(0.0, Vector2(0.25, 0.25), 0.0, sprite.position)
//			RenderingServer.canvas_item_set_transform(sprite.rid, sprite_transform)

		foreach(ServerSpriteCS sprite in sprites) {
			sprite.position += sprite.velocity * (float)delta;
			if (sprite.position.X < 0.0){
				sprite.velocity.X = -sprite.velocity.X;
			}else if(sprite.position.X > 1280.0){
				sprite.velocity.X = -sprite.velocity.X;
			}
			if(sprite.position.Y < 0.0){
				sprite.velocity.Y = -sprite.velocity.Y;
			}else if(sprite.position.Y > 720.0){
				sprite.velocity.Y = -sprite.velocity.Y;
			}
			Transform2D sprite_transform = new Transform2D((float)0, new Vector2(1, 1)*(float)0.25, (float)0, sprite.position);
			RenderingServer.CanvasItemSetTransform(sprite.rid, sprite_transform);
		}


	}

	public void clear()
	{
		foreach(ServerSpriteCS sprite in sprites)
			RenderingServer.FreeRid(sprite.rid);
		sprites.Clear();
	}


	public int get_count()
	{
		return sprites.Count;
	}



}
