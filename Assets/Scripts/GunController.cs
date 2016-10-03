using UnityEngine;
using System.Collections;

public class GunController: MonoBehaviour {

    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletOutFlash;
    public Animator anim;
    public GameObject impactPrefab;

    public GameObject impact;

    public bool shooting;

    public ParticleSystem testImpact;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        shooting = false;
        impact = (GameObject)Instantiate(impactPrefab);
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
            bulletOutFlash.Play();
            anim.SetTrigger("Fire");

            shooting = true;
        }
	}

    void FixedUpdate()
    {
        if (shooting)
        {
            shooting = false;

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);

                impact.transform.position = hit.point;
                impact.GetComponent<ParticleSystem>().Play();

                //handle the object hit

                //check if hit zombie
                //if ("Zombie" == hit.transform.tag)
                //    Destroy(hit.transform.gameObject);
                Debug.Log(hit.collider.transform.tag);
                if ("head" == hit.collider.transform.tag)
                {
                    Debug.Log("head");
                }
                else if ("body" == hit.collider.transform.tag)
                    Debug.Log("body");
            }
        }
    }
}
