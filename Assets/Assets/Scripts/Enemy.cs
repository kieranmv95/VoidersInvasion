using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _laserPrefab, _explosionPrefab;

    public void StartShooting()
    {
        StartCoroutine(ShootLaser());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Laser")
        {   
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    IEnumerator ShootLaser()
    {
        while (true)
        {
            float randomTime = Random.Range(0.275f, 10f);
            yield return new WaitForSeconds(randomTime);
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position + new Vector3(0, -0.4f, 0), Quaternion.Euler(0.0f, 0.0f, 180));
            enemyLaser.GetComponent<Laser>().SetSpeed(2f);
        }
    }
}
