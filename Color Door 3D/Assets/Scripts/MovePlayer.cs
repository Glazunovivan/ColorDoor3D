using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    // 0.6 - оптимальный вариант
    private float _speedSlide = 0.6f;
    private PathCreator _pathCreator;
    private float _distanceTravelled;

    [SerializeField] private bool _isRun = false;
    private FixedJoystick _joystick;
    private float _currentPositionZ;
    //private StatePlayer _statePlayer;

    //событие
    public delegate void State();
    public static State Move;
    public static State StopMove;


    private void Awake()
    {
        _pathCreator = FindObjectOfType<PathCreator>();
        _joystick = FindObjectOfType<FixedJoystick>();
        //_statePlayer = FindObjectOfType<StatePlayer>();
        PlayerCollider.Finish += StopRun;
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
        _distanceTravelled += _speed * Time.deltaTime;
        if (_joystick.Horizontal != 0)
        {
            _currentPositionZ = _joystick.Horizontal * _speedSlide;
        }
        transform.position = new Vector3(_pathCreator.path.GetPointAtDistance(_distanceTravelled).x,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).y,
                                         _pathCreator.path.GetPointAtDistance(_distanceTravelled).z + _currentPositionZ);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }

    public void StartRun()
    {
        _isRun = true;
        Move?.Invoke();
    }
    public void StopRun()
    {
        _isRun = false;
        StopMove?.Invoke();
    }
}
