using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public So_Player _Player;
    public SpriteRenderer interact;
    public Sprite _SpriteTalk;
    public Sprite _SpriteObserver;
    public Sprite _SpriteDeplacer;
    public Sprite _SpriteCacher;
    public Sprite _SpritePorte;
    public Sprite _SpritePassage;
    public Sprite _SpriteCarte;
    public Sprite _SpriteCrochetage;
    public Sprite _SpriteCables;
      

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            _Player._TriggerObject = other.gameObject;
            
            switch (other.tag)
                {
                    case "Carte":
                        interact.sprite = _SpriteCarte;
                        break;
                    
                    case "Crochetage":
                        interact.sprite = _SpriteCrochetage;
                        break;
                    
                    case "Cables":
                        interact.sprite = _SpriteCables;
                        break;

                    case "Observer":
                        interact.sprite = _SpriteObserver;
                        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        break;

                    case "Deplacer":
                        interact.sprite = _SpriteDeplacer;
                        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        break;

                    case "Cacher":
                        interact.sprite = _SpriteCacher;
                        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        break;
                    
                    case "Finish":
                        interact.sprite = _SpritePorte;
                        other.transform.parent.GetComponent<Portes>().GO_cadre.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        other.transform.parent.GetComponent<Portes>().GO_cadre.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 50f);
                    //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                    break;
                    
                    
                    case "Parler":
                        interact.sprite = _SpriteTalk;
                        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        break;
                    
                    case "Passage":
                        interact.sprite = _SpritePassage;
                        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        break;

                    default:
                        break;
                }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        _Player._TriggerObject = null;
        interact.sprite = null;
        
        if (!other.CompareTag("Untagged"))
        {
            if (other.CompareTag("Door"))
            {
                other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                other.GetComponentInChildren<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
            }
        }
        //other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
    }
}
