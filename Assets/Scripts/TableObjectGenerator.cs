using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TableObjectGenerator : MonoBehaviour
{
    public int NumberOfTableObjects = 3;
    public int NumberOfObstacles = 3;
    public GameObject BoomBox;
    public GameObject Table;
	public GameObject TableObjectParent;
    public GameObject TableObjectPrefab;
    public GameObject ObstacleParent;
    public GameObject ObstaclePrefab;

	void Start ()
    {
        //Get List of All Objects
        StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnObstacles());
    }

	public void GenerateObjects()
	{
		StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnObstacles());
        if (!BoomBox.activeInHierarchy)
        {
            BoomBox.SetActive(true);
            BoomBox.GetComponent<AudioSource>().Play();
        }
        BoomBox.transform.localPosition = new Vector3(0, 0, 5.7f);
        BoomBox.transform.localRotation = Quaternion.Euler(0, 270, 0);
	}

    protected IEnumerator SpawnObstacles()
    {
        //Find Table, Get Position Above Table
        if (Table == null) { Debug.Log("NO TABLE NOOOOOO"); }
        var tablePosition = Table.transform.position;

        //Spawn Obstacles
        for (int i = 0; i < NumberOfObstacles; i++)
        {
            var rand = UnityEngine.Random.Range(0, GameInformation.AllObstacles.Count);
            var obstacle = Instantiate(ObstaclePrefab);
            obstacle.transform.SetParent(ObstacleParent.transform);
            var goSize = Vector3.Scale(obstacle.GetComponent<MeshFilter>().mesh.bounds.size, obstacle.transform.localScale);
            var minX = tablePosition.x - 1;
            var maxX = tablePosition.x - 4;
            var minZ = tablePosition.z - 3;
            var maxZ = tablePosition.z + 3;
            var xPos = UnityEngine.Random.Range(minX, maxX);
            var zPos = UnityEngine.Random.Range(minZ, maxZ);
            var spawnPosition = new Vector3(xPos, tablePosition.y + 3, zPos);

            obstacle.transform.position = spawnPosition;

            var tableObjectController = obstacle.GetComponent<ObstacleController>();
            tableObjectController.TableObjectName = GameInformation.AllObstacles[rand];
            obstacle.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }
    }

    protected IEnumerator SpawnObjects()
    {
        //Find Table, Get Position Above Table
        if (Table == null) { Debug.Log("NO TABLE NOOOOOO"); }
        var tablePosition = Table.transform.position;
        var tableSize = Vector3.Scale(Table.GetComponent<MeshFilter>().mesh.bounds.size, Table.transform.localScale);

        //Spawn Objects
        for (int i = 0; i < NumberOfTableObjects; i++)
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
            var spawnPosition = new Vector3(xPos, tablePosition.y + 3, zPos);

            go.transform.position = spawnPosition;

            var tableObjectController = go.GetComponent<TableObjectController>();
            tableObjectController.TableObjectName = GameInformation.AllTableObjects[rand];
            go.SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }


    }

}
