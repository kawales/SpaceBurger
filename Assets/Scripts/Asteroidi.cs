using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidi : MonoBehaviour
{
    public GameObject asteroidi;
    private GameObject noviAsteroid;
    private float randomXpozicija;
    private float randomYpozicija;
    private Vector2 pozicija;
    public float brzina = 2;
    [SerializeField]
    private float brzinaPojavljivanja;
    [SerializeField]
    private float jacinaSile;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(30);
        while (true)
        {
            yield return new WaitForSeconds(brzinaPojavljivanja);
            float nasumicnaStranica = Random.Range(10f, -10f);
            if (Mathf.RoundToInt(nasumicnaStranica) % 4 == 0)
            {
                pozicija = new Vector2(Random.Range(3f, -32f), -25f);
                noviAsteroid = Instantiate(asteroidi, pozicija, Quaternion.identity);
                
            } else if (Mathf.RoundToInt(nasumicnaStranica) % 4 == 1)
            {
                pozicija = new Vector2(Random.Range(3f, -32f), 22f);
                noviAsteroid = Instantiate(asteroidi, pozicija, Quaternion.identity);
            } else if(Mathf.RoundToInt(nasumicnaStranica) % 4 == 2)
            {
                pozicija = new Vector2(-40f, Random.Range(17.6f, -18f));
                noviAsteroid = Instantiate(asteroidi, pozicija, Quaternion.identity);
            } else
            {
                pozicija = new Vector2(10f, Random.Range(17.6f, -18f));
                noviAsteroid = Instantiate(asteroidi, pozicija, Quaternion.identity);
            }
            brzinaPojavljivanja -= 0.1f;
            if(brzinaPojavljivanja < 2)
            {
                brzinaPojavljivanja = 2;
            }
        }
        
    }

}
