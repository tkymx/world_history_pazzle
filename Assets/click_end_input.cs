using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class click_end_input : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Button button = GetComponent<Button>();
        button.onClick.AddListener(onclick);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onclick()
    {
        GameManager.Instance.m_input.GetComponent<InputManager>().end_input();
    }
}
