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

            //if (Physics.Raycast(transform.position,transform.forward,out hit,50f))
            //{
            //    impact.transform.position = hit.point;
            //    Debug.Log(transform.position);
            //    //Debug.Log(hit.point);
            //    impact.GetComponent<ParticleSystem>().Play();
            //    Debug.DrawRay(transform.position, transform.forward, Color.green);
            //}
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                impact.transform.position = hit.point;
                //ParticleSystem ps = impact.GetComponent<ParticleSystem>();
                impact.GetComponent<ParticleSystem>().Play();

                //if (!impact.GetComponent<ParticleSystem>().isPlaying)
                //    impact.GetComponent<ParticleSystem>().Play();

                //Instantiate(impactPrefab, hit.point, Quaternion.identity);

                //ps.Clear();
                //ps.Play();

                //impact.SetActive(false);
                //impact.SetActive(true);
                //Debug.Log(ps.isPlaying);
            }
        }
        shooting = false;
    }
}
