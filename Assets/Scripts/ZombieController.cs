using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

    public Transform target;
    public float safetyDis;

	// Use this for initialization
	void Start () {
        Debug.Log(transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
	    if(safetyDis >= Vector3.Distance(transform.position,target.position))
        {
            //Debug.Log("danger");
            Vector3 tmp = target.position - transform.position;
            transform.forward = tmp;
        }

        //Vector3 targetDir = target.position - transform.position;
        //float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle);
    }
}
