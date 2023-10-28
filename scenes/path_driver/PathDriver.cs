using Godot;
using System;

public partial class PathDriver : Path2D
{
    [Export]
    public float Speed { get; set; } = 100;

    [Export]
    public bool Loop { get; set; } = true;

    [Export]
    public bool Debug { get; set; } = false;

    [Export]
    public Node2D Target { get; set; } = null;

    private PathFollow2D _follow;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _follow = GetNode<PathFollow2D>("PathFollow2D");
        _follow.Loop = Loop;
        if (Debug)
        {
            var line = new Line2D();
            line.ZIndex = -100;
            foreach (var point in Curve.GetBakedPoints())
            {
                line.AddPoint(point);
            }
            line.Width = 1;
            AddChild(line);

            var debugNode = new DebugVehicleVisualizer();
            _follow.AddChild(debugNode);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _follow.Progress += (float)(Speed * delta);
        if (Target != null)
        {
            Target.Transform = _follow.Transform;
        }
    }
}
