using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MeshLoader : MonoBehaviour
{
    public GameInformation.TableObjectNames[] ObjectNames;
    public Mesh[] ObjectMeshes;

    void Awake()
    {
        Debug.Log("Assigning Things!");
        for (int i = 0; i < ObjectNames.Length; i++)
        {
            GameInformation.TableObjects[ObjectNames[i]].ObjectMesh = ObjectMeshes[i];
        }
    }
}
