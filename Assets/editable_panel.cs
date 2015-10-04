using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class editable_panel : MonoBehaviour
{

	// Use this for initialization
	void Start () {

        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

	}
	
	// Update is called once per frame
	void Update () {


	}

    public void OnClick()
    {
        GameManager.Instance.m_input.GetComponent<InputManager>().start_input(gameObject);
    }

}
