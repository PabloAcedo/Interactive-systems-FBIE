using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject scorpionPrefab; //prefab of the scorpion
    public List<Transform> scorpionSpawnPositions = new List<Transform>(); //list of the positions where the scorpions will be spawned
    public float timeBetweenSpawns; 
    private List<GameObject> scorpionList = new List<GameObject>(); //lis of active scorpions (spawned scorpions)

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(SpawnRoutine()); //setting the spawn coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Vector3 randomPosition = scorpionSpawnPositions[Random.Range(0, scorpionSpawnPositions.Count)].position;
        GameObject scorpion = Instantiate(scorpionPrefab, randomPosition, scorpionPrefab.transform.rotation); //creating the scorpion
        scorpionList.Add(scorpion); //adding it to the list
        scorpion.GetComponent<Scorpion>().SetSpawner(this);
    } 

    private IEnumerator SpawnRoutine(){
        while (canSpawn){
            Spawn();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveScorpionFromList(GameObject scorpion){
        scorpionList.Remove(scorpion); //removing the scorpions form the active scorpions list
    }

    public void DestroyAll(){ //in order to destroy all the scorpions
        foreach (GameObject scorpion in scorpionList){
            Destroy(scorpion);
        }
        scorpionList.Clear();
    }
}


