using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSpawner : MonoBehaviour
{
    int leverCount;
    int levers = 0;

    [SerializeField]
    GameObject lever;

    Vector3 leverLocation;

    // Start is called before the first frame update
    void Start()
    {
        leverCount = Random.Range(3, 7);

        while (levers < leverCount)
        {
            SpawnLever();

            levers++;
        }
    }

    private void SpawnLever()
    {
        leverLocation = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);

        RaycastHit2D hit = Physics2D.Raycast(leverLocation, -Vector2.up);

        if (hit.collider.tag == "Untagged")
        {
            Instantiate(lever, leverLocation, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            SpawnLever();
        }
    }
}
