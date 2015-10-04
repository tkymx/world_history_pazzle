using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        //サイズの変更
        GameObject target_flick_obj = find_near_game_object();
        target_flick_obj.transform.localScale = new Vector3(2, 2, 2);

	}

    public GameObject find_near_game_object()
    {
        float min_length = 1 << 21;
        GameObject go = null;

        Vector3 mouse_pos = Input.mousePosition;

        foreach (Transform child in transform )
        {
            if (!child.gameObject.activeSelf)
                continue;

            child.localScale = new Vector3(1, 1, 1);

            Vector3 pos = child.gameObject.transform.position;

            if ((pos - mouse_pos).magnitude < min_length)
            {
                min_length = (pos - mouse_pos).magnitude;
                go = child.gameObject;
            }
        }
        return go;

    }
    public string find_near_moji()
    {
        return find_near_game_object().GetComponentInChildren<Text>().text;
    }

    public string get_select_moji()
    {
        return find_near_moji();
    }

    public void show_flick( string []mojis , Vector3 center )
    {
        gameObject.SetActive(true);

        string[] strs = { "center", "left", "top", "right", "bottom" };


        for (int i = 0; i < strs.Length; i++)
        {
            transform.FindChild(strs[i]).gameObject.SetActive(false);
        }

        for (int i = 0; i < mojis.Length; i++)
        {
            transform.FindChild(strs[i]).gameObject.SetActive(true);
            transform.FindChild(strs[i]).GetComponentInChildren<Text>().text = mojis[i];
        }

        transform.position = center;

    }

    public void hide_flick()
    {
        gameObject.SetActive(false);
    }
}
