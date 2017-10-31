using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

    public string targetSceneName;

    //unity complains if the parameter isn't there ¯\_(ツ)_/¯
    public void changeTheScene(bool whatever)
    {
        //Debug.Log("changing scene");
        SceneManager.LoadScene(targetSceneName);
    }

}
