using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float blood;
    public bool dead;
    public Text HUDHealthText;
    public Slider healthSlider;

    public GameObject[] myItems;
    public int currentObjectIndex;
    public GameObject crosshair;

	// Use this for initialization
	void Start () {
        dead = false;
        //myItems.
        currentObjectIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (blood <= 0)
            dead = true;
        HUDHealthText.text = ""+(int)blood + "/100";
        healthSlider.value = (int)blood;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z");
        }else if ((Input.GetKeyDown(KeyCode.X)))
        {
            myItems[currentObjectIndex].SetActive(false);
            crosshair.SetActive(false);
        }
	}

    void beAttacked()
    {
        blood -= 10;
    }
}
