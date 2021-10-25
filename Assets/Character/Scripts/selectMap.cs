using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class selectMap : MonoBehaviour
{
    private int index;
    public Sprite[] sprite;
    public GameObject panel;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        image = panel.GetComponent<Image>();
        image.sprite = sprite[index];
    }

    public void left()
    {
        index -= 1;
        if (index < 0) {
            index = sprite.Length - 1;
        }
        image.sprite = sprite[index];
    }

    public void right()
    {
        index += 1;
        if (index >= sprite.Length) {
            index = 0;
        }
        image.sprite = sprite[index];
    }
}
