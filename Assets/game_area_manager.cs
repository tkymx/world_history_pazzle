using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class game_area_manager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

        if( m_in && m_down )
        {
            m_pane_manager.GetComponent<cross_word_pazzle_move>().setIsMove(true);
        }

        if( !m_down )
        {
            m_pane_manager.GetComponent<cross_word_pazzle_move>().setIsMove(false);
        }

        Debug.Log(m_down);

	}

    bool m_in = false;
    bool m_down = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_in = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_in = false;
    }
}
