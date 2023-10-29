using Godot;

interface ModelInterface
{
    (Vector2 pos, float angle) Update(Vector2 position, float angle, Vector2 velocity, float omega, double dt);
}
