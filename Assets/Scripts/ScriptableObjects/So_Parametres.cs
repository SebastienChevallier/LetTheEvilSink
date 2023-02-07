using UnityEngine;

[CreateAssetMenu(fileName = "So_Parametres", menuName = "Parametres", order = 1)]
public class So_Parametres : ScriptableObject
{
    public float volumeGeneral;
    public float volumeMusic;
    public float volumeSound;
    
    public float brightness;
    public float sensitivity;
    
    public float resolutionX;
    public float resolutionY;
    
    public bool fullscreen;
}