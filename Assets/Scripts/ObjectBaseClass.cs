using UnityEngine;
using System.Collections;

public class ObjectBaseClass : MonoBehaviour {

    public GameInformation.TableObjectNames TableObjectName;
    public bool IsATable = false;

    protected GameInformation.TableObject TableObject;
    protected MeshFilter TableObjectMeshFilter;
    protected MeshCollider TableObjectMeshCollider;
    protected Rigidbody TableObjectRigidBody;
    protected AudioSource TableObjectAudioSource;
    protected MeshRenderer TableObjectMeshRenderer;

    protected Vector3 LastPosition;
    protected Quaternion LastRotation;

	protected float SFXCountDown = 0;
	protected float SFXCountDownMax = 2;
	protected int ColliderCount = 0;

    void Start()
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

        if (!IsATable)
        {
            TableObjectMeshCollider = GetComponent<MeshCollider>();
            if (TableObjectMeshCollider == null)
            {
                var mc = gameObject.AddComponent<MeshCollider>();
                TableObjectMeshCollider = mc;
            }
            TableObjectMeshCollider.sharedMesh = TableObjectMeshFilter.mesh;
        }

        TableObjectMeshRenderer = GetComponent<MeshRenderer>();
        if (TableObjectMeshRenderer == null)
        {
            var tomr = gameObject.AddComponent<MeshRenderer>();
            TableObjectMeshRenderer = tomr;
        }
        TableObjectMeshRenderer.material = TableObject.Material;

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
			TableObjectAudioSource = audSrc;
        }
		TableObjectAudioSource.clip = TableObject.SoundEffect;
    }

    void Update()
    {
        //Destroy Out of Bounds Objects
        if (!IsATable)
        {
            if (transform.position.y < -1)
                Destroy(gameObject);
        }

        //Generate Score
        if (LastPosition == null)
            LastPosition = transform.position;
        if (LastRotation == null)
            LastRotation = transform.rotation;

        var dist = Vector3.Distance(transform.position, LastPosition);
        if (dist > 0.01)
        {
            int score = Mathf.CeilToInt(dist);
            GameInformation.Score += score;
        }

        var rel = Quaternion.Inverse(transform.rotation) * LastRotation;
        var dif = rel.x + rel.y + rel.z;
        if (dif > 0.01)
        {
            int score = Mathf.CeilToInt(dif);
            GameInformation.Score += score;
        }

        LastPosition = transform.position;
        LastRotation = transform.rotation;

		//SFXTimer
		if (SFXCountDown > 0)
			SFXCountDown -= Time.deltaTime;
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "ExplosionCollision(Clone)")
		{			
			ColliderCount++;
			GameInformation.Score += 1000 * ColliderCount;
			Debug.Log("Combo: " + ColliderCount + " X 1000");
		}


		if (TableObject.SoundEffect != null && SFXCountDown <= 0)
		{
			if (Random.Range(0f, 1f) > 0.3f)
				TableObjectAudioSource.Play();

			SFXCountDown = SFXCountDownMax;
		}
		ChildCollisionEnter(collision);
	}
	
	public virtual void ChildCollisionEnter(Collision collision)
	{

	}
}
