using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerScr : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]int test=0;
    int offset;
    [SerializeField]Sprite[] currentCustomer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite=currentCustomer[test+offset];
    }

    public void changeCustomer()
    {
        offset=2*Random.Range(0,5);
    }
}
