using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuilder will load the Scene with a single node
        SceneManager.LoadScene("From-the-ShadowsNew", LoadSceneMode.Single);
    }
}
