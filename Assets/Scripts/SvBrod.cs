using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SvBrod : MonoBehaviour
{

    private Rigidbody2D rbTelo;
    private float verticalniInput;
    private bool daLiRotira = false;
    private float rotiraj;
    private bool idiNapred;
    private bool idiNazad;
    [SerializeField]
    private float silaPomeranja;
    private bool nePomeraSe = false;
    private bool boosted = false;
    [SerializeField]
    GameObject boostParticle;

    [SerializeField]
    AudioClip[] Clips;
    [SerializeField]
    AudioSource As;
    
    //private float gorivo;
    //private int braunResursi, zeleniResursi, crveniResursi, zutiResursi;
    //public int brojMesa;
    //public int brojSira;
    //public int brojKrompira;
    //public int brojSalata;
    

    [SerializeField] GameObject planeta1, planeta2, planeta3, planeta4, particle;

    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        rbTelo = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            idiNapred = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            idiNazad = true;
        }
        verticalniInput = Input.GetAxis("Vertical");
        rotiraj = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            daLiRotira = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            daLiRotira=false;
        }
        if (Input.GetKeyUp(KeyCode.W)){
            nePomeraSe = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine("Boost");
        }
    }

    private void FixedUpdate()
    {

        if (idiNapred )
        {
            rbTelo.AddForce(transform.up * silaPomeranja);
            idiNapred=false;
            if(!boosted) particle.SetActive(true);
        }
        if (idiNazad )
        {
            rbTelo.AddForce(-transform.up * silaPomeranja);
            idiNazad=false;
        }
        if (daLiRotira)
        { 
            rbTelo.AddTorque(-rotiraj * 0.5f);
        }
        else
        {
            rbTelo.angularVelocity = 0;
        }

        if (nePomeraSe)
        {
            particle.SetActive(false);

           nePomeraSe=false;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Aster"))
        {
            As.clip = Clips[1];
            As.Play();
            StartCoroutine(GameObject.Find("RestaurantManager").GetComponent<RestaurantScr>().shakeCam());
            StartCoroutine("Stun");
        }
        if(collision.gameObject.tag == "Cat"){
            As.clip = Clips[2];
            As.Play();
        }
    }

    IEnumerator Stun()
    {
        silaPomeranja = 0;
        yield return new WaitForSeconds(2);
        silaPomeranja = 10;

    }

    IEnumerator Boost(){
        if(!boosted) {
            As.clip = Clips[0];
            As.Play();
            StartCoroutine("StopSound");
            boosted = true;
            boostParticle.SetActive(true);
            particle.SetActive(false);
            silaPomeranja = 40;
            yield return new WaitForSeconds(1);
            silaPomeranja = 10;
            yield return new WaitForSeconds(3);
            boosted = false;
            boostParticle.SetActive(false);
        }
    }

    IEnumerator StopSound(){
        yield return new WaitForSeconds(3);
        As.Stop();
    }

}
