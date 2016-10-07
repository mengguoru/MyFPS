using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    public float blood;
    public bool dead;
    public Text HUDHealthText;
    public Slider healthSlider;

    public GameObject[] myItems;
    public int currentObjectIndex;
    public GameObject crosshair;

    public List<Image> ItemIcons;

	// Use this for initialization
	void Start () {
        dead = false;
        //myItems.
        currentObjectIndex = 0;
        //ItemIcons[currentObjectIndex].sprite = myItems[currentObjectIndex].GetComponent<ItemInformation>().myIcon;
        //ItemIcons[1].sprite = myItems[1].GetComponent<ItemInformation>().myIcon;
        for(int i = 0; i < 3; ++i)
        {
            ItemIcons[i].sprite = myItems[i].GetComponent<ItemInformation>().myIcon;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (blood <= 0)
            dead = true;
        HUDHealthText.text = ""+(int)blood + "/100";
        healthSlider.value = (int)blood;

        //Z:0 X:1
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("Z");
            myItems[currentObjectIndex].SetActive(true);
            crosshair.SetActive(true);

            myItems[1].SetActive(false);
        }
        else if ((Input.GetKeyDown(KeyCode.X)))
        {
            myItems[currentObjectIndex].SetActive(false);
            crosshair.SetActive(false);

            myItems[1].SetActive(true);
        }
        else if ((Input.GetKeyDown(KeyCode.C)))
        {
            myItems[0].SetActive(false);
            myItems[1].SetActive(false);
            myItems[2].SetActive(true);
        }

    }

    void beAttacked()
    {
        blood -= 10;
    }
}
