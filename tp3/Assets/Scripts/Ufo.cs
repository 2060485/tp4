using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ufo : MonoBehaviour
{

    public GameObject canvas;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)&& canvas.activeSelf){
            Debug.Log("teest");
            SceneManager.LoadScene("Level2");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        
        // Vérifiez si l'objet qui est entré dans le trigger a le tag "Player"
        if ((other.CompareTag("Player")))
        {


            // Exécutez l'action souhaitée, par exemple afficher un message
            Debug.Log("Le ufo");
            canvas.SetActive(true);
            
            
        }
        }
}
