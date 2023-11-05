using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;
using JetBrains.Annotations;
using TMPro;

public class ButtonScript : MonoBehaviour
{

    public ObjectMovement objectMovement;
    public GameObject panel;
    public GameObject popa;
    public GameObject penis;
    public GameObject terrain;
    public Button button;
    public Text text;
    public AudioClip[] aux;
    public AudioSource auxtixon;
    private int score = 0;
    public int status = 0;
    public TMP_Text coins;
    public int coinscout;
    public float oldspeed1;
    public GameObject grob;
    void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
        penis.SetActive(true);
        if(!PlayerPrefs.HasKey("coins")){
            PlayerPrefs.SetInt("coins",0);
            PlayerPrefs.Save();
        }
        coinscout = PlayerPrefs.GetInt("coins");
        coins.text = coinscout.ToString();
	}

    public void OnButtonClick()
    {
        oldspeed1 = objectMovement.speed;
        GameObject pisun = GameObject.FindWithTag("pisun");
        objectMovement = pisun.GetComponent<ObjectMovement>();
        objectMovement.moveRight = false;
        objectMovement.moveUp = true;
        if(objectMovement.transform.position.x>=213.28 & objectMovement.transform.position.x<=213.8) {
            objectMovement.speed = 3f;
            auxtixon.PlayOneShot(aux[0]);
            score +=1;
            coinscout+=10;
            PlayerPrefs.SetInt("coins",coinscout);
            PlayerPrefs.Save();
            coins.text = coinscout.ToString();
            text.text = score + "";
        }
        else{
            IEnumerator lose(){ 
                if (pisun!=null){
                objectMovement.speed = 3f;
                pisun = GameObject.FindWithTag("pisun");
                yield return new WaitForSeconds(0.5f);
                //sound of lose
                pisun.SetActive(false);
                auxtixon.PlayOneShot(aux[1]);
                yield return new WaitForSeconds(1.5f);
                grob.SetActive(false);
                popa.SetActive(false);
                terrain.SetActive(false);
                panel.SetActive(true);
                SceneManager.LoadScene(2);
                }
            }
            StartCoroutine(lose());
        }
    }
}