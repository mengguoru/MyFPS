using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.tag);
        if ("Player" == other.transform.tag)
        {
            //Debug.Log("load scene");
            SceneManager.LoadScene("InBigHouse");
        }
    }
}
