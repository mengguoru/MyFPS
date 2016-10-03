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

	// Use this for initialization
	void Start () {
        //Debug.Log(transform.forward);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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
        else if(dis <= dangerDis)
        {
            Vector3 tmp = target.position - transform.position;
            transform.forward = tmp;
            //Debug.Log(transform.forward);
            transform.Translate(transform.forward * runSpeed * Time.deltaTime * -1);

            anim.SetBool("attack", true);
        }

        //Vector3 targetDir = target.position - transform.position;
        //float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle);
    }

    public void beShooted(string str)
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
            
    }
}
