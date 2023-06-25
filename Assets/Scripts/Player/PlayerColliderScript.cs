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
                        if (other.TryGetComponent<Trigger_Minijeu>(out Trigger_Minijeu minijeu))
                        {
                            minijeu.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                            minijeu.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 200f);
                        }
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
                        if (other.transform.parent.TryGetComponent<Portes>(out Portes portes))
                        {
                            if ((portes.cadre_arriere || portes.cadre_avant) != null)
                            {
                                portes.cadre_avant.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                                portes.cadre_avant.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 200f);
                                portes.cadre_arriere.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.white);
                                portes.cadre_arriere.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 200f);
                            }
                        }
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
            if (other.CompareTag("Finish") && other.transform.parent.TryGetComponent<Portes>(out Portes portes))
            {
                if ((portes.cadre_arriere || portes.cadre_avant) != null)
                {
                    portes.cadre_avant.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                    portes.cadre_avant.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
                    portes.cadre_arriere.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                    portes.cadre_arriere.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20f);
                }
            }
            else if (other.CompareTag("Cables") && other.TryGetComponent<Trigger_Minijeu>(out Trigger_Minijeu minijeu))
            {
                minijeu.GetComponent<MeshRenderer>().material.SetColor("_Outline_Color", Color.black);
                minijeu.GetComponent<MeshRenderer>().material.SetFloat("_Outline_Width", 20F);
            }
        }
    }
}
