using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    private int _countWrongDoor;

    [SerializeField] private GameObject _tip;
    [SerializeField] private GameObject _fail;
    [SerializeField] private GameObject _complete;

    private MovePlayer _player;
    private bool _isGaming;

    private void Awake()
    {
        //подписка на событие
        Door.OpenDoorWrong += IncrementCountWrongDoor;
        //инициализируем счетчик неправильных дверей
        _countWrongDoor = 0;

        _fail.SetActive(false);
        _complete.SetActive(false);
        
        DisplayTip();
        PlayerCollider.Finish += Finish;
        _player = FindObjectOfType<MovePlayer>();
        _isGaming = false;
    }

    private void Update()
    {
        if (!_isGaming)
        {
            if(Input.GetMouseButtonDown(0))
            {
                CloseTip();
            }          
        }
    }

    private void DisplayTip()
    {
        _tip.SetActive(true);
    }

    private void CloseTip()
    {
        _isGaming = true;
        _tip.SetActive(false);
        _player.StartRun();
    }

    private void EndGame()
    {
        Debug.Log("Конец игры");
        //запуск экрана перезагрузки
        _fail.SetActive(true);
        //остановка персонажа
        _player.StopRun();
    }

    private void Finish()
    {
        Debug.Log("Финиш!");
        _complete.SetActive(true);
        _player.StopRun();
    }

    private void IncrementCountWrongDoor()
    {
        if(_countWrongDoor == 2)
        {
            EndGame();
            return;
        }
        Debug.Log("Увеличили счетчик");
        _countWrongDoor++;
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        DisplayTip();
    }
}
