using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject winnerText;
    private TextMeshProUGUI winnerTextMesh;

    public string winningPlayer;
    public void Winscreen()
    {
        winnerTextMesh = winnerText.GetComponent<TextMeshProUGUI>();
        winnerTextMesh.text = winningPlayer + " wins!!";

        winScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
