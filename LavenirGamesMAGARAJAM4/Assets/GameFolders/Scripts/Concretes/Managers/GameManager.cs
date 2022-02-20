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
        public event System.Action<bool> OnSceneChanged;
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
            OnSceneChanged?.Invoke(false);
        }

        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
        }

        private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("MenuGiris");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(true);
        }

        public void ExitGame()
        {
            Debug.Log("Exitbutton triggered");
            Application.Quit();
        }

        public void LoadSuperUltraSplashScene(float delayLoadingTime)
        {
            StartCoroutine(LoadSuperUltraPowerSplashScene(delayLoadingTime));
        }

        private IEnumerator LoadSuperUltraPowerSplashScene(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Level2Secim");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(false);



        }




    }
}
