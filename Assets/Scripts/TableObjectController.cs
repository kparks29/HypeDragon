using UnityEngine;
using System.Collections;

public class TableObjectController : MonoBehaviour
{
    public GameInformation.TableObjectNames TableObjectName;

    protected GameInformation.TableObject TableObject;
    protected MeshFilter TableObjectMeshFilter;
    protected MeshCollider TableObjectMeshCollider;
    protected Rigidbody TableObjectRigidBody;
    protected AudioSource TableObjectAudioSource;
   
	void Start ()
    {
        TableObject = GameInformation.TableObjects[TableObjectName];
        TableObjectMeshFilter = GetComponent<MeshFilter>();
        if (TableObjectMeshFilter == null)
        {
            var mf = gameObject.AddComponent<MeshFilter>();
            TableObjectMeshFilter = mf;
        }
        //if (TableObjectMeshFilter.mesh != null)
        //{
        //    TableObject.ObjectMesh = TableObjectMeshFilter.mesh;
        //}
        //else
        //Debug.Log("Bewp" + TableObject.ObjectMesh.name);
        TableObjectMeshFilter.mesh = TableObject.ObjectMesh;

        TableObjectMeshCollider = GetComponent<MeshCollider>();
        if (TableObjectMeshCollider == null)
        {
            var mc = gameObject.AddComponent<MeshCollider>();
            TableObjectMeshCollider = mc;
        }
        TableObjectMeshCollider.sharedMesh = TableObjectMeshFilter.mesh;

        TableObjectRigidBody = GetComponent<Rigidbody>();
        if (TableObjectRigidBody == null)
        {
            var rb = gameObject.AddComponent<Rigidbody>();
            TableObjectRigidBody = rb;
        }
        TableObjectRigidBody.mass = TableObject.Mass;
        TableObjectRigidBody.drag = TableObject.Drag;

        TableObjectAudioSource = GetComponent<AudioSource>();
        if (TableObjectAudioSource == null)
        {
            var audSrc = gameObject.AddComponent<AudioSource>();
            audSrc.clip = TableObject.SoundEffect;
        }
        else
        {
            TableObject.SoundEffect = TableObjectAudioSource.clip;
        }
    }
	
	void Update ()
    {
	
	}
}
