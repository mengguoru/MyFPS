using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

    public Transform target;
    public float safetyDis;
    public float dangerDis;
    public float walkSpeed;
    public float runSpeed;
    public Animator anim;

    public float blood;

    public bool playerInRange;
    public float timeBetweenAttack = 0.5f;
    float timer;

	// Use this for initialization
	void Start () {
        //Debug.Log(transform.forward);
        anim = GetComponent<Animator>();
        playerInRange = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(playerInRange && timer >= timeBetweenAttack)
        {
            anim.SetBool("attack", true);   
        }

        //Vector3 targetDir = target.position - transform.position;
        //float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle);

        if (blood <= 0)
        {
            //Destroy(this.gameObject);
            anim.SetBool("dead", true);
        }
        else
        {
            float dis = Vector3.Distance(transform.position, target.position);

            if (safetyDis >= dis && dis >= dangerDis)
            {
                //Debug.Log("danger");
                Vector3 tmp = target.position - transform.position;
                transform.forward = tmp;
                //Debug.Log(transform.forward);
                transform.Translate(transform.forward * walkSpeed * Time.deltaTime * -1);

                anim.SetBool("attack", false);
            }
            else if (dis <= dangerDis)
            {
                Vector3 tmp = target.position - transform.position;
                transform.forward = tmp;
                //Debug.Log(transform.forward);
                transform.Translate(transform.forward * runSpeed * Time.deltaTime * -1);

                //anim.SetBool("attack", true);
            }

        }
    }

    //void OnCollisionEnter(Collision coll)
    //{
    //    if ("Player" == coll.transform.tag)
    //        coll.transform.gameObject.SendMessage("beAttacked");
    //}

    void OnTriggerEnter(Collider other)
    {
        if ("Player" == other.transform.tag)
        {
            playerInRange = true;

            if (playerInRange && timer >= timeBetweenAttack)
            {
                Debug.Log(other.transform.gameObject.tag);
                other.transform.gameObject.SendMessage("beAttacked");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ("Player" == other.transform.tag)
            playerInRange = false;
    }

    void beShooted(string str)
    {
        switch(str)
        {
            case "head":
                blood -= 100;
                break;
            case "Zombie":
                blood -= 50;
                break;
        }
        //Debug.Log(blood);
    }
}
