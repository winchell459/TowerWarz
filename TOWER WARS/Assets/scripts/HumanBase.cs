using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanBase : MonoBehaviour
{
    public int HP = 100;
    public GameObject DEATHSCREEN;
    public void POW(int attack) {
        HP -= attack;
        Debug.Log("Human Base has " + HP + " HP left.");
        if (HP <= 0) {
            DEATHSCREEN.SetActive(true);
            Debug.Log("U died u noob 101011100 WaVe InFinEtY Is CoMiNG foR U, NoOb MaBey NeXt tIMe NoOb");

        }


    }
    public void loadMandM()
    {
        SceneManager.LoadScene(0);
    }
}
