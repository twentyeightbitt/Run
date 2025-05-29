using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private AudioSource _audioSource;

    public int gameStatus = 2;
    void Start()
    {
        _menuScreen.SetActive(true);
        Time.timeScale = 0;
        _audioSource.Stop();
    }

    public void Play()
    {
        _menuScreen.SetActive(false);
        Time.timeScale = 1.0f;
        gameStatus = 2;
        _audioSource.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void LateUpdate()
    {
        if (gameStatus == 0) 
        {
            _loseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if(gameStatus == 1)
        {
            _winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
