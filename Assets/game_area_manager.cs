using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class game_area_manager : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{

    public GameObject m_input;
    public GameObject m_pane_manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if( m_input.activeSelf )
        {
            GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.4f);
        }
        else
        {
            GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        }

        m_down = Input.GetMouseButton(0);

        if( m_in && m_down && !m_start_no_in )
        {
            OnButtonInArea();
        }

        if( !m_down )
        {
            OnNoButtonInArea();

            m_start_no_in = false;
        }
	}

    void OnButtonInArea()
    {
        m_pane_manager.GetComponent<cross_word_pazzle_move>().setIsMove(true);
    }

    void OnNoButtonInArea()
    {
        m_pane_manager.GetComponent<cross_word_pazzle_move>().setIsMove(false);
    }

    bool m_in = false;
    bool m_down = false;
    bool m_start_no_in = false;
/*
    public void OnMove(PointerEventData eventData)
    {
        if (m_down)
        {
            m_start_no_in = true;
        }

        m_in = true;
    }
*/
    public void OnPointerDown(PointerEventData eventData)
    {
        if( m_down )
        {
            m_start_no_in = true;
        }

        m_in = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_in = false;
    }
}
