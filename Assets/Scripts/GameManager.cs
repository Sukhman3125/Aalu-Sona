using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Prefabs prefabs;

    [Header("Parents")]
    public Transform bulletParent;
    public Transform instansiatedAmmoParent;

    [Header("BulletSettings")]
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 3f;
    public float shootingCooldownTime = 0.5f;
    public int maxAmmo = 10;

    [Header("AmmoSpawnSettings")]
    public float ammo_SpawnRadius = 5f;
    public float ammo_minSpawnTime = 3f;
    public float ammo_maxSpawnTime = 10f;
    public float ammo_despawnDistance = 10f;
    public int ammo_maxInstansiatedAmmo = 10;

    [Space]
    public float ammo_maxScale = 1.4f;
    public float ammo_cycleTime = 1f;

}
