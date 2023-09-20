using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RestaurantScr : MonoBehaviour
{
    GameObject holding;
    Vector2 camPos;
    static public string order="";
    int orderNumber=0;
    int cbCounter=-1;
    string[] cookBook={"Burger","Fries","Hotdog", "Salad", "Pancake", "Pizza"};
    string[] orderRec={"BYGR","BBY","BRG", "GG", "BYR", "YRR"};
    [SerializeField]Sprite[] foodSprites;
    [SerializeField]Sprite[] smallFoodSprites;
    
    [SerializeField] TextMeshProUGUI cbText;
    [SerializeField] TextMeshProUGUI foodTimeTxt;
    [SerializeField] TextMeshProUGUI happynessT;
    [SerializeField]GameObject bootedCat;

    bool orderGood = false;

    [SerializeField]
    float foodTime=30;

    [SerializeField]
    float maxFoodTime=30;
    int happyness=6;
    int orderCount=0;
    [SerializeField]Sprite[] customerFaces;

    [SerializeField]
    AudioClip[] Clips;

    [SerializeField]
    AudioSource As;

    Animator customerAnim;
    // Start is called before the first frame update

    private bool succeeded = false;
    void Start()
    {
        StartCoroutine(takeTimeOff());
        takeRandOrder();
        customerAnim=GameObject.Find("customer").GetComponent<Animator>();
        //customerAnim.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
                StartCoroutine(shakeCam());
        }
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider!=null)
            {
                Debug.Log(hit.collider.transform.name);
                if(hit.collider.transform.tag=="food")
                {
                    holding=hit.collider.gameObject;
                    holding.GetComponent<Collider2D>().enabled=false;
                    
                }
                else if(hit.collider.name=="nextCB")
                {
                    cbCounter++;
                    if(cbCounter>=cookBook.Length)
                        cbCounter=0;
                    Debug.Log(cookBook[cbCounter]);
                    cbText.text=cookBook[cbCounter];
                    smallRec();
                }
                else if(hit.collider.name=="prevCB")
                {
                    cbCounter--;
                    if(cbCounter<0)
                        cbCounter=cookBook.Length-1;
                    //Debug.Log(cookBook[cbCounter]);
                    cbText.text=cookBook[cbCounter];
                    smallRec();
                }
                else if(hit.collider.name=="printerReset")
                {
                    order="";
                    for(int i=1;i<=4;i++)
                    {
                        GameObject.Find("flaskBG"+i).GetComponent<SpriteRenderer>().enabled=false;
                        dispenserScr.counter=1;
                    }
                }
                else if(hit.collider.name.Contains("printer"))
                {
                    StartCoroutine(printerBtn(hit.collider.GetComponent<SpriteRenderer>()));
                    Debug.Log(order+" "+orderRec[orderNumber]);
                    if(order!="")
                        GameObject.Find("3dDispenser").GetComponent<ParticleSystem>().Play();
                    foodTime=0f;
                    if(order==orderRec[orderNumber])
                    {
                        orderGood = true;
                        if(foodTime>=2*maxFoodTime/2.0f)
                            happyness++;
                        //happyness++;
                        orderCount++;
                        if(maxFoodTime>15)
                        {
                            maxFoodTime--;
                        }
                        
                    }
                    order="";
                    for(int i=1;i<=4;i++)
                    {
                        GameObject.Find("flaskBG"+i).GetComponent<SpriteRenderer>().enabled=false;
                        dispenserScr.counter=1;
                    }
                    //takeRandOrder();
                    happynessT.text=happyness.ToString()+"  "+orderRec[orderNumber];
                    
                }
            }
                
        }
        if(Input.GetMouseButton(0) && holding!=null)
        {
            camPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            holding.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            holding.transform.position=camPos;
        }
        if(Input.GetMouseButtonUp(0) && holding!=null)
        {
            holding.GetComponent<Collider2D>().enabled=true;
            holding=null;
        }
    }
    IEnumerator takeTimeOff()
    {
        yield return new WaitForSeconds(1f);
        foodTime-=1f;
        if(foodTime<=0)
        {
          takeRandOrder();
          customerAnim.enabled=true;
          GameObject.Find("face").GetComponent<SpriteRenderer>().sprite=customerFaces[3];
          StartCoroutine(startAnim());

        }
        else if(foodTime<maxFoodTime/3.0f)
        {
            As.clip = Clips[2];
            As.Play();
            GameObject.Find("face").GetComponent<SpriteRenderer>().sprite=customerFaces[2];
        }
        else if(foodTime<2*maxFoodTime/3.0f)
        {
            GameObject.Find("face").GetComponent<SpriteRenderer>().sprite=customerFaces[1];
        }

        foodTimeTxt.text=foodTime.ToString();
        StartCoroutine(takeTimeOff());
    }

    IEnumerator printerBtn(SpriteRenderer spr)
    {
        spr.enabled=true;
        yield return new WaitForSeconds(0.1f);
        spr.enabled=false;
    }

    void takeRandOrder()
    {
        foodTime=maxFoodTime;
        if(!orderGood) {
            happyness-=1;
            As.clip = Clips[0];
            As.Play();
        }
        else if(orderGood){
            As.clip = Clips[1];
            As.Play();
        }
        orderGood = false;
        happynessT.text=happyness.ToString()+"  "+orderRec[orderNumber];
        orderNumber=Random.Range(0,orderRec.Length);
        GameObject.Find("foodWanted").GetComponent<SpriteRenderer>().sprite=foodSprites[orderNumber];
        GameObject.Find("Zvezda").GetComponent<SpriteRenderer>().size=new Vector2((happyness/2.0f),0.43f);
        if(happyness<=0)
        {
            PlayerPrefs.SetInt("ordersTaken",orderCount);
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
    }
    public IEnumerator shakeCam()
    {
        for(int i=0;i<5;i++)
        {
            Vector2 randDir = Random.insideUnitCircle.normalized;
            transform.Translate(randDir*0.08f);
            yield return new WaitForSeconds(0.2f);
            transform.Translate(-randDir*0.08f);
        }

    }

    IEnumerator startAnim()
    {
        customerAnim.SetBool("done",true);
        yield return new WaitForSeconds(0.1f);
        customerAnim.SetBool("done",false);
        yield return new WaitForSeconds(1.1f);
        GameObject.Find("face").GetComponent<SpriteRenderer>().sprite=customerFaces[0];
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("customer").GetComponent<customerScr>().changeCustomer();
        Transform tr = GameObject.Find("Igrac").transform;
        GameObject.Instantiate(bootedCat,tr.position-tr.up,Quaternion.Euler(0,0,0));
    }

    void smallRec() // pretvara kombinacije u recept
    {
        Debug.Log("smallREC"+orderRec[cbCounter]);
        if(cbCounter<0)return;
        for(int i=0;i<orderRec[cbCounter].Length;i++)
        {
            if(orderRec[cbCounter][i]=='R')
            {
                GameObject.Find("small"+(i+1)).GetComponent<SpriteRenderer>().sprite=smallFoodSprites[0];
            }
            else if(orderRec[cbCounter][i]=='G')
            {
                GameObject.Find("small"+(i+1)).GetComponent<SpriteRenderer>().sprite=smallFoodSprites[1];
            }
            else if(orderRec[cbCounter][i]=='Y')
            {
                GameObject.Find("small"+(i+1)).GetComponent<SpriteRenderer>().sprite=smallFoodSprites[2];
            }
            else if(orderRec[cbCounter][i]=='B')
            {
                GameObject.Find("small"+(i+1)).GetComponent<SpriteRenderer>().sprite=smallFoodSprites[3];
            }
        }
        if(orderRec[cbCounter].Length==3)
        {
            GameObject.Find("small"+(4)).GetComponent<SpriteRenderer>().sprite=null;
        }
        else if(orderRec[cbCounter].Length==2)
        {
            GameObject.Find("small"+(3)).GetComponent<SpriteRenderer>().sprite=null;
            GameObject.Find("small"+(4)).GetComponent<SpriteRenderer>().sprite=null;
        }
    }

    
}
