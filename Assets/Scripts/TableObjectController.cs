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

	protected Vector3 LastPosition;
	protected Quaternion LastRotation;
   
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
		//Generate Score
		if (LastPosition == null)
			LastPosition = transform.position;
		if (LastRotation == null)
			LastRotation = transform.rotation;

		var dist = Vector3.Distance(transform.position, LastPosition);
		if (dist > 0)
		{
			int score = Mathf.CeilToInt(dist);
			GameInformation.Score += score;
		}

		var rel = Quaternion.Inverse(transform.rotation) * LastRotation;
		var dif = rel.x + rel.y + rel.z;
		if (dif > 0)
		{
			int score = Mathf.CeilToInt(dif);
			GameInformation.Score += score;
		}

		LastPosition = transform.position;
		LastRotation = transform.rotation;
	}
}
