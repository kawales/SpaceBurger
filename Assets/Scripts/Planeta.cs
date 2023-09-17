using UnityEngine;
using System.Collections;

public class Planeta : MonoBehaviour
{
    [SerializeField] int tipPlanete;
    [SerializeField] GameObject meso;
    [SerializeField] GameObject sir;
    [SerializeField] GameObject krompir;
    [SerializeField] GameObject kupus;
    [SerializeField] SvBrod igrac;
    [SerializeField] GameObject spawner;
    bool onPlanet = false;
    
    [SerializeField]
    AudioClip[] Clips;

    [SerializeField]
    AudioSource As;
   

    void Update()
    {
        if (onPlanet && Input.GetKeyDown(KeyCode.Space))
        {
            if (tipPlanete == 1)
            {
                Instantiate(meso, spawner.transform.position, Quaternion.identity);//r
                As.clip = Clips[2];
                As.Play();
                StartCoroutine("PopAfter");
                
            }
            if (tipPlanete == 2)
            {
                Instantiate(sir, spawner.transform.position, Quaternion.identity);//y
                As.clip = Clips[0];
                As.Play();
                StartCoroutine("PopAfter");

            }
            if (tipPlanete == 3)
            {
                Instantiate(kupus, spawner.transform.position, Quaternion.identity);//g
                As.clip = Clips[1];
                As.Play();
                StartCoroutine("PopAfter");
            }
            if (tipPlanete == 4)
            {
                Instantiate(krompir, spawner.transform.position, Quaternion.identity);//b
                As.clip = Clips[3];
                As.Play();
                StartCoroutine("PopAfter");
            }
        }
    }

    IEnumerator PopAfter(){
        yield return new WaitForSeconds(1);
        As.clip = Clips[4];
        As.Play();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player") onPlanet = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player") onPlanet = false;
    }
}
