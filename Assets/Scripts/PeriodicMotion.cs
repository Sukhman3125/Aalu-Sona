using UnityEngine;

public class PeriodicMotion : MonoBehaviour
{
    public float speed = 0.1f;
    public float moveDistance = 0.2f;

    private bool movingUp = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.y >= startPosition.y + moveDistance)
            movingUp = false;
        else if(transform.position.y <= startPosition.y)
            movingUp = true;
        int direction = movingUp ? 1 : -1;  

        transform.position += new Vector3(0, direction * Time.deltaTime * speed, 0);

    }
}
