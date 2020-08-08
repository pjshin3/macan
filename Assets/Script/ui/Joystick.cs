using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick: MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform m_rectBack;
    RectTransform m_rectJoystick;

    Transform m_trCube;
    public float m_fRadius;
    public float m_fSpeed = 5.0f;
    public float m_fSqr = 0f;

    Vector3 m_vecMove;

    Vector2 m_vecNormal;

    bool m_bTouch = false;
    Animator animator;

    string direction = "";


    void Start()
    {
        m_rectBack = transform.Find("Joystickback").GetComponent<RectTransform>();
        m_rectJoystick = transform.Find("Joystickback/Joystick").GetComponent<RectTransform>();

        m_trCube = GameObject.Find("Master").transform;
        animator = GameObject.Find("Master").GetComponent<Animator>();


        // JoystickBackground의 반지름입니다.
        m_fRadius = m_rectBack.rect.width * 0.5f;
    }

    void Update()
    {
        if (m_bTouch)
        {
            animator.SetBool("move", true);
            if(direction == "Left")
            {
                m_trCube.localScale = new Vector3(-1, 1, 1);
            } else if(direction == "Right")
            {
                m_trCube.localScale = new Vector3(1, 1, 1);
            }
            m_trCube.position += m_vecMove;
        }
        else
        {
            animator.SetBool("move", false);
        }

    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - m_rectBack.position.x, vecTouch.y - m_rectBack.position.y);


        // vec값을 m_fRadius 이상이 되지 않도록 합니다.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        m_rectJoystick.localPosition = vec;

        // 조이스틱 배경과 조이스틱과의 거리 비율로 이동합니다.
        float fSqr = (m_rectBack.position - m_rectJoystick.position).sqrMagnitude / (m_fRadius * m_fRadius);

        // 터치위치 정규화
        Vector2 vecNormal = vec.normalized;

        if(vec.normalized.x > 1)
        {
            direction = "Left";
        }
        else
        {
            direction = "Right";
        }

        m_vecMove = new Vector3(vecNormal.x * m_fSpeed * Time.deltaTime * fSqr, vecNormal.y * m_fSpeed * Time.deltaTime * fSqr, 0f);
        //m_trCube.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        m_rectJoystick.localPosition = Vector2.zero;
        m_bTouch = false;
    }
}
