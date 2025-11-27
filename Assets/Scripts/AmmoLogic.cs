using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLogic : Singleton<AmmoLogic>
{
    public int ammo = 0;

    private List<GameObject> ammoList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(AmmoSpawner());
    }

    private void Update()
    {
        List<GameObject> toRemove = new List<GameObject>();
        foreach (var ammo in ammoList)
        {
            if (Vector3.Distance(transform.position, ammo.transform.position) > GameManager.Instance.ammo_despawnDistance)
            {
                toRemove.Add(ammo);
            }
        }

        foreach (var ammo in toRemove)
        {
            DestroyInstansiatedAmmo(ammo);
        }
    }

    #region Ammo Spawning
    IEnumerator AmmoSpawner()
    {
        ammoList.Clear();
        while(true)
        {
            while(ammoList.Count >= GameManager.Instance.ammo_maxInstansiatedAmmo)
            {
                yield return null;
            }
            Vector2 dir = Random.insideUnitCircle.normalized; // random direction
            float radius = Random.Range(0.3f, 1f); // random distance

            Vector2 randPos = (Vector2)transform.position + dir * radius * GameManager.Instance.ammo_SpawnRadius;

            var instansiatedAmmo = Instantiate(GameManager.Instance.prefabs.InstansiatedAmmoPrefab,
                GameManager.Instance.instansiatedAmmoParent);
            ammoList.Add(instansiatedAmmo);
            Vector3 spawnPos = new Vector3(randPos.x, instansiatedAmmo.transform.position.y, randPos.y);
            instansiatedAmmo.transform.position = spawnPos;
            float randTime = Random.Range(GameManager.Instance.ammo_minSpawnTime, GameManager.Instance.ammo_maxSpawnTime);
            yield return new WaitForSeconds(randTime);
        }
    }

    private void DestroyInstansiatedAmmo(GameObject instansiatedAmmo)
    {
        ammoList.Remove(instansiatedAmmo);
        Destroy(instansiatedAmmo);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PeriodicMotion>())
        {
            if(ammo< GameManager.Instance.maxAmmo)
            {
                ammo += 1;
                DestroyInstansiatedAmmo(other.gameObject);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GameManager.Instance.ammo_SpawnRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, GameManager.Instance.ammo_despawnDistance);
    }

}
