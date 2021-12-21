using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float _shotSpeed;
    Rigidbody2D _rb2b;
    // Start is called before the first frame update
    void Start()
    {
        _rb2b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb2b.velocity = new Vector2(0, _shotSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(""))
        {
            Destroy(gameObject);
        }
    }
}
