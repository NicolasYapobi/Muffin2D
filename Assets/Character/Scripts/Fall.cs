using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ceoko");
        if (collision.gameObject.CompareTag("Player"))
        {
		    Debug.Log("caaaaa");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("caaaaa");
            Destroy(collision.gameObject);
        }
    }

}
