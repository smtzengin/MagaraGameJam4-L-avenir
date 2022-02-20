using LavenirGamesMAGARAJAM4.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavenirGamesMAGARAJAM4.Uis
{ 
    public class MenuPanel : MonoBehaviour
    {
        public void PlayButtonClick()
        {
            GameManager.Instance.LoadScene(2);
        }
        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
        public void RestartButtonClick()
        {
            if (GameObject.Find("DogrulukObjesi").gameObject.GetComponent<DogrulukKontrolcusu>().dogruSecim == true)
            {
                GameManager.Instance.LoadScene(-1);
            }
            else
            {
                GameManager.Instance.LoadScene(-2);
            }
        }
        public void FirstButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void SecondButtonClick()
        {
            GameManager.Instance.LoadScene(2);
        }

        public void FakeButtonClick()
        {
            GameManager.Instance.LoadScene(2);
            GameManager.Instance.LoadSuperUltraSplashScene(5f);

        }

      

        
    }
}
