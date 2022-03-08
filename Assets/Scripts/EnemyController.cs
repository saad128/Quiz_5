using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody enemyRb;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        enemyRb.rotation = Quaternion.Euler(0f,targetAngle,0f);
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveEnemies(movement);
    }

    void MoveEnemies(Vector3 direction)
    {
        enemyRb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
