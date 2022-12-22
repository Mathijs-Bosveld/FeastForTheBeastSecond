using Pathfinding;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private AIDestinationSetter AIDestinationSetter;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    private Vector3 locationPlayer1;
    private Vector3 locationPlayer2;
    private Vector3 locationMonster;

    private float distancePlayer1;
    private float distancePlayer2;

    [SerializeField]
    private GameObject sceneManager;
    private GameEnd gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        gameEnd =  sceneManager.GetComponent<GameEnd>();
        AIDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        GetClosestPlayer();
    }

    void GetClosestPlayer()
    {
        //get player and monster positions
        locationPlayer1 = player1.transform.position;
        locationPlayer2 = player2.transform.position;
        locationMonster = gameObject.transform.position;

        //calculate distance to players
        distancePlayer1 = Vector3.Distance(locationPlayer1, locationMonster);
        distancePlayer2 = Vector3.Distance(locationPlayer2, locationMonster);

        //set closest player as target
        if (distancePlayer1 < distancePlayer2)
        {
            AIDestinationSetter.target = player1.transform;
        }
        else
        {
            AIDestinationSetter.target = player2.transform;
        }
    }

    //if player touches the mosnter
    void OnTriggerEnter2D(Collider2D other)
    {
        //player loses
        if (other.gameObject.tag == "Player")
        {
            if (other.name == "Player1")
            {
                gameEnd.winningPlayer = "player 2";
                gameEnd.Winscreen();
                player1.SetActive(false);
            }
            else
            {
                gameEnd.winningPlayer = "player 1";
                gameEnd.Winscreen();
                player2.SetActive(false);
            }
        }
    }
}