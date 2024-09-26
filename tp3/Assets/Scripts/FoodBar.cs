using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Image bar;
    public Text txt;

    public Color AlertColor = Color.red;
    Color startColor;

    public float alert = 25f;
    private float Val;

    // Start is called before the first frame update
    void Start()
    {
        startColor = bar.color;
        Val = 100;
    }

    public void AddEnergy() {
        Val+=10;
        if(Val>=90){
            Val=100;
        }
        txt.text = Val + "%"; // Changed from txt.Text to txt.text
        bar.fillAmount = Val / 100;
    }

    public void UpdateValue() {
        Val-=1;
        txt.text = Val + "%"; // Changed from txt.Text to txt.text
        bar.fillAmount = Val / 100;
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
