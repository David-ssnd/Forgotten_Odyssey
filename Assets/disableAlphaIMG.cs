using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableAlphaIMG : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void disableImg()
    {
        image.enabled = false;
    }
}
