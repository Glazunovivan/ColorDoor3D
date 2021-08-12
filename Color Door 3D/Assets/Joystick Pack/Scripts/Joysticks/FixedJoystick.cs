using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    //переопределим метод OnPointerUp, чтобы не сбрасывать позицию Handle 
    public override void OnPointerUp(PointerEventData eventData)
    {
    }
}