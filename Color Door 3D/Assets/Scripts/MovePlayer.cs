using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovePlayer : MonoBehaviour
{
    private PathCreator _pathCreator;
    private float _distanceTravelled;

    [SerializeField] private float _speed;
    [SerializeField] private bool _isRun = false;
    [SerializeField] private float _currentPositionZ;
    private StatePlayer _statePlayer;


    private void Start()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
        TransformPositionPlayer();
        _statePlayer = FindObjectOfType<StatePlayer>();
    }

    private void Update()
    {
        if (_isRun)
        {
            RunPlayer();
        }    
    }

    private void RunPlayer()
    {
        TransformPositionPlayer();
    }
    private void TransformPositionPlayer()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        transform.position = new Vector3(_pathCreator.path.GetPointAtDistance(_distanceTravelled).x,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).y,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).z);
    }

    public void StartRun()
    {
        _statePlayer.PlayAnimationMove();
        _isRun = true;
    }
    public void StopRun()
    {
        _statePlayer.StopAnimationMove();
        _isRun = false;
    }

}
