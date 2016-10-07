using UnityEngine;
using System.Collections;

public class lifeBottle : MonoBehaviour {

    public float availableDis;

	// Use this for initialization
	//void Start () {
	
	//}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, availableDis);

        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if ("Player" == hitColliders[i].transform.tag)
            {
                Debug.Log("addBlood");
                hitColliders[i].transform.gameObject.SendMessage("addBlood");
                Destroy(this.transform.gameObject);
            }
        }
    }
}
