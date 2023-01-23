using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Crochetage : MonoBehaviour
{

    public GameObject _Crochet;
    [SerializeField]
    private float objectifFinal;
    private float objectif1;
    private float objectif2;
    private float timeLeft;
    private float _TimeDelay = 1f;

    private float val;


    // Start is called before the first frame update
    void Start()
    {
        objectif1 = Random.Range(0f, 110f);
        objectif2 = Random.Range(240f, 360f);
        var var_crochet = Random.Range(0, 2);
        if (var_crochet == 0)
            objectifFinal = objectif1;
        else
            objectifFinal = objectif2;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        
        if (Input.GetKey(KeyCode.A) && (_Crochet.transform.eulerAngles.z < 110 || _Crochet.transform.eulerAngles.z > 230))
        {
            _Crochet.transform.Rotate(0, 0, 1f);
        }

        if (Input.GetKey(KeyCode.D) && (_Crochet.transform.eulerAngles.z < 120 || _Crochet.transform.eulerAngles.z > 240))
        {
            _Crochet.transform.Rotate(0, 0, -1f);
        }

        Debug.Log(val);
           
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (_Crochet.transform.eulerAngles.z > objectifFinal - 10  && _Crochet.transform.eulerAngles.z < objectifFinal + 10)
            {
                SceneManager.UnloadSceneAsync("Crochetage");
                SceneManager.LoadScene("Mini jeux", LoadSceneMode.Additive);
            }
        }
    }

   
}
