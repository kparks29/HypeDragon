using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TableObjectGenerator : MonoBehaviour
{
    public int NumberOfObjects = 3;
    public GameObject Table;
	public GameObject TableObjectParent;
    public GameObject TableObjectPrefab;

	void Start ()
    {
        //Get List of All Objects

        
        StartCoroutine(SpawnObjects());
	}

	public void GenerateObjects()
	{
		StartCoroutine(SpawnObjects());
	}

    protected IEnumerator SpawnObjects()
    {
        //Find Table, Get Position Above Table
        if (Table == null) { Debug.Log("NO TABLE NOOOOOO"); }
        var tablePosition = Table.transform.position;
        var tableSize = Vector3.Scale(Table.GetComponent<MeshFilter>().mesh.bounds.size, Table.transform.localScale);

        //Spawn Objects
        for (int i = 0; i < NumberOfObjects; i++)
        {

            var rand = UnityEngine.Random.Range(0, GameInformation.AllTableObjects.Count);
            var go = Instantiate(TableObjectPrefab);
			go.transform.SetParent(TableObjectParent.transform);
            var goSize = Vector3.Scale(go.GetComponent<MeshFilter>().mesh.bounds.size, go.transform.localScale);
            var minX = tablePosition.x - (tableSize.x / 2) + goSize.x;
            var maxX = tablePosition.x + (tableSize.x / 2) - goSize.x;
            var minZ = tablePosition.z - (tableSize.z / 2) + goSize.z;
            var maxZ = tablePosition.z + (tableSize.z / 2) - goSize.z;
            var xPos = UnityEngine.Random.Range(minX, maxX);
            var zPos = UnityEngine.Random.Range(minZ, maxZ);
            var spawnPosition = new Vector3(xPos, tablePosition.y + 1, zPos);

            go.transform.position = spawnPosition;

            var tableObjectController = go.GetComponent<TableObjectController>();
            tableObjectController.TableObjectName = GameInformation.AllTableObjects[rand];
            go.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
