using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    Renderer r;
    Color defaultcolor;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>(); 
        defaultcolor = r.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("hand") || other.CompareTag("Hand")){
            r.material.SetColor("_Color",Color.blue);
        }

    }

    private void OnTriggerExit(Collider other){
         r.material.SetColor("_Color",defaultcolor);
    }
}
