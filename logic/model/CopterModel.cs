using Godot;

class CopterModel : ModelInterface
{
    public (Vector2 pos, float angle) Update(Vector2 position, float angle, Vector2 velocity, float omega, double dt)
    {
        Vector2 next_pos = Vector2.Zero;
        float next_angle;
        if (Mathf.IsZeroApprox(omega))
        {
            next_pos.X = position.X + (velocity.X * Mathf.Cos(angle) - velocity.Y * Mathf.Sin(angle)) * (float)dt;
            next_pos.Y = position.Y + (velocity.X * Mathf.Sin(angle) + velocity.Y * Mathf.Cos(angle)) * (float)dt;
            next_angle = angle + omega * (float)dt;
        }
        else
        {
            next_pos.X = position.X + (velocity.X / omega) * (Mathf.Sin(angle + omega * (float)dt) - Mathf.Sin(angle)) + (velocity.Y / omega) * (Mathf.Cos(angle + omega * (float)dt) - Mathf.Cos(angle));
            next_pos.Y = position.Y + (velocity.X / omega) * (Mathf.Cos(angle) - Mathf.Cos(angle + omega * (float)dt)) + (velocity.Y / omega) * (Mathf.Sin(angle + omega * (float)dt) - Mathf.Sin(angle));
            next_angle = angle + omega * (float)dt;
        }
        return (next_pos, next_angle);
    }
}
