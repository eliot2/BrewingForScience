﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour {

    public GameObject[] MyTips;
    private bool[] myTipsEnabled;
    public Image CoverPanel;

	// Use this for initialization
	void Start () {
        myTipsEnabled = new bool[MyTips.Length];
        for(int x = 0; x < myTipsEnabled.Length; x++)
        {
            myTipsEnabled[x] = false;
            MyTips[x].SetActive(false);
        }
        CoverPanel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Static Functions
    public static void Spawn(int tipNum)
    {
        GameObject.FindGameObjectWithTag("Tips").GetComponent<Tips>()._spawn(tipNum);
    }
    #endregion

    #region Helper Functions
    private void _spawn(int tipNum)
    {
        if (myTipsEnabled[tipNum])
            return;
        myTipsEnabled[tipNum] = true;
        MyTips[tipNum].SetActive(true);
        //Pause Game
        PauseHandler.PauseGame();
        //Enable panel raycast.
        CoverPanel.enabled = true;
    }
    #endregion
}