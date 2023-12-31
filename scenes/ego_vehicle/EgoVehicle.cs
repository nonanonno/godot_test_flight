using Godot;
using System;

public partial class EgoVehicle : Area2D
{
    [Export]
    public float Speed { get; set; } = 400;

    [Export]
    public float RotationRate { get; set; } = 1;

    [Export]
    public Label Label { get; set; } = null;

    public Vector2 ScreenSize;

    private CopterModel _model;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
        _model = new CopterModel();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Vector2 velocity = Vector2.Zero;
        float rotation = 0;
        if (Input.IsActionPressed("move_forward"))
        {
            velocity.X += 1;
        }
        if (Input.IsActionPressed("move_back"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("move_left"))
        {
            velocity.Y -= 1;
        }
        if (Input.IsActionPressed("move_right"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("rotate_left"))
        {
            rotation -= 1;
        }
        if (Input.IsActionPressed("rotate_right"))
        {
            rotation += 1;
        }
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized();
        }
        (Position, Rotation) = _model.Update(Position, Rotation, velocity * Speed, rotation * RotationRate, delta);
    }

    public void OnAreaEntered(Area2D area)
    {
        if (Label != null)
        {
            Label.Text += "Collision\n";
        }
    }

    public void OnMarginEntered(Area2D area)
    {
        if (Label != null)
        {
            Label.Text += "incident\n";
        }
    }
}
