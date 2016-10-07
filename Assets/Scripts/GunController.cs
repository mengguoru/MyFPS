using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunController: MonoBehaviour {

    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletOutFlash;
    Animator anim;
    public GameObject impactPrefab;

    public GameObject impact;

    public bool shooting;
    
    public int bulletAmount;
    public int maxbBulletAmount;


    public Text HUDbulletAmount;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        shooting = false;
        impact = (GameObject)Instantiate(impactPrefab);
        maxbBulletAmount = bulletAmount;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1") && bulletAmount > 0)
        {
            muzzleFlash.Play();
            bulletOutFlash.Play();
            anim.SetTrigger("Fire");

            shooting = true;
        }

        HUDbulletAmount.text = bulletAmount + "/" + maxbBulletAmount;
    }

    void FixedUpdate()
    {
        if (shooting && bulletAmount >0)
        {
            shooting = false;
            bulletAmount--;

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

                //Debug.Log(hit.collider.transform.tag);
                if ("head" == hit.collider.transform.tag)
                {
                    Debug.Log("head");
                    //hit.transform.gameObject.SendMessage("beShooted", "head");
                    hit.transform.parent.gameObject.SendMessage("beShooted", "head");
                }
                else if ("Zombie" == hit.collider.transform.tag)
                {
                    Debug.Log("body");
                    hit.transform.gameObject.SendMessage("beShooted", "Zombie");
                }

            }
        }
    }
}
