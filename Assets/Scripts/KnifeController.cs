using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour {

    Animator anim;
    bool shooting;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        shooting = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Fire");
            shooting = true;
        }
    }

    void FixedUpdate()
    {
        if (shooting)
        {
            shooting = false;

            
        }
    }
}
