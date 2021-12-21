using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class managerJoystick : MonoBehaviour, IDragHandler , IPointerDownHandler, IPointerUpHandler
{
    private Image imgJoyBg;
    private Image imgJoy;
    private Vector2 posInput;
    public Transform dumen;

    void Start()
    {
        imgJoyBg = GetComponent<Image>();
        imgJoy = transform.GetChild(0).GetComponent<Image>();
    }
    
    void Update()
    {
        //1- tekne içerisindeki dümen, joysticke bağlı sağa kaydırılırsa sağ, sola kayrırılsa sola dönecek
        Vector3 dumenRot = new Vector3(100,0,0);
            if (posInput.x > 0)
        {
           dumen.transform.Rotate(-dumenRot*Time.deltaTime);

        }
            else if (posInput.x < 0)
        {
            dumen.transform.Rotate(dumenRot * Time.deltaTime);
        }
        else
        {
            dumen.transform.Rotate(0,0,0);
        }
        //1   
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoyBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput))
        {
            //mouse pozisyonu, joystick ile entegre edildi
            posInput.x = posInput.x / (imgJoyBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (imgJoyBg.rectTransform.sizeDelta.y);

         

            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            imgJoy.rectTransform.anchoredPosition = new Vector2(
            posInput.x * (imgJoyBg.rectTransform.sizeDelta.x /2),
            posInput.y * (imgJoyBg.rectTransform.sizeDelta.y /2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        imgJoy.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        //joystick mouse pozisyonuna göre : Horizontal
        if(posInput.x !=0)
        {
            return posInput.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float inputVertical()
    {
        //joystick mouse pozisyonuna göre : Vertial
        if (posInput.y != 0)
        {
            return posInput.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
