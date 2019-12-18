using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 8;
    public void TakeDamage(int attack)
    {
        HP -= attack;

        if(HP <= 0)
        {
            die();
        }
    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("HumanBase"))
        {
            Debug.Log("OOffF..." + " " + collision.gameObject.name);
            collision.gameObject.GetComponent<HumanBase>().POW(HP);
            HP = 0;

            die();
        }
    }
    private void die()
    {
        FindObjectOfType<ZombieSpawner>().ZombieDeath(gameObject);
        Destroy(gameObject);
    }
}
