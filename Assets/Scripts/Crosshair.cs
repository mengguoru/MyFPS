using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public Texture2D crossHair;

    void OnGUI()
    {
        float w = crossHair.width / 2;
        float h = crossHair.height / 2;

        Rect position = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
        GUI.DrawTexture(position,crossHair);
    }
}
