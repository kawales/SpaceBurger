using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signBlinkScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blinkS());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator blinkS()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled=true;
        StartCoroutine(blinkS());

    }
}
