using Godot;
using System;

public partial class Tank : Node2D
{
    public static Tank New()
    {
        var Tank = GD.Load<PackedScene>("res://Scenes/Tank.tscn").Instantiate() as Tank;
        return Tank;
    }
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

        var turret = GetNode<Sprite2D>("Turret");
        var mousePos = GetGlobalMousePosition();
        var tankPos = GlobalPosition;
        var angle = mousePos.AngleToPoint(tankPos);
        turret.Rotation = angle;


    }
}
