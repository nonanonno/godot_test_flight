using Godot;

public class Drawer
{
    public static void Draw(Godot.CanvasItem canvasItem, float radius, Godot.Color color, float width)
    {
        canvasItem.DrawArc(Vector2.Zero, radius, 0, 360, 60, color, width);
        canvasItem.DrawLine(Vector2.Zero, new Vector2(radius, 0), color, width);
    }
}
