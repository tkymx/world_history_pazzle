using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

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
        // 入力
        string input = m_current_panel.GetComponentInChildren<Text>().text;

        if (moji == "”")
        {
            char dakuten    = '\x3099';   // U+3099: COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK
            string added = (input + dakuten).Normalize(NormalizationForm.FormC);
            if (input.Length == added.Length)
            {
                moji = added;
            }
            else
            {
                moji = input;
            }
        }
        if (moji == "゜")
        {
            char handakuten = '\x309A';   // U+309A: COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
            string added = (input + handakuten).Normalize(NormalizationForm.FormC);
            if (input.Length == added.Length)
            {
                moji = added;
            }
            else
            {
                moji = input;
            }
        }

        m_current_panel.GetComponentInChildren<Text>().text = moji;
    }

    public void end_input()
    {
        gameObject.SetActive(false);
    }

    public void start_input(GameObject panel)
    {
        m_current_panel = panel;
        gameObject.SetActive(true);
    }
}
