using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TableObjectGenerator : MonoBehaviour
{
    public int NumberOfObjects = 3;
    public GameObject Table;

	void Start ()
    {
        //Get List of All Objects
        var allTableObjects = Enum.GetValues(typeof(GameInformation.TableObjectNames)).Cast<GameInformation.TableObjectNames>().ToList();
        allTableObjects = allTableObjects.Where(o => o >= 0).ToList();

        //Find Table, Get Position Above Table
        if (Table == null) { Debug.Log("NO TABLE NOOOOOO"); }
        var spawnPosition = Table.transform.position;
        spawnPosition.y += 1;

        //Spawn Objects
        for (int i = 0; i < NumberOfObjects; i++)
        {
            var rand = UnityEngine.Random.Range(0, allTableObjects.Count);
            Debug.Log("Create a " + allTableObjects[rand]);
        }
	}
}
