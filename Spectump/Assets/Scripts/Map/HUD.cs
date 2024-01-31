using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image speedBar;
    public float speedBarMax = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSpeedBar(float speed)
    {
        speedBar.fillAmount = speed / speedBarMax;
    }
}
