using Godot;
using System;

public partial class Trajectory : Line2D
{
	[Export]
	public int Capacity { get; set; } = 100;

	[Export]
	public Node2D Target { get; set; } = null;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ClearPoints();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Target != null)
		{
			AddPoint(Target.GlobalPosition);
			if (Points.Length > Capacity)
			{
				RemovePoint(0);
			}
		}
	}

	public void Clear()
	{
		ClearPoints();
	}
}
