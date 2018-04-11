using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           //unity de texti eklerken ekledik bunu scriptte kullanabilmek icin
using UnityEngine.SceneManagement;     // button u kontrol etme

public class UiManager : MonoBehaviour {

    public static UiManager instance;           //bu scripteki fonksiyonlara filan baska yerlerden ulasmak icin 

    public GameObject zigzagPanel;
    public GameObject gameoverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text level;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        highScore1.text = "High Score: "+ PlayerPrefs.GetInt("highScore").ToString();
    }


    public void GameStart()
    {
        if(!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 1);
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
        tapText.SetActive(false);           //oyun basladiginda tap to start yazmasin diye
        zigzagPanel.GetComponent<Animation>().Play("PanelUp");

    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        if (PlayerPrefs.GetInt("score") > 99)
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        level.text = PlayerPrefs.GetInt("level").ToString();
        gameoverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
