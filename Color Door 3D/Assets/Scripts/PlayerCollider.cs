using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public delegate void Player();
    public static event Player Finish;
    private StatePlayer _statePlayer;
    private MovePlayer _movePlayer;
    private Game _game;

    private void Start()
    {
        _movePlayer = FindObjectOfType<MovePlayer>();
        _statePlayer = FindObjectOfType<StatePlayer>();
        _game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Коснулись стены!");
            //перезагрузка
            //_game.HitTheWall();
            //_movePlayer.StopRunIntoObstacle();
            //_statePlayer.StopAnimationMove();
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Финиш");
            _game.Finish();
            _movePlayer.StopRun();
            _statePlayer.PlayAnimationVictory();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Obstacle")){
            Debug.Log("Коснулись стены!");
            _movePlayer.StopRunIntoObstacle();
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.collider.CompareTag("Obstacle")){
            Debug.Log("Ушли от стены!");
            _movePlayer.StartRun();
        }
    }
}
