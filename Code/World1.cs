using System.Threading.Tasks.Dataflow;
using Godot;
using System;

public partial class World1 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		var tank = Tank.New(TankOptions.Paveken);
		AddChild(tank);
		tank.Position = new Vector2(100, 100);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
