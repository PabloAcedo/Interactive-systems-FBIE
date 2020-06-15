using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchBone : MonoBehaviour
{
    public string bone;

    public string tagOption; //in order to visualize which bone the user has to touch in the game mode
    public string touchedBonetag;

    public Text bones; //text
    public Text ScoreText; //score text
    public Image timerbar; //time image

    private bool gameMode; //para saber si el modo es el de touchbone o el de jugar(si es true, es el de jugar)
   
    public float time;

    float minTime; //time to wait

    int score; public int opt;

    void Start()
    {
        //init
        bone = "Touch a bone";
        gameMode = menuSelect.gamemode;
        minTime = 3.0f; //time to wait, 3 seconds
        time = minTime;
        score = 0;
        timerbar.enabled = false;

        if(gameMode){
            ScoreText.text = "Score: ";
            //begin always with the skull option
            tagOption = "skull";
            bone = "Touch your skull";
            bones.text = bone;
            ScoreText.text = "Score: "+ score.ToString();
            timerbar.enabled = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {  
        gameMode = menuSelect.gamemode;

        if(gameMode){

            //when the user touch the correct bone, wait 3 seconds
            if (tagOption == touchedBonetag){
                timerbar.fillAmount = time / 3;
                time -= Time.deltaTime;
            }

            //when the time is over, 
            if (time < 0.1){
                SumScore();
                timerbar.fillAmount = 1;
            }

        }else{
            ScoreText.text = ""; //hide the score in default mode
        }

    }

    //method in order to change the tag of the bone that the user has to touch(in Game Mode)
    void changeBone2touch(int option){

        switch(option){
            case 0:
                tagOption = "skull";
                bone = "Touch your skull";
                break;
            case 1:
                tagOption = "hand";
                bone = "Touch your hand";
                break;
            case 2:
                tagOption = "arm";
                bone = "Touch your humerus";
                break;
            case 3:
                tagOption = "forearm";
                bone = "Touch your Radius and Ulna";
                break;
            case 4:
                tagOption = "ribs";
                bone = "Touch your Ribs";
                break;
            case 5:
                tagOption = "pelvis";
                bone = "Touch your Pelvis";
                break;
            case 6:
                tagOption = "upperleg";
                bone = "Touch your Femur";
                break;
        }

    }

    //with this method we control the game mode of the app
    void InGame(){
        opt = Random.Range(0,6); //random option
        changeBone2touch(opt); //changing wich bone the user has to touch
        bones.text = bone; //displaying the text
    }

    //sum score and change bone to touch 
    void SumScore(){
        score+=1; //adding one point
        time = minTime; //reset the time
        ScoreText.text = "Score: "+ score.ToString();
        InGame();
    }

    private void OnTriggerEnter(Collider other){

        //in default/informative mode, change which bone you are touching
        if(!gameMode){
            if (other.CompareTag("skull")){
                bone = "skull";
            }else if (other.CompareTag("hand")){
                bone = "Carpals, metacarpals and phalanges";
            }else if (other.CompareTag("arm")){
                bone = "Humerus";
            }
            else if (other.CompareTag("forearm")){
                bone = "Radius and Ulna";
            }
            else if (other.CompareTag("ribs"))
            {
                bone = "Ribs";
            }
            else if (other.CompareTag("pelvis"))
            {
                bone = "Pelvis";
            }
            else if (other.CompareTag("upperleg"))
            {
                bone = "Femur";
            }
            else if (other.CompareTag("lowerleg"))
            {
                bone = "Tibia and Fibula";
            }

            bones.text = "Last bone touched: " + bone; //displaying the text (the bone that the user is touching)

        }else{ //if game mode
            touchedBonetag = other.tag; //saving tag to compare
            time = minTime; //if tag is changed 
        }

    }

}
