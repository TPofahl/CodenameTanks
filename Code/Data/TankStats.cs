using System.Collections.Generic;
public class TankStats
{
    public float Speed;
    public float Health;
    public float MaxHealth;
    public float FireRate;
    public float ReloadTime;
    public float BulletSpeed;
    public float BulletDamage;

    public static Dictionary<TankOptions, TankStats> Stats = new Dictionary<TankOptions, TankStats>
    {
        {TankOptions.Paveken, new TankStats
        {
            Speed = 1000,
            Health = 100,
            MaxHealth = 100,
            FireRate = 1,
            ReloadTime = 1,
            BulletSpeed = 100,
            BulletDamage = 10
        }},
        {TankOptions.Pofahler, new TankStats
        {
            Speed = 1000,
            Health = 100,
            MaxHealth = 100,
            FireRate = 1,
            ReloadTime = 1,
            BulletSpeed = 100,
            BulletDamage = 10
        }},
        {TankOptions.Smithington, new TankStats
        {
            Speed = 1000,
            Health = 100,
            MaxHealth = 100,
            FireRate = 1,
            ReloadTime = 1,
            BulletSpeed = 100,
            BulletDamage = 10
        }},
        {TankOptions.Humphrey, new TankStats
        {
            Speed = 1000,
            Health = 100,
            MaxHealth = 100,
            FireRate = 1,
            ReloadTime = 1,
            BulletSpeed = 100,
            BulletDamage = 10
        }},
        {TankOptions.Davidsman, new TankStats
        {
            Speed = 1000,
            Health = 100,
            MaxHealth = 100,
            FireRate = 1,
            ReloadTime = 1,
            BulletSpeed = 100,
            BulletDamage = 10
        }}
    };
}