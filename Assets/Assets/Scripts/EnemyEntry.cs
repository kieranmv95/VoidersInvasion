using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntry : MonoBehaviour
{
    private Vector2 _targetPosition;
    public float speed = 5.0f;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    public void StartMoving(Vector2 destination)
    {
        _targetPosition = destination;
        isMoving = true;
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);

        if (Vector2.Distance(transform.position, _targetPosition) < 0.001f)
        {
            isMoving = false;
            TriggerChildrenShooting();
        }
    }

    private void TriggerChildrenShooting()
    {
        foreach (Transform child in transform)
        {
            Enemy enemyScript = child.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                enemyScript.StartShooting();
            }
        }
    }
}
