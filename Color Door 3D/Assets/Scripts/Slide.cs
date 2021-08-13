using UnityEngine;

public class Slide : MonoBehaviour
{
    private FixedJoystick _joystick;
    private float _speedSlide = 0.7f;
    private float _currentPositionX = 0;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
    }
    private void Update()
    {
        if (_joystick.Horizontal != 0)
        {
            _currentPositionX = _joystick.Horizontal * _speedSlide;
        }
        transform.localPosition = new Vector3(_currentPositionX, transform.localPosition.y, transform.localPosition.z);
    }
}
