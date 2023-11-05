using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class main : MonoBehaviour
{
    public int realtimeskincout;
    public Material[] mats;
    public Renderer rend;
    void Start()
    {
        realtimeskincout = PlayerPrefs.GetInt("realtimeskincout");
        rend.material = mats[(mats.Length/2)+realtimeskincout];
    }
}
