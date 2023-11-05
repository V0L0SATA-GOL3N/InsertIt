using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject panel;
    public Button retry;
    public Button returntomenu;
    // Start is called before the first frame update
    public void Start(){
        retry.onClick.AddListener(restartgame);
        returntomenu.onClick.AddListener(returntomenu1);
    }
    public void restartgame(){
        panel.SetActive(true);
        SceneManager.LoadScene(1);
    }
    public void returntomenu1(){
        panel.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
