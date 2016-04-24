using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObstacleController : ObjectBaseClass
{
    public GameObject explosion;
    public GameObject explosionCollision;

    public override void ChildCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TableObjectPrefab(Clone)")
        {
            GameInformation.Score += 10000;

			var children = new List<GameObject>();
			foreach (Transform child in transform.parent.transform) children.Add(child.gameObject);
			if (children.Count == 1)
			{
                var specialCanvas = GameObject.Find("SpecialCanvas");
                specialCanvas.GetComponent<ShoutController>().PlayAnimation();

                Debug.Log("Destroyed All Objects!");
				GameInformation.Score += 50000;
			}

			Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(explosionCollision, transform.position, transform.rotation);
        }
    }
}
