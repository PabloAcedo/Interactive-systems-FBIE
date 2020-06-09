using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchBone : MonoBehaviour
{
    public string bone;

    public Text bones;

    //public bool state;
    void Start()
    {
        bone = "adios";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("skull")){
            bone = "skull";
            bones.text = bone;
        }
    }

    private void OnTriggerExit(Collider other){

        if (other.CompareTag("skull")){
            bone = "nothing";
            bones.text = bone;
        }
    }

}
