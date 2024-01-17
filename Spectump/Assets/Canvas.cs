using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public TMPro.TMP_Text text;
    float time;

    public void Update()
    {
        time = Time.time;
        text.text = "Temps: " + time;
    }
}
