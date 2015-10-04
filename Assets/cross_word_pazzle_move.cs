using UnityEngine;
using System.Collections;

public class cross_word_pazzle_move : MonoBehaviour {

    private bool m_isMove;
    public void setIsMove(bool f)
    {
        m_isMove = f;
    }

    private float sensitivity = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (m_isMove)
        {
            if (Input.GetMouseButton(0))
            {
                float mouse_move_x = Input.GetAxis("Mouse X") * sensitivity;
                float mouse_move_y = Input.GetAxis("Mouse Y") * sensitivity;

                transform.position = transform.position + new Vector3(mouse_move_x, mouse_move_y, 0);
            }
        }       
	}
}
