using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneChanger : MonoBehaviour {

    public Toggle thisButton;
    public string targetSceneName;

    public void changeTheScene(bool whatever)
    {
        //Debug.Log("changing scene");
        SceneManager.LoadScene(targetSceneName);
    }

    void Start()
    {
        thisButton.onValueChanged.AddListener(changeTheScene);
    }

}
