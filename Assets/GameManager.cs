using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    public Canvas m_root_canvas;
    public GameObject m_input;
    public GameObject m_panel_manager;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {

        CrossWordCreater.CreateCrossWord(m_panel_manager, "stage/sample_stage");
        
	}
	
	// Update is called once per frame
	void Update () {
	}
}
