using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]  // Attribut correctement écrit
    private int startCountDown = 60;

    [SerializeField]  // Attribut correctement écrit
    private Text TxtCountDown;

    [SerializeField] private EnergyBar _EnergyBar;
    [SerializeField] private FoodBar _FoodBar;

    // Start is called before the first frame update
    void Start()
    {
        TxtCountDown.text = "TimeLeft : " + startCountDown;
        StartCoroutine(Pause());
    } 

    IEnumerator Pause()
    {
        while (startCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            startCountDown--;
            TxtCountDown.text = "TimeLeft : " + startCountDown;
            _EnergyBar.UpdateValue();
            _FoodBar.UpdateValue();
        }
        
    }
}
