using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Target;
    public float FireRate;
    public int FirePower;
    public float Range = 3;
    private float lastAttack = 0;
    public enum AttackType
    {
        Individual, 
        Area,
        Cone
    }
    public AttackType TowerAttack;
    // Update is called once per frame
    void Update()
    {
        if (!Target) Target = FindObjectOfType<ZombieSpawner>().GetNextZombie(null);
        if (Target)
        {
            bool done = false;
            if (Vector3.Distance(transform.position, Target.transform.position) < Range) done = true;
            while (!done)
            {
                Target = FindObjectOfType<ZombieSpawner>().GetNextZombie(Target);
                if (Target)
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) < Range)
                        done = true;
                    else
                    {
                        done = true;
                    }
                }
            }
            if (Target) transform.LookAt(Target.transform);

            if(TowerAttack == AttackType.Individual)
            {
                if(FireRate + lastAttack < Time.fixedTime && Target)
                {
                    Target.GetComponent<Enemy>().TakeDamage(FirePower);
                    lastAttack = Time.fixedTime;
                }
            }
           


        }

    }
}
