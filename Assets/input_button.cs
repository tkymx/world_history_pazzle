using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class input_button : MonoBehaviour {

    public string[] m_moji = new string[4];

	// Use this for initialization
	void Start () {

        Button button = GetComponent<Button>();
        button.onClick.AddListener(onclick);

        GetComponentInChildren<Text>().text = m_moji[0];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onclick()
    {
        GameManager.Instance.m_input.GetComponent<InputManager>().set_moji(m_moji[0]);
    }

}
