using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameHandler : MonoBehaviour
{
    public Text CreditsText;
    private int credits;
    public string[] levels;
   
    // Start is called before the first frame update
    void Start()
    {
        if (CreditsText)
        {
            credits = PlayerPrefs.GetInt("Credits");
            CreditsText.text = credits.ToString();
            //SetCredit(99999);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartLevel(string level) {
        SceneManager.LoadScene(level);
    }
    public void StartRandomLevel()
    {
        int choice = Random.Range(0, levels.Length);
        StartLevel(levels[choice]);
    }


    private void SetCredit(int credits)
    {
        PlayerPrefs.SetInt("Credits", credits);
    }
    private void addTowerToPlayList(TowerList.Towers tower)
    {
        FindObjectOfType<TowerList>().AddTowerToList(tower);
    }
    public void ScoutTower()
    {
        int cost = 0;
        string towerKey = "ScoutTower";
        if (PlayerPrefs.GetInt(towerKey) == 1)
        {
            addTowerToPlayList(TowerList.Towers.Scout);
        }
        else
        {
            if (cost <= credits)
            {
                credits -= cost;
                SetCredit(credits);
                PlayerPrefs.SetInt(towerKey, 1);
            }
        }
    }

    public void HunterTower()
    {
        int cost = 300;
        string towerKey = "HunterTower";
        if (PlayerPrefs.GetInt(towerKey) == 1)
        {
            addTowerToPlayList(TowerList.Towers.Hunter);
        }
        else
        {
            if (cost <= credits)
            {
                credits -= cost;
                SetCredit(credits);
                PlayerPrefs.SetInt(towerKey, 1);
            }
        }
    }
}
