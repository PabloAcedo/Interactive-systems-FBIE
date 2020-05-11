using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public float speed; //speed at which the scorpion is moving
    private bool hitted; //if is hitted or not

    private Collider myCollider; 
    private Rigidbody myRigidbody;

    private Spawner ScorpionSpawner; //in order to spawn scorpions from certain points

    // Start is called before the first frame update
    void Start(){
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.down * speed * Time.deltaTime);//moving the scorpion in the negative vertical axis
    }

    private void Hitted(){

        hitted = true;
        speed = 0;
        Destroy(gameObject); //destroying the hitted scorpion
        ScorpionSpawner.RemoveScorpionFromList(gameObject); //removing the scorpion from the scorpionlist of the spawner

    }

    private void OnTriggerEnter(Collider other){
        //if you touch with your hands or skull (head) the scorpion 
        if (other.CompareTag("hand") || other.CompareTag("skull") && !hitted){

            Hitted(); //scoprion hitted and destroyed

        }else if (other.CompareTag("object_destroyer")){ //if scorpion reach the final of the scene

            Hitted(); //scorpion destroyed

        }
    }

    
    public void SetSpawner(Spawner spawner){ 
        ScorpionSpawner = spawner;
    }
}
