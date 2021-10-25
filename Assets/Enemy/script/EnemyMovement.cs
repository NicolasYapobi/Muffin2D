using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = false;
    }

    private void Update() {
        if (facingRight) {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;   
        } else {
            transform.position += new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            facingRight = !facingRight;
            // if (facingRight == true) {
            //     facingRight = false;
            // } else {
            //     facingRight = true;
            // }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            facingRight = !facingRight;
            // if (facingRight == true) {
            //     facingRight = false;
            // } else {
            //     facingRight = true;
            // }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Fall"))
        {
            Destroy(gameObject);
        }
    }
}
