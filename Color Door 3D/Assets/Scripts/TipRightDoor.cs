using System.Collections;
using UnityEngine;

public class TipRightDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] _iconsRightDoor;
    [SerializeField] private float _waitSeconds = 1f;
    private int _hashDoorRight = Animator.StringToHash("Right door_appear");

    public bool IsAllowedToPlay = false;

    private void Start()
    {
        StartCoroutine(StartAnimation());    
    }

    private IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(1);
        foreach (var icon in _iconsRightDoor)
        {           
            icon.gameObject.SetActive(true);
            icon.GetComponent<Animator>().Play(_hashDoorRight);
            yield return new WaitForSeconds(_waitSeconds);
            icon.gameObject.SetActive(false);
        }
        IsAllowedToPlay = true;
    }
}
