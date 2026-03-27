using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int CoinCount;
    [SerializeField] TextMeshProUGUI coinCountUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        CoinTextUpdate();
    } 

    public void CoinCollect()
    {
        CoinCount += 1;
        Debug.Log(CoinCount);
        CoinTextUpdate();

        if(CoinCount >= 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void CoinTextUpdate()
    {
        coinCountUI.text = ("Coins: " + CoinCount.ToString());
    }
}
