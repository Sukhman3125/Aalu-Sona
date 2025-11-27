using UnityEngine;
using System.Collections;

public class ShootingHandler : Singleton<ShootingHandler>
{
    [Header("Settings")]
    public Transform shootPoint;
    private bool onCooldown = false;

    private void Update()
    {
        if (!onCooldown && Input.GetKey(KeyCode.Mouse0))
        {
            if (AmmoLogic.Instance.ammo > 0)
            {
                StartCoroutine(Cooldown());
                AmmoLogic.Instance.ammo -= 1;
                Fire();
            }
        }
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(GameManager.Instance.shootingCooldownTime);
        onCooldown = false;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(GameManager.Instance.prefabs.bulletPrefab, 
            GameManager.Instance.bulletParent);
        bullet.transform.position = shootPoint.position;   
        float rotation = Movement.Instance.transform.rotation.eulerAngles.y;
        bullet.transform.rotation = Quaternion.Euler(0,rotation,0);

    }
}
