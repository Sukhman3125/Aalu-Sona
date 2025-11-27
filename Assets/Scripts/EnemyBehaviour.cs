using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyType myEnemyType;

    public void enemyInit(EnemyType enemyType)
    {
        myEnemyType = enemyType;
    }

    private void FixedUpdate()
    {
        Transform player = Movement.Instance.transform;

        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);

        transform.Translate(Vector3.forward * EnemyManager.Instance.enemySpeed * Time.fixedDeltaTime);
    }
}
