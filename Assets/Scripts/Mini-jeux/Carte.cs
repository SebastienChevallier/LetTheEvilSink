using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte : MonoBehaviour
{
    public GameObject carte;
    public bool completed;

    private Vector3 mousePos;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.Find("Camera").gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if((mousePos.x < carte.transform.position.x + 10 && mousePos.x > carte.transform.position.x - 10) && (mousePos.y < carte.transform.position.y + 5 && mousePos.y > carte.transform.position.y - 5))
            {
                float pos = Mathf.Clamp(Input.mousePosition.x,-200f,200f);
                carte.transform.position = new Vector3(pos, carte.transform.position.y, carte.transform.position.z);
            }
            
        }
    }
}
