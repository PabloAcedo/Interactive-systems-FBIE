using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchBone : MonoBehaviour
{
    public string bone;

    public Text bones;

    private bool gameMode; //para saber si el modo es el de touchbone o el de jugar(si es true, es el de jugar)

    //public bool state;
    void Start()
    {
        bone = "Touch a bone";
        gameMode = menuSelect.gamemode;
    }

    // Update is called once per frame
    void Update()
    {
        gameMode = menuSelect.gamemode;

        //prueba para saber si se coloca bien el gamemode
        if(gameMode)
            Debug.Log("Game mode");
    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("skull")){
            bone = "skull";
            bones.text = bone;
        }else if (other.CompareTag("hand")){
            bone = "Carpals, metacarpals and phalanges";
            bones.text = bone;
        }else if (other.CompareTag("arm")){
            bone = "Humerus";
            bones.text = bone;
        }
        else if (other.CompareTag("forearm")){
            bone = "Radius and Ulna";
            bones.text = bone;
        }
        else if (other.CompareTag("ribs"))
        {
            bone = "Ribs";
            bones.text = bone;
        }
        else if (other.CompareTag("pelvis"))
        {
            bone = "Pelvis";
            bones.text = bone;
        }
        else if (other.CompareTag("upperleg"))
        {
            bone = "Femur";
            bones.text = bone;
        }
        else if (other.CompareTag("lowerleg"))
        {
            bone = "Tibia and Fibula";
            bones.text = bone;
        }
    }

    private void OnTriggerExit(Collider other){
        //ahorramos codigo ya que tan solo al salir de cualquier huesto se actualizara a touch a bone
        bone = "Touch a bone";
        bones.text = bone;
    }

}
