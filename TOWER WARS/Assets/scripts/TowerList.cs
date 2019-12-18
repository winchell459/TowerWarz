using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerList : MonoBehaviour
{
    public int TowerCount = 5;
    public enum Towers
    {
        Scout,
        Hunter,
        Camper,
        Fraggiler,
        Bank
    }
    public List<Towers> TowersList = new List<Towers>();
    // Start is called before the first frame update
    void Start()
    {
         if(FindObjectsOfType<TowerList>().Length > 1){

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        TowersList.Add(Towers.Scout);
        TowersList.Add(Towers.Hunter);
        TowersList.Add(Towers.Camper);
        TowersList.Add(Towers.Fraggiler);
        TowersList.Add(Towers.Bank);
    }

   public void AddTowerToList(Towers tower)
    {
        if(TowersList.Count < TowerCount && !TowersList.Contains(tower))
        {
            TowersList.Add(tower);
        }
    }
    public void ClearTowerList()
    {
        TowersList.Clear();
    }
}
