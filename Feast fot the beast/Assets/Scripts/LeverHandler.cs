using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandler : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    string interactName;

    float leverPullRate = .5f;
    float leverPulled;

    [SerializeField]
    GameObject wallBlocker;
    GameObject wall;

    Vector3 blockLocation;


    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        SpawnBlocker();

        AstarPath.active.Scan();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactName = other.GetComponent<PlayerController>().Playerchecker(other.transform);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetAxis(interactName) != 0 && Time.time > leverPulled)
        {
            if (spriteRenderer.flipY == true)
            {
                spriteRenderer.flipY = false;
                wall.SetActive(true);
            }
            else
            {
                spriteRenderer.flipY = true;
                wall.SetActive(false);
            }

            AstarPath.active.Scan();

            leverPulled = Time.time + leverPullRate;
        }
    }

    private void SpawnBlocker()
    {
        blockLocation = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);

        RaycastHit2D hit = Physics2D.Raycast(blockLocation, -Vector2.up);

        if (hit.collider.tag == "Untagged")
        {
            wall = Instantiate(wallBlocker, blockLocation, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            SpawnBlocker();
        }
    }
}
