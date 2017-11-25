using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*************************************************************************************
 * Behavior : Randomize position of players and Json everytime the scence is loaded  *
 *                                                                                   *
 *************************************************************************************/

public class Spawner : MonoBehaviour
{
    private GameObject playersFolder;
    private GameObject spawnersFolder;
    private List<Transform> spawnersTransformList;
    private List<int> usedSpawner;
    private List<GameObject> activePlayers;

	// Use this for initialization
	void Start ()
    {
        playersFolder = GameObject.Find("PlayersFolder");

        spawnersFolder = GameObject.Find("SpawnersFolder");

        spawnersTransformList = new List<Transform>();
        foreach(Transform t in spawnersFolder.transform)
            spawnersTransformList.Add(t);

        usedSpawner = new List<int>();

        // Set activePlayers list, ignore unassigned players ! and spawn them at a random spawner position
        activePlayers = new List<GameObject>();
        foreach(Transform t in playersFolder.transform)
            if(t.gameObject.activeSelf)
                activePlayers.Add(t.gameObject);
        for(int i = 0; i < activePlayers.Count; i++)
        {
            // Get random unused spawner
            int randomSpawnerIndex = Random.Range(0, spawnersTransformList.Count - 1);
            while(usedSpawner.Contains(randomSpawnerIndex))
                randomSpawnerIndex = Random.Range(0, spawnersTransformList.Count - 1);
            
            // Set player position
            activePlayers[i].transform.position = spawnersTransformList[randomSpawnerIndex].position;
            activePlayers[i].GetComponent<PlayerInputs>().SetAllowMovement(true);

            // Add spawner to the list of used spawner
            usedSpawner.Add(randomSpawnerIndex);
        }
	}
}
