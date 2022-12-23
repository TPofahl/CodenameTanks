using System.Globalization;
using Godot;
using System;

public partial class Tank : RigidBody2D
{
    public TankOptions Type { get; private set; }
    public TankStats Stats { get; private set; }
    public Camera2D cameraPositon;
    [Export]
    public Vector2 zoomSpeed;
    [Export]
    public Vector2 minZoom;
     [Export]
    public Vector2 maxZoom;



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
        cameraPositon = GetNode<Camera2D>("Camera2D");
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
        zoomSpeed = new Vector2(0.70F, 0.70F);
        minZoom = new Vector2(0.4F, 0.4F);
        maxZoom = new Vector2(2.50F, 2.50F);

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
        if (Input.IsActionJustReleased("scrollUp") && cameraPositon.Zoom.x <= maxZoom.x) 
        {
            GD.Print($"Scroll up: {cameraPositon.Zoom}");
            cameraPositon.Zoom += zoomSpeed;
        }
        if (Input.IsActionJustReleased("scrollDown") && cameraPositon.Zoom.x >= minZoom.x) 
        {
            GD.Print($"Scroll down: {cameraPositon.Zoom}");
            cameraPositon.Zoom -= zoomSpeed;
        }
    }
}
