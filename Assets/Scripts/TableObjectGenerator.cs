using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TableObjectGenerator : MonoBehaviour
{
    public int NumberOfObjects = 3;
    public GameObject Table;

    public GameObject TableObjectPrefab;

	void Start ()
    {
        //Get List of All Objects
        var allTableObjects = Enum.GetValues(typeof(GameInformation.TableObjectNames)).Cast<GameInformation.TableObjectNames>().ToList();
        allTableObjects = allTableObjects.Where(o => o >= 0).ToList();
        
        StartCoroutine(SpawnObjects(allTableObjects));
	}

    protected IEnumerator SpawnObjects(List<GameInformation.TableObjectNames> allTableObjects)
    {
        //Find Table, Get Position Above Table
        if (Table == null) { Debug.Log("NO TABLE NOOOOOO"); }
        var spawnPosition = Table.transform.position;
        spawnPosition.y += 5;

        //Spawn Objects
        for (int i = 0; i < NumberOfObjects; i++)
        {
            var rand = UnityEngine.Random.Range(0, allTableObjects.Count);
            var go = Instantiate(TableObjectPrefab);
            go.transform.position = spawnPosition;

            var tableObjectController = go.GetComponent<TableObjectController>();
            tableObjectController.TableObjectName = allTableObjects[rand];
            go.SetActive(true);

            yield return new WaitForSeconds(1);
        }
    }
}
