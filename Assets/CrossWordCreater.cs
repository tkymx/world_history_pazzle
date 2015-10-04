using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossWordCreater {

    static public void CreateCrossWord( GameObject panel_manager , string filename )
    {
        TextAsset asset = Resources.Load(filename) as TextAsset;

        Debug.Log(asset.text);

        string[] line_texts = asset.text.Replace("\r","").Split('\n');

        GameObject block_object = null;

        int y = 0;
        int x = 0;
        foreach (string line in line_texts)
        {
            Debug.Log(line);

            string[] panels = line.Split(',');

            x = 0;
            foreach (string panel in panels)
            {
                block_object = AddPanel(panel_manager, panel, x, -y , panels.Length , line_texts.Length );
                x++;
            }
            y++;
        }

        panel_manager.transform.localScale = new Vector3(1, 1, 1) * 0.6f;
    }

    static public GameObject AddPanel( GameObject panel_manager , string panel , int x , int y , int wn , int hn )
    {
        GameObject block_object = null;
        if( panel == "#" )
        {
            block_object = GameObject.Instantiate( Resources.Load("prefab/block_panel",typeof(GameObject)) as GameObject );
            block_object.transform.SetParent(panel_manager.transform);
            block_object.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); 
            block_object.transform.localPosition = new Vector3( 
                (x-wn/2) * (block_object.GetComponent<RectTransform>().sizeDelta.x + 2) , 
                (y+hn/2) * (block_object.GetComponent<RectTransform>().sizeDelta.y + 2) , 
                0 );
        }

        else if (panel == "　")
        {
            block_object = GameObject.Instantiate(Resources.Load("prefab/editable_panel", typeof(GameObject)) as GameObject);
            block_object.transform.SetParent(panel_manager.transform);
            block_object.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            block_object.transform.localPosition = new Vector3(
                (x - wn / 2) * (block_object.GetComponent<RectTransform>().sizeDelta.x + 2),
                (y + hn / 2) * (block_object.GetComponent<RectTransform>().sizeDelta.y + 2),
                0);
        }

        else
        {
            block_object = GameObject.Instantiate(Resources.Load("prefab/static_panel", typeof(GameObject)) as GameObject);
            block_object.GetComponentInChildren<Text>().text = panel;
            block_object.transform.SetParent(panel_manager.transform);
            block_object.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            block_object.transform.localPosition = new Vector3(
                (x - wn / 2) * (block_object.GetComponent<RectTransform>().sizeDelta.x + 2),
                (y + hn / 2) * (block_object.GetComponent<RectTransform>().sizeDelta.y + 2),
                0);
        }

        return block_object;
    }

}
