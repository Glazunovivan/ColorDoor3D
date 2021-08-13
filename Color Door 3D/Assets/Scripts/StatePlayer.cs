using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StatePlayer : MonoBehaviour
{
    #region Animation
    private Animator _animator;
    private int _runHash = Animator.StringToHash("IsRun");
    private int _victoryHash = Animator.StringToHash("Victory");
    private int _numbnessHash = Animator.StringToHash("Numbness");
    #endregion

    private MovePlayer _movePlayer;

    void Start()
    {
        _movePlayer = FindObjectOfType<MovePlayer>();
        _animator = GetComponent<Animator>();
        //Events
        /*Door.OpenDoorWrong += PlayAnimationNumbness;
        PlayerCollider.Finish += PlayAnimationVictory;
        MovePlayer.Move += PlayAnimationMove;
        MovePlayer.StopMove += StopAnimationMove;*/
    }

    public void PlayAnimationMove()
    {
        //_movePlayer.StartRun();
        _animator.SetBool(_runHash, true);
    }

    public void StopAnimationMove()
    {
        //_movePlayer.StopRun();
        _animator.SetBool(_runHash, false);
    }

    public void PlayAnimationNumbness()
    {
        _animator.SetTrigger(_numbnessHash);
    }

    public void PlayAnimationVictory()
    {
        //_movePlayer.StopRun();
        _animator.SetBool(_victoryHash, true);
    }


}
