using Godot;
using System;

public partial class WPCollision : CollisionShape2D
{
	private bool _traveled;

	private CircleShape2D _circle;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_circle = Shape as CircleShape2D;
		AddChild(new Label { Text = GetParent().Name });
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Draw()
	{
		var color = _traveled ? Colors.Green : Colors.Red;
		DrawArc(Vector2.Zero, _circle.Radius, 0, Mathf.Pi * 2, 100, color);
	}

	public void OnAreaEntered(Area2D area)
	{
		GD.Print("enter");
		_traveled = true;
		QueueRedraw();
	}
}
