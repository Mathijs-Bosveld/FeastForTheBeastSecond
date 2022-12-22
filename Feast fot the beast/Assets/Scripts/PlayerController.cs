using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    SpriteRenderer spriteRenderer;
    public Sprite playerSpriteFront;
    public Sprite playerSpriteBack;
    public Sprite playerSpriteSide;

    Vector3 left = new Vector3 (-1,1,1);
    Vector3 Right = new Vector3 (1,1,1);

    private string horizontalName;
    private string verticalName;
    private string interactName;

    float horizontal;
    float vertical;

    private float speed = 5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Playerchecker(transform);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalName);
        vertical = Input.GetAxisRaw(verticalName);

        if(horizontal > 0)
        {
            spriteRenderer.sprite = playerSpriteSide;
            transform.localScale = Right;
        } else if(horizontal < 0)
        {
            spriteRenderer.sprite = playerSpriteSide;
            transform.localScale = left;
        } else if(vertical > 0)
        {
            spriteRenderer.sprite = playerSpriteBack;
        } else if(vertical < 0)
        {
            spriteRenderer.sprite = playerSpriteFront;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public string Playerchecker(Transform playerTransform)
    {
        if (transform.name == "Player1")
        {
            horizontalName = "HorizontalPlayer1";
            verticalName = "VerticalPlayer1";
            interactName = "InteractPlayer1";
        }
        else
        {
            horizontalName = "HorizontalPlayer2";
            verticalName = "VerticalPlayer2";
            interactName = "InteractPlayer2";
        }

        return interactName;
    }
}
