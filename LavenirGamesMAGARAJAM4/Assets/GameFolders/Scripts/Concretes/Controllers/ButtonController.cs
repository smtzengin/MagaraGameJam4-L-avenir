using LavenirGamesMAGARAJAM4.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool IsClick = false;
    [SerializeField] public GameObject menuPanel;

    private void Start()
    {
        IsClick = false;
    }
    public void PlayButtonClick()
    {
        if (!IsClick)
        {
            GameManager.Instance.LoadScene(2);
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
            menuPanel.gameObject.SetActive(false);
        }
    }
    public void ExitButtonClick()
    {
        if (!IsClick)
        {
            GameManager.Instance.ExitGame();
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
        }
    }
    public void RestartButtonClick()
    {
        if (!IsClick)
        {
            if (GameObject.Find("DogrulukObjesi").gameObject.GetComponent<DogrulukKontrolcusu>().dogruSecim == true)
            {
                GameManager.Instance.LoadScene(-1);
            }
            else
            {
                GameManager.Instance.LoadScene(-2);
            }
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
        }
    }
    public void FirstButtonClick()
    {
        if (!IsClick)
        {
            GameManager.Instance.LoadScene(1);
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
        }
    }
    public void SecondButtonClick()
    {
        if (!IsClick)
        {
            GameManager.Instance.LoadScene(2);
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
        }
    }

    public void FakeButtonClick()
    {
        if (!IsClick)
        {
            GameManager.Instance.LoadScene(2);
            GameManager.Instance.LoadSuperUltraSplashScene(5f);
            IsClick = true;
            StartCoroutine(ClickDelay(4f));
        }
    }
    public IEnumerator ClickDelay(float delayClickTime)
    {
        yield return new WaitForSeconds(delayClickTime);
        IsClick = false;
    }

    private void Update()
    {
        print(IsClick);
    }
}
