using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    [HideInInspector] public GameObject m_current_panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void set_moji(string moji)
    {
        m_current_panel.GetComponentInChildren<Text>().text = moji;
        gameObject.SetActive(false);
    }

    public void start_input(GameObject panel)
    {
        m_current_panel = panel;
        gameObject.SetActive(true);
    }
}
