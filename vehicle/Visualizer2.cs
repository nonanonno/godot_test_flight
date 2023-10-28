using Godot;
using System;


[Tool]
public partial class Visualizer2 : Node2D
{

    private float _radius = 10;
    private Color _my_color = Colors.Red;

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
        get => _my_color;
        set
        {
            _my_color = value;
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
        Drawer.Draw(this, Radius, Color, Width);
    }
}
