using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomeranjeAsteroida : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float sila;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 pozicija = new Vector2(rb.transform.position.x, rb.transform.position.y);
        Vector2 smerDoCentra = new Vector2(Random.Range(0f, -25f), Random.Range(10f, -10f)) - pozicija;
        rb.AddForce(smerDoCentra * sila, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(rb.position.y > 28 || rb.position.y < -29 || rb.position.x > 16 || rb.position.x < -46)
        {
            Destroy(gameObject);
        }
    }
}
