using UnityEngine;
using System.Collections;

public class ExplosionCollisionController : MonoBehaviour
{
    float MaxSize = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.localScale.x < MaxSize)
        { 
            var scale = transform.localScale;
            scale *= 1.1f;
            transform.localScale = scale;
        }
	    else
        {
            Destroy(gameObject);
        }
	}
}
