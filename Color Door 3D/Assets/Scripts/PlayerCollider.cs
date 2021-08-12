using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public delegate void Player();
    public static event Player Finish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Коснулись стены!");
        }

        if (other.CompareTag("Finish"))
        {
            Finish?.Invoke();
            Debug.Log("Стоп, финиш!");
        }
    }
}
