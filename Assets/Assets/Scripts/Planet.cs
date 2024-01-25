using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    [SerializeField]
    private GameObject _planetDmg;

    private void TakeDamage()
    {
        _planetDmg.SetActive(true);
        _health -= 0.5f;
        StartCoroutine(ShowDamage());
    }

    private IEnumerator ShowDamage()
    {
        _planetDmg.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _planetDmg.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "EnemyLaser")
        {   
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
}
