using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rottenScr : MonoBehaviour
{
    [SerializeField]Sprite rotten;
    [SerializeField]float t;
    void Start()
    {
        StartCoroutine(rot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator rot()
    {
        yield return new WaitForSeconds(t);
        GetComponent<SpriteRenderer>().sprite=rotten;
        this.name="rotten";
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject!=null)
        {
            if(col.gameObject.name=="floor")
            {
                GetComponent<SpriteRenderer>().sprite=rotten;
                this.name="rotten";
            }
        }
    }
}
