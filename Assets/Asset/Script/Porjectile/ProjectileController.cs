using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f; 
    public float lifeTime = 3f; 

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
       
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
