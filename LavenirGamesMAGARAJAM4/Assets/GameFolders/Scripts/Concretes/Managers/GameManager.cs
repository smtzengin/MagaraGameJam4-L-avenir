using LavenirGamesMAGARAJAM4.Uis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavenirGamesMAGARAJAM4.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float delayLevelTime = 1f;

        public static GameManager Instance { get; private set; }
        public int buildIndex;

        private void Awake()
        {
            SingletonGameObject();
        }

        private void SingletonGameObject()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }
        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);
            
            buildIndex = SceneManager.GetActiveScene().buildIndex;
            

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };

        }
        
        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));

        }

        private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

        }

        public void ExitGame()
        {
            Debug.Log("Exit button triggered");
            Application.Quit();
        }

        public void LoadSuperUltraSplashScene(float delayLoadingTime)
        {
            StartCoroutine(LoadSuperUltraPowerSplashScene(delayLoadingTime));
        }

        private IEnumerator LoadSuperUltraPowerSplashScene(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.UnloadSceneAsync(10);
            yield return SceneManager.LoadSceneAsync("Level2Secim", LoadSceneMode.Additive);
            
        }

        private void Update()
        {
            print(buildIndex);
        }






    }
}
