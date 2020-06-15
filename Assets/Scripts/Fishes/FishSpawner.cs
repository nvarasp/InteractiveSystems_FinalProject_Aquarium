using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject nose;                                         // Nose
    public List<GameObject> fishPrefabs = new List<GameObject>();   // Fishes List
    public List<Transform> SpawnPositions = new List<Transform>();  // Spawn Positions List
    public float timeBetweenSpawns;                                 // Time between Spawns
    public float spwanPos;                                          // Spawn positions

    private int counter_total = 0;                                  // Fishes count
    public int max = 7;                                             // Maximum fishes in the aquarium

    private List<GameObject> fishList = new List<GameObject>();     // Fishes list

    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("SpawnRoutine", 1f, timeBetweenSpawns);
    }

    // Fishes spawner
    private void SpawnFish()
    {
        if (counter_total < max)
        {
            Vector3 newloc = SpawnPositions[Random.Range(0, SpawnPositions.Count)].position;    // Choose randomly the spawn position
            GameObject randomFish = fishPrefabs[Random.Range(0, fishPrefabs.Count)];
            GameObject fish = Instantiate(randomFish, newloc, randomFish.transform.rotation);
            counter_total += 1;
            fishList.Add(fish); 
            fish.SetActive(true);
        }
    }

    // Spawn fishes when person is down
    private void SpawnRoutine()
    {
        if(nose.transform.position.y <= spwanPos){
            SpawnFish();
        }
    }

    // Remove fishes from list
    public void RemoveFishFromList (GameObject fish)
    {
        fishList.Remove(fish);
    }

    // Destroy the fishes in the list
    public void DestroyAllFish()
    {   
        counter_total = 0;
        fishList.Clear();
    }
}
