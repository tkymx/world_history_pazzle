using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class input_button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string[] m_mojis = new string[5];

	// Use this for initialization
	void Start () {

        GetComponentInChildren<Text>().text = m_mojis[0];
	
	}

    bool m_area_down = false;

	// Update is called once per frame
	void Update () {

        m_down = Input.GetMouseButtonDown(0);
        m_up = Input.GetMouseButtonUp(0);

        if (m_in && m_down)
        {
            OnButtonInArea();

            m_area_down = true;
        }

        if ( m_up && m_area_down )
        {
            OnButtonUpFromAreaDown();

            m_start_no_in = false;
            m_area_down = false;
        }
    }

    void OnButtonInArea()
    {
        GameManager.Instance.m_input.transform.FindChild("flick").GetComponent<FlickManager>().show_flick(m_mojis,transform.position);
    }

    void OnButtonUpFromAreaDown()
    {
        GameManager.Instance.m_input.GetComponent<InputManager>().set_moji(
                    GameManager.Instance.m_input.transform.FindChild("flick").GetComponent<FlickManager>().get_select_moji()
            );

        GameManager.Instance.m_input.transform.FindChild("flick").GetComponent<FlickManager>().hide_flick();
    }

    bool m_in = false;
    bool m_down = false;
    bool m_up = false;
    bool m_start_no_in = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_down)
        {
            m_start_no_in = true;
        }

        m_in = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_in = false;
    }

}
