using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class attack : MonoBehaviour, IPointerDownHandler
{

    Transform m_wephone;
    Transform Master;
    Animator animator;
    Object effect;

    // Start is called before the first frame update
    void Start()
    {
        Master = GameObject.Find("Master").transform;
        m_wephone = Master.GetChild(0);
    
        effect = Resources.Load("PreFabs/Effect/AxsEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(m_wephone.localScale.x > 0)
        {
            m_wephone.transform.localPosition = new Vector3(0.27f, 0.39f,1);
            m_wephone.localScale = new Vector2(-1, -1);
            AtteckEffect(new Vector3(Master.transform.localPosition.x + m_wephone.transform.localPosition.x + 1, Master.localPosition.y+ m_wephone.transform.localPosition.y, -1));
        }
        else
        {
            m_wephone.transform.localPosition = new Vector3(-0.27f, -0.39f,1);
            m_wephone.localScale = new Vector2(1, 1);
            AtteckEffect(new Vector3(Master.transform.localPosition.x + m_wephone.transform.localPosition.x + 1, Master.localPosition.y + m_wephone.transform.localPosition.y, -1));
        }
    }
    private void AtteckEffect(Vector3 location)
    {
        if(Master.localScale.x < 0)
        {
            (effect as GameObject).transform.localScale = new Vector2(-1,-1);
        }
        else
        {
            (effect as GameObject).transform.localScale = new Vector2(1, 1);
        }

        Object effect_item = Instantiate(effect, location, Quaternion.identity);
        Destroy(effect_item, 0.5f);
    }
}
