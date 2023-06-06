using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Crochetage : MonoBehaviour
{
    public GameObject _Crochet;
    public GameObject _CrochetFinal;
    private float objectifFinal;
    private float objectif1;
    private float objectif2;
    private Animation anim;


    void OnEnable()
    {
        objectif1 = Random.Range(0f, 110f);
        objectif2 = Random.Range(240f, 360f);
        var var_crochet = Random.Range(0, 2);
        anim = GetComponent<Animation>();

        if (var_crochet == 0)
            objectifFinal = objectif1;
        else
            objectifFinal = objectif2;

        _CrochetFinal.transform.eulerAngles = new Vector3(0, 0, objectifFinal);
    }

    void Update()
    {
        CheckPosition();
        
        if (Input.GetAxis("Horizontal") < 0 && (_Crochet.transform.eulerAngles.z < 110 || _Crochet.transform.eulerAngles.z > 230))
        {
            _Crochet.transform.Rotate(0, 0, 0.5f);
        }

        if (Input.GetAxis("Horizontal") > 0 && (_Crochet.transform.eulerAngles.z < 120 || _Crochet.transform.eulerAngles.z > 240))
        {
            _Crochet.transform.Rotate(0, 0, -0.5f);
        }           
    }

    private void CheckPosition()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_Crochet.transform.eulerAngles.z > objectifFinal - 10  && _Crochet.transform.eulerAngles.z < objectifFinal + 10)
            {
                Debug.Log("REUSSI");
                anim.Play("CrochetageValide");
                transform.parent.parent.GetComponent<Trigger_Minijeu>().validated = true;
            }
            else
            {
                anim.Play("CrochetageFail");
            }
        }
    }

   
}
