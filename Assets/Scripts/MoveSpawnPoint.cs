using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawnPoint : MonoBehaviour
{

    public float speed;//speed of movement
    
    public float limitx_left; //left limit (in x axis)
    public float limitx_right; //right limit(in y axis)

    public bool right; //in order to know if the object is at the right (positive) side of x axis or not

    // Start is called before the first frame update
    void Start()
    {
        //if initial pos of the object is at the left
        if(!right){
            speed = -speed; //the object starts to move in the other direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        Update_movement();
    }

    void Update_movement(){
        //setting the direction of the speed (sign) depending of the location of the object
        //if the object reaches de left limit the object will move to the right, if the object reaches
        //the right limit the object will move to the left
        if(transform.position.x > limitx_right || transform.position.x < limitx_left){
            speed = -speed;//changing the direction by changing the speed
        }

        transform.Translate(transform.right * speed * Time.deltaTime); //moving the object
    }
}
