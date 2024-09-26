using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public Text txt;

    public Color AlertColor = Color.red;
    Color startColor;

    public float alert = 25f;
    private double Val;
    private float val;

    // Start is called before the first frame update
    void Start()
    {
        startColor = bar.color;
        Val = 100;
    }

    public void UpdateValue() {
        Val-=.01;
        val = (int)Val;
        txt.text = val + "%"; // Changed from txt.Text to txt.text
        
        bar.fillAmount = val / 100;
        if(Val<=0){
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;  
            #else 
                Application.Quit();
            #endif       
        }
        if(Val<=alert){
            bar.color = AlertColor;
        }
        else{
            bar.color = startColor;
        }
    }
}
