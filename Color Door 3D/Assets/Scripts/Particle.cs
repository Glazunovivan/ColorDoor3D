using UnityEngine;

public class Particle : MonoBehaviour
{
    [Tooltip("Врезались в дверь")]
    [SerializeField] private ParticleSystem _burnInto;

    [Tooltip("Дверь упала")]
    [SerializeField] private ParticleSystem _fall;

    private void Awake()
    {
        if (_burnInto == null)
        {
            Debug.LogError("Эффект удара в дверь не назначен");
        }
        if(_fall == null)
        {
            Debug.LogError("Эффект падения двери не назначен");
        }
    }


    public void PlayBurnInto()
    {
        _burnInto.Play();
    }

    public void PlayFall()
    {
        _fall.Play();
    }

    public void SetTransform(Vector3 targetPosition)
    {
        _burnInto.transform.position = targetPosition;
        _fall.transform.position = targetPosition;
    }
}
