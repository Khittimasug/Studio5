using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChronoSkill : MonoBehaviour
{
    public GameObject chronoX2;
    public GameObject chronoX3;
    void Start()
    {
        chronoX2 = GameObject.Find("Global Volume2").gameObject;
        chronoX3 = GameObject.Find("Global Volume3").gameObject;
    }

    public void openChrono()
    {
        chronoX2.SetActive(false);
        chronoX3.SetActive(true);
    }

    public void openChoro2()
    {
        chronoX3.SetActive(false);
        chronoX2.SetActive(true);
    }
}
