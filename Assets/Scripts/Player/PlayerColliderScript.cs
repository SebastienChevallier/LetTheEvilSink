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
                        break;

                    case "Deplacer":
                        interact.sprite = _SpriteDeplacer;
                        break;

                    case "Cacher":
                        interact.sprite = _SpriteCacher;
                        break;
                    
                    case "Finish":
                        interact.sprite = _SpritePorte;
                        other.transform.parent.GetComponent<Portes>().cadre_avant.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        other.transform.parent.GetComponent<Portes>().cadre_avant.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 50f);
                        other.transform.parent.GetComponent<Portes>().cadre_arriere.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                        other.transform.parent.GetComponent<Portes>().cadre_arriere.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 50f);
                    break;
                    
                    
                    case "Parler":
                        interact.sprite = _SpriteTalk;
                        break;
                    
                    case "Passage":
                        interact.sprite = _SpritePassage;
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
            if (other.CompareTag("Finish"))
            {
                other.transform.parent.GetComponent<Portes>().cadre_avant.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                other.transform.parent.GetComponent<Portes>().cadre_avant.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
                other.transform.parent.GetComponent<Portes>().cadre_arriere.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                other.transform.parent.GetComponent<Portes>().cadre_arriere.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
            }
        }
    }
}
