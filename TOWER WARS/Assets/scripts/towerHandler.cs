using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerHandler : MonoBehaviour
{
    public Camera cam;
    public Transform TowerPrefab;
    public Transform[] towerPrefabs;
    public float TowerSpacing = 2f;
    private List<Transform> towers = new List<Transform>();
    public LayerMask TowerMask;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, TowerMask))
            {
                if (!hit.transform.CompareTag("Panel"))
                {
                    bool dropable = true;
                    foreach (Transform tower in towers)
                    {
                        if (Vector3.Distance(tower.position, hit.point) < TowerSpacing)
                        {
                            dropable = false;
                        }
                    }
                    if (dropable)
                    {
                        Transform newTower = Instantiate(TowerPrefab, hit.point, Quaternion.identity);
                        towers.Add(newTower);
                    }
                }
            }
              

        }
    }
    public void Tower1Button()
    {
        TowerPrefab = towerPrefabs[(int)FindObjectOfType<TowerList>().TowersList[0]];
    }
    public void Tower2Button()
    {
        TowerPrefab = towerPrefabs[(int)FindObjectOfType<TowerList>().TowersList[1]];
    }
    public void Tower3Button()
    {
        TowerPrefab = towerPrefabs[(int)FindObjectOfType<TowerList>().TowersList[2]];
    }
    public void Tower4Button()
    {
        TowerPrefab = towerPrefabs[(int)FindObjectOfType<TowerList>().TowersList[3]];
    }
    public void Tower5Button()
    {
        TowerPrefab = towerPrefabs[(int)FindObjectOfType<TowerList>().TowersList[4]];
    }
}
