using UnityEngine;

public class StatePlayer : MonoBehaviour
{
    #region Animation
    private Animator _animator;
    private int _runHash = Animator.StringToHash("IsRun");
    private int _victoryHash = Animator.StringToHash("Victory");
    private int _numbnessHash = Animator.StringToHash("Numbness");
    #endregion

    void Start()
    {
        _animator = GetComponent<Animator>();
        //Events
        Door.OpenDoorWrong += PlayAnimationNumbness;
        PlayerCollider.Finish += PlayAnimationVictory;
        MovePlayer.Move += PlayAnimationMove;
        MovePlayer.StopMove += StopAnimationMove;
    }

    private void PlayAnimationMove()
    {
        _animator.SetBool(_runHash, true);
    }

    private void StopAnimationMove()
    {
        _animator.SetBool(_runHash, false);
    }

    private void PlayAnimationNumbness()
    {
        _animator.SetTrigger(_numbnessHash);
    }

    private void PlayAnimationVictory()
    {
        _animator.SetBool(_victoryHash, true);
    }


}
