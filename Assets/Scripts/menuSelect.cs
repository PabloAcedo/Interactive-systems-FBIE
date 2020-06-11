using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuSelect : MonoBehaviour
{

    public bool invoke;

    public static bool gamemode; 

    Collider trig;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        invoke = false;
        time = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //compute the time (countdown of 5 seconds) since the hand is touching the option of the menu
        if (invoke == true){
            time -= Time.deltaTime;
        }

        if(time < 1){
            if (trig.CompareTag("DefaultMode")){
                PlayGame(); //play game in default mode (only touching bones)
            }else if (trig.CompareTag("PlayMode")){
                gamemode = true; //activate the game mode in order to play
                PlayGame();
            }else if(trig.CompareTag("Quit")){
            
                Debug.Log("Bye!!");
                Application.Quit(); //kill app
            }
        }
        
        
    }

     public void PlayGame(){

        SceneManager.LoadScene(1);//load the main scene

    }

    private void OnTriggerEnter(Collider other){
        invoke = true; //if an option is touch with the hand, call the option
        trig = other;
    }

    private void OnTriggerExit(Collider other){
        invoke = !invoke; //exit option
        time = 5.0f; //reset counter
    }

}
