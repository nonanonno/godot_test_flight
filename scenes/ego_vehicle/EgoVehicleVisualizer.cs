using Godot;
using System;

[Tool]
public partial class EgoVehicleVisualizer : Node2D
{
    private float _radius = 10;
    private Color _color = Colors.Green;

    private float _width = -1;

    [Export]
    public float Radius
    {
        get => _radius;
        set
        {
            _radius = value;
            QueueRedraw();
        }
    }

    [Export]
    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            QueueRedraw();
        }
    }

    [Export]
    public float Width
    {
        get => _width;
        set
        {
            _width = value;
            QueueRedraw();
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _Draw()
    {
        DrawArc(Vector2.Zero, Radius, 0, 360, 60, Color, Width);
        DrawLine(Vector2.Zero, new Vector2(Radius, 0), Color, Width);
    }
}
