using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Transform grid;
    public List<Tuyauterie> puzzleTiles;


    void OnEnable()
    {
        foreach (Transform t in grid)
        {
            Tuyauterie tuyau = t.GetComponent<Tuyauterie>();

            // Randomize rotation
            int i = Random.Range(0, 4);
            t.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + (90 * i));
            tuyau.actualRotation = t.eulerAngles.z;

            if (tuyau.isPuzzle)
            {
                puzzleTiles.Add(t.GetComponent<Tuyauterie>());
            }
        }
    }

    public void CheckPuzzle()
    {
        foreach (Tuyauterie t in puzzleTiles)
        {
            if (!CheckPuzzleRot(t.actualRotation, t.puzzleRotation))
            {
                return;
            }
        }

        // PUZZLE FINI
        transform.parent.GetComponent<Trigger_Minijeu>().validated = true;
    }

    private bool CheckPuzzleRot(float actualRot, List<float> puzzleRot)
    {
        foreach (float rot in puzzleRot)
        {
            if (actualRot == rot)
            {
                return true;
            }
        }

        return false;
    }
}
