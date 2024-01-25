using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 10f;

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if(transform.position.y > 5.2)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.y < -5.2)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Laser")
        {   
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
