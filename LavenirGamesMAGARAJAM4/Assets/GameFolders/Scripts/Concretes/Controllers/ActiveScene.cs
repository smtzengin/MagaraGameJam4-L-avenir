using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveScene : MonoBehaviour
{
    void Update()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level2Secim"));
    }
}
