using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image bar;
    public Text txt;

    public Color AlertColor = Color.red;
    Color startColor;

    public float alert = 25f;
    public ClaireController claire;
    private double Val;
    private float val;
    private bool run=false;

    // Start is called before the first frame update
    void Start() {
        startColor = bar.color;
        Val = 100;
    }

    public void UpdateValue() {
        Val -= .01;
        val = (int)Val;
        txt.text = val + "%"; // Changed from txt.Text to txt.text

        bar.fillAmount = val / 100;
        if (Val <= 0) {
            if(!run){
                claire.ClaireDead();
                run=true;
            }
        }
        if (Val <= alert) {
            bar.color = AlertColor;
        } else {
            bar.color = startColor;
        }
    }

    // Method to decrease health
    public void DecreaseHealth(float amount) {
        Val -= amount;
        if (Val < 0) Val = 0; // Ensure health doesn't go below 0
        UpdateValue(); // Update health bar
    }
}
