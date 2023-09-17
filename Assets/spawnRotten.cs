using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRotten : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]GameObject trash;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject!=null)
        {
            Transform tr = GameObject.Find("Igrac").transform;
            GameObject.Instantiate(trash,tr.position-tr.up,Quaternion.Euler(0,0,0));
            Destroy(col.gameObject);
        }
        
    }
}
