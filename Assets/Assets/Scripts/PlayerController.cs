using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 6.5f;
    private float _canFire, _fireRate = 0.25f;
    private Animator animator;
    private float lastHorizontalInput = 0;
    
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetButton("Fire1") && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        float currentX = transform.position.x;
        float currentY = transform.position.y;

        AnimatePlayer(horizontalInput);
        
        if(currentX < -2.423f)
        {
            transform.position = new Vector3(-2.423f, currentY, 0);
        }
        else if (currentX > 2.423f)
        {
            transform.position = new Vector3(2.423f, currentY, 0);
        }
    }

    private void AnimatePlayer(float horizontalInput)
    {

        if (horizontalInput < 0 && lastHorizontalInput >= 0)
        {
            animator.Play("Player_BL_anim");
        }
        else if (horizontalInput > 0 && lastHorizontalInput <= 0)
        {
            animator.Play("Player_BR_anim");
        }
        else if (horizontalInput == 0 && lastHorizontalInput != 0)
        {
            animator.Play("Player_anim");
        }

        lastHorizontalInput = horizontalInput;
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
    }

    void TakeDamage()
    {
        this._lives--;

        if(this._lives == 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
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
