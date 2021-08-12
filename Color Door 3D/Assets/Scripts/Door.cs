using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [Tooltip("True - если дверь правильная")]
    [SerializeField] private bool _isRightDoor;
    private Animator _animator;

    #region Events
    public delegate void OpenDoorDelegate();
    public static event OpenDoorDelegate OpenDoorWrong;

    public UnityEvent WrongEvent;
    #endregion

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (!_isRightDoor)
        {
            //called event
            OpenDoorWrong?.Invoke();
            WrongEvent.Invoke();
        }
        StartAnimation();
    }

    private void StartAnimation()
    {
        if (_isRightDoor)
        {
            PlayAnimationRightDoor();   
        }
        else
        {
            PlayAnimationWrongDoor();
        }
    }

    private void PlayAnimationRightDoor()
    {
        _animator.SetTrigger("OpenRightDoor");
    }

    private void PlayAnimationWrongDoor()
    {
        _animator.SetTrigger("OpenWrongDoor");
    }
}
