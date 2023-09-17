using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodavanjeRezultata : MonoBehaviour
{
    private TMPro.TextMeshProUGUI txtRezultat;

    // Start is called before the first frame update
    void Start()
    {
        txtRezultat = GetComponent<TMPro.TextMeshProUGUI>();
        txtRezultat.text = "Score: " + PlayerPrefs.GetInt("ordersTaken").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
