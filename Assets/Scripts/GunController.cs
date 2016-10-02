using UnityEngine;
using System.Collections;

public class GunController: MonoBehaviour {

    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletOutFlash;
    public Animator anim;
    public GameObject impactPrefab;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
            bulletOutFlash.Play();
            //anim.SetTrigger("Fire");
        }
	}
}
