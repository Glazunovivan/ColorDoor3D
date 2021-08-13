using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private FixedJoystick _joystick;
    private float _directionX;
    public float DirectionX
    {
        get
        {
           return _directionX;
        }
    }
    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        /*if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                _directionX = eventData.delta.x;
                Debug.Log("Двигаемся вправо на " + eventData.delta.x);
            }
            else
            {
                _directionX = eventData.delta.x;
                Debug.Log("Двигаемся вправо на " + eventData.delta.x);
            }
        }*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(eventData.delta.x);
    }
}
