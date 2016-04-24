using UnityEngine;
using System.Collections;

public class ObstacleController : ObjectBaseClass {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TableObjectPrefab(Clone)")
            Debug.Log("Boom!");
    }
}
