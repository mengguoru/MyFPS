using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Scene2Telepoter : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
	
	//}
	
	//// Update is called once per frame
	//void Update () {
	
	//}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.tag);
        if ("Player" == other.transform.tag)
        {
            //Debug.Log("load scene");
            SceneManager.LoadScene("theEnd");
        }
    }
}
