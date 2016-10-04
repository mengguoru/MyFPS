﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float blood;
    public bool dead;
    public Text HUDHealthText;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (blood <= 0)
            dead = true;
        HUDHealthText.text = ""+(int)blood + "/100";
        healthSlider.value = (int)blood;
	}

    void beAttacked()
    {
        blood -= 10;
    }
}
