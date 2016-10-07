using UnityEngine;
using System.Collections;

public class KnifeController : MonoBehaviour {

    Animator anim;
    bool shooting;
    public float attackDis;

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

            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, attackDis);

        for(int i = 0; i < hitColliders.Length; ++i)
        {
            if("Zombie" == hitColliders[i].transform.tag)
            {
                Debug.Log("broken bootle hit");
                hitColliders[i].transform.gameObject.SendMessage("beBrokenBottleAttack");
            }
        }
    }
}
