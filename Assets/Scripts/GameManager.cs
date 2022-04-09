using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
         if (Instance != null) {
            Destroy(this.gameObject);
            return;
        }
        
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        this.restartButton.gameObject.SetActive(false);
        this.exitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGameOver()
    {
        this.restartButton.gameObject.SetActive(true);
        this.exitButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        StartCoroutine(this.RestartGameCoroutine());
    }

    private IEnumerator RestartGameCoroutine()
    {
        this.restartButton.gameObject.SetActive(false);
        this.exitButton.gameObject.SetActive(false);
        this.GetComponent<EnemySpawner>().Clean();
        yield return new WaitForSeconds(2);
        this.player.GetComponent<PlayerControl>().Respawn();
        this.GetComponent<EnemySpawner>().SpawnWave();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
