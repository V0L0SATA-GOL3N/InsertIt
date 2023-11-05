using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data.Common;
// using UnityEngine.UIElements;

public class changepenis : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public Button button;
    public Button button2;
    public Button savebutton;
    public GameObject pen;
    public GameObject pen2;
    public GameObject pen3;
    public GameObject loadingscreen;
    public Renderer rend;
    public Renderer rend2;
    public Renderer rend3;
    private int coins;
    public TMP_Text coinstext;
    public int num =0;
    public int SkinCount= 0;
    public Material[] listofmat;
    public string[] dickname;
    public int[] skincost;
    private int middlechlen;
    public TMP_Text dicktext;
    public GameObject buybutton;
    public GameObject savebutton1;
    public TMP_Text buybuttontext;
    public Button buybuttonlistener;
    [SerializeField]private int realtimeskincout;

    private void Start() {
        button.onClick.AddListener(right);
        button2.onClick.AddListener(left);
        savebutton.onClick.AddListener(save);
        buybuttonlistener.onClick.AddListener(buy);
        rend = pen.GetComponent<MeshRenderer>();
        rend2 = pen2.GetComponent<MeshRenderer>();
        rend3 = pen3.GetComponent<MeshRenderer>();
        SkinCount = listofmat.Length;
        coins = PlayerPrefs.GetInt("coins");
        coinstext.text = coins.ToString();
        middlechlen = SkinCount/2;
        if (!PlayerPrefs.HasKey("realtimeskincout")){
            PlayerPrefs.SetInt("realtimeskincout",-4);
            PlayerPrefs.SetInt("skin0",0); //not a skin
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
            PlayerPrefs.Save();
        }
        realtimeskincout=PlayerPrefs.GetInt("realtimeskincout");
        dicktext.text =dickname[middlechlen+realtimeskincout];
        rend2.material=listofmat[middlechlen+realtimeskincout];
        rend.material = listofmat[middlechlen-1+realtimeskincout];
        rend3.material = listofmat[middlechlen+1+realtimeskincout];
    }
    public void right() {
        IEnumerator right1(){
        if (realtimeskincout>=-(middlechlen/2+1)){
        realtimeskincout-=1;
        dicktext.text =dickname[middlechlen+realtimeskincout];
        if(PlayerPrefs.GetInt("skin"+(middlechlen+realtimeskincout).ToString())==0){
            savebutton1.SetActive(false);
            buybutton.SetActive(true);
            buybuttontext.text=skincost[middlechlen+realtimeskincout].ToString();
        }
        else{
            savebutton1.SetActive(true);
            buybutton.SetActive(false);
        }
        anim.SetTrigger("right");
        anim2.SetTrigger("right2");
        yield return new WaitForSeconds(0.25f);
        rend2.material = listofmat[middlechlen+realtimeskincout];
        rend.material = listofmat[middlechlen+realtimeskincout-1];
        rend3.material = listofmat[middlechlen+realtimeskincout+1];
        }
    }
        StartCoroutine(right1());
    }
public void left(){
    IEnumerator left1(){
        if(realtimeskincout<=(middlechlen/2+1)){
            realtimeskincout+=1;
            dicktext.text =dickname[middlechlen+realtimeskincout];
            if(PlayerPrefs.GetInt("skin"+(middlechlen+realtimeskincout).ToString())==0){
            savebutton1.SetActive(false);
            buybutton.SetActive(true);
            buybuttontext.text=skincost[middlechlen+realtimeskincout].ToString();
        }
            else{
                savebutton1.SetActive(true);
                buybutton.SetActive(false);
            }
            anim2.SetTrigger("left2");
            anim3.SetTrigger("left3");
            yield return new WaitForSeconds(0.25f);
            rend2.material = listofmat[middlechlen+realtimeskincout];
            rend.material = listofmat[middlechlen+realtimeskincout-1];
            rend3.material = listofmat[middlechlen+realtimeskincout+1];
        }
    }
    StartCoroutine(left1());
}
public void save(){
    PlayerPrefs.SetInt("realtimeskincout", realtimeskincout);
    PlayerPrefs.Save();
    dicktext.text = "";
    loadingscreen.SetActive(true);
    pen.SetActive(false);
    pen2.SetActive(false);
    pen3.SetActive(false);
    SceneManager.LoadScene(0);
}
public void buy(){
    coins = PlayerPrefs.GetInt("coins");
    if (coins>=skincost[middlechlen+realtimeskincout]){
        coins-=skincost[middlechlen+realtimeskincout];
        coinstext.text = coins.ToString();
        PlayerPrefs.SetInt("skin"+(middlechlen+realtimeskincout).ToString(),1);
        PlayerPrefs.SetInt("coins",coins);
        PlayerPrefs.Save();
        buybutton.SetActive(false);
        savebutton1.SetActive(true);
    }
    else{
        IEnumerator buyfalse(){
            buybuttontext.text = "no money";
            yield return new WaitForSeconds(2);
            buybuttontext.text = skincost[middlechlen+realtimeskincout].ToString();
        }
        StartCoroutine(buyfalse());
    }
}
public void Update(){
    pen2.transform.Rotate(0,-40*Time.deltaTime,0);
    pen.transform.Rotate(0,-40*Time.deltaTime,0);
    pen3.transform.Rotate(0,-40*Time.deltaTime,0);
}
}