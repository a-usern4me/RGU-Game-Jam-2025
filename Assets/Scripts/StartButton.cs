using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StartButton : MonoBehaviour {

    void Start(){

    }

    void Update(){

    }

    public void onClick(){
        SceneManager.LoadScene ("SampleScene");
    }
}