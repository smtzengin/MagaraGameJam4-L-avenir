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
            float buildIndex = SceneManager.GetActiveScene().buildIndex;
            if (buildIndex %2 == 0)
            {
                GameManager.Instance.LoadScene(-2);
            }
            else if (buildIndex % 2 == 1)
            {
                
                GameManager.Instance.LoadScene(-1);
            }

        }
        public void HighSpeedButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void LowSpeedButtonClick()
        {
            GameManager.Instance.LoadScene(2);
        }

        


    }
}
