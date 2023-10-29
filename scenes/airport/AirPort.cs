using Godot;
using System;
using System.Collections.Generic;

public partial class AirPort : Area2D
{


	[Export]
	public Label Label { get; set; } = null;

	private HashSet<Node2D> _controls = new HashSet<Node2D>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnAreaEntered(Area2D area)
	{
		if (area is Node2D node)
		{
			_controls.Add(node);
		}
		if (Label != null)
		{
			var text = "Controlling:\n";
			foreach (var c in _controls)
			{
				text += c.Name + "\n";
			}
			Label.Text = text;
		}
	}

	public void OnAreaExited(Area2D area)
	{
		if (area is Node2D node)
		{
			_controls.Remove(node);
		}
		if (Label != null)
		{
			var text = "";
			foreach (var c in _controls)
			{
				text += c.Name + "\n";
			}
			Label.Text = text;
		}
	}
}
