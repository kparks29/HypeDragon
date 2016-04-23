using UnityEngine;
using System.Collections;

public class TableObjectController : MonoBehaviour
{
    public GameInformation.TableObjectNames TableObjectName;

    protected GameInformation.TableObject TableObject;
    protected MeshFilter TableObjectMeshFilter;
    protected Rigidbody TableObjectRigidBody;
    protected AudioSource TableObjectAudioSource;
   
	void Start ()
    {
        TableObject = GameInformation.TableObjects[TableObjectName];
        TableObjectMeshFilter = GetComponent<MeshFilter>();
        if (TableObjectMeshFilter != null)
            TableObject.ObjectMesh = TableObjectMeshFilter.mesh;

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
