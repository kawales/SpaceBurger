using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserKaPlaneti : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] GameObject Igrac;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, new Vector3(Igrac.transform.position.x, Igrac.transform.position.y, Igrac.transform.position.z));
        lr.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
}
