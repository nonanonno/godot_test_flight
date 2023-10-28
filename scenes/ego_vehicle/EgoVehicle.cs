using Godot;
using System;

public partial class EgoVehicle : Area2D
{
    [Export]
    public float Speed { get; set; } = 400;

    [Export]
    public float RotationRate { get; set; } = 1;

    public Vector2 ScreenSize;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
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
        Rotation += RotationRate * rotation * (float)delta;
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized();
            velocity = velocity.Rotated(Rotation);
            Position += velocity * Speed * (float)delta;
        }
    }
}