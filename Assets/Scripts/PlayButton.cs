using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public Button but2;
    public Button but;
    public Button but3;
    public Button menuexit;
    public Button reset;
    public GameObject panel;
    public GameObject menupanel;
    public  GameObject pensil;
    public TMP_Text text;
    public int coins;
    // Start is called before the first frame update
    private void Start() {
        but2.onClick.AddListener(changepenis);
        but.onClick.AddListener(play);
        but3.onClick.AddListener(menu);
        reset.onClick.AddListener(reset1);
        menuexit.onClick.AddListener(exitmenu);
        if (!PlayerPrefs.HasKey("coins")){
            PlayerPrefs.SetInt("coins",0);
            PlayerPrefs.Save();
        }
        coins = PlayerPrefs.GetInt("coins");
        text.text = coins.ToString();
    }
    public void play(){
        panel.SetActive(true);
        pensil.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void changepenis(){
        panel.SetActive(true);
        pensil.SetActive(false);
        SceneManager.LoadScene(3);
    }
    public void menu(){
        pensil.SetActive(false);
        menupanel.SetActive(true);
    }
    public void exitmenu(){
        pensil.SetActive(true);
        menupanel.SetActive(false);
    }
    public void reset1(){
        PlayerPrefs.SetInt("coins",0);
        PlayerPrefs.SetInt("skin0",0);
        PlayerPrefs.SetInt("skin1",1);
        PlayerPrefs.SetInt("skin2",0);
        PlayerPrefs.SetInt("skin3",0);
        PlayerPrefs.SetInt("skin4",0);
        PlayerPrefs.SetInt("skin5",0);
        PlayerPrefs.SetInt("skin6",0);
        PlayerPrefs.SetInt("skin7",0);
        PlayerPrefs.SetInt("skin8",0);
        PlayerPrefs.SetInt("skin9",0);
        PlayerPrefs.SetInt("skin10",0);
        PlayerPrefs.SetInt("skin11",0);
        PlayerPrefs.SetInt("realtimeskincout",-5);
        PlayerPrefs.Save();
    }

}