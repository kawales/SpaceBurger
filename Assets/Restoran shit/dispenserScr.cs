using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispenserScr : MonoBehaviour
{
    // Start is called before the first frame update
    public static int counter=1;
    [SerializeField]Color[] foodColors;
    [SerializeField] int combO;
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(counter>4)
        {
            return;
        }
        if(!Input.GetMouseButton(0) && col.gameObject.tag=="food" && counter<5)
        {
            if(col.gameObject.name.Contains("rotten"))
                return;
            /*
            if(col.gameObject.name.Contains("meat"))
            {
                GetComponent<SpriteRenderer>().color=foodColors[0];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "R");
                //RestaurantScr.order=s;
                RestaurantScr.order+="R";
            }
            else if(col.gameObject.name.Contains("salad"))
            {
                GetComponent<SpriteRenderer>().color=foodColors[1];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "G");
                //RestaurantScr.order=s;
                RestaurantScr.order+="G";
            }
            else if(col.gameObject.name.Contains("potato"))
            {
                GetComponent<SpriteRenderer>().color=foodColors[3];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "B");
                //RestaurantScr.order=s;
                RestaurantScr.order+="B";
            }
            else if(col.gameObject.name.Contains("cheese"))
            {
                GetComponent<SpriteRenderer>().color=foodColors[2];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "Y");
                //RestaurantScr.order=s;
                RestaurantScr.order+="Y";
            }
            Destroy(col.gameObject);
            
            Debug.Log(RestaurantScr.order);
            GetComponent<SpriteRenderer>().enabled=true;
            return;
            */
            GameObject current = GameObject.Find("flaskBG"+counter);
            Debug.Log(counter);
            if(col.gameObject.name.Contains("meat"))
            {
                current.GetComponent<SpriteRenderer>().color=foodColors[0];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "R");
                //RestaurantScr.order=s;
                RestaurantScr.order+="R";
            }
            else if(col.gameObject.name.Contains("salad"))
            {
                 current.GetComponent<SpriteRenderer>().color=foodColors[1];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "G");
                //RestaurantScr.order=s;
                RestaurantScr.order+="G";
            }
            else if(col.gameObject.name.Contains("potato"))
            {
                current.GetComponent<SpriteRenderer>().color=foodColors[3];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "B");
                //RestaurantScr.order=s;
                RestaurantScr.order+="B";
            }
            else if(col.gameObject.name.Contains("cheese"))
            {
                current.GetComponent<SpriteRenderer>().color=foodColors[2];
                string s = RestaurantScr.order;
                //s= s.Remove(combO, 1).Insert(combO, "Y");
                //RestaurantScr.order=s;
                RestaurantScr.order+="Y";
            }
            
            Destroy(col.gameObject);
            
            Debug.Log(RestaurantScr.order);
            current.GetComponent<SpriteRenderer>().enabled=true;
            counter++;
            return;
        }
    }
}
