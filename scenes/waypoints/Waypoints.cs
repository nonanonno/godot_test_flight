using Godot;
using System;
using System.Drawing;

[Tool]
public partial class Waypoints : Path2D
{
    [Export]
    public Node2D Target { get; set; } = null;

    [Export]
    public PackedScene WayPointScene { get; set; } = null;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        for (int i = 0; i < Curve.PointCount; i++)
        {
            var wp = WayPointScene.Instantiate() as Node2D;
            wp.Position = Curve.GetPointPosition(i);
            wp.Name = $"WayPoint{i}";
            AddChild(wp);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _Draw()
    {
        for (int i = 0; i < Curve.PointCount - 1; i++)
        {
            DrawLine(Curve.GetPointPosition(i), Curve.GetPointPosition(i + 1), Colors.Aqua, 2);
        }
    }

}
