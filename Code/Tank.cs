using System.Globalization;
using Godot;
using System;

public partial class Tank : RigidBody2D
{
    public TankOptions Type { get; private set; }
    public TankStats Stats { get; private set; }

    private static Tank New()
    {
        var Tank = GD.Load<PackedScene>("res://Scenes/Tank.tscn").Instantiate() as Tank;
        return Tank;
    }

    public static Tank New(TankOptions type)
    {
        var tank = Tank.New();
        tank.Type = type;
        tank.Stats = TankStats.Stats[type];
        return tank;
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
    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("right"))
        {
            var force = GlobalTransform.x * (float)delta * Stats.Speed;
            GD.Print($"Right: {force}");
            ApplyCentralImpulse(force);
        }
        if (Input.IsActionPressed("left"))
        {
            var force = -GlobalTransform.x * (float)delta * Stats.Speed;
            GD.Print($"Left: {force}");
            ApplyCentralImpulse(force);
        }
    }
}
