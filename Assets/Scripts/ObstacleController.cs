using UnityEngine;
using System.Collections;

public class ObstacleController : ObjectBaseClass
{
    public GameObject explosion;

    public override void ChildCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TableObjectPrefab(Clone)")
        {
            Debug.Log("Boom!");
            GameInformation.Score += 10000;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
