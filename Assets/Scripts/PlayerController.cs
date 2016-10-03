using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float blood;
    public bool dead;

	// Use this for initialization
	void Start () {
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (blood <= 0)
            dead = true;
	}

    void beAttacked()
    {
        blood -= 10;
    }
}
