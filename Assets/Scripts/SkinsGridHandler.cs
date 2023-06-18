using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsGridHandler : MonoBehaviour
{
    [SerializeField] private Material[] skinsMaterials;
    [SerializeField] private GameObject[] chestsInGame;
    private int[][] skinsIndixes;

    private void Start()
    {
        skinsIndixes= new int[][] { new int[]{2, 9, 1, 9, 2, 1},
                                    new int[]{3, 9, 1, 9, 3, 1},
                                    new int[]{4, 9, 1, 9, 4, 1},
                                    new int[]{6, 9, 1, 9, 6, 1},
                                    new int[]{7, 9, 1, 9, 7, 1},
                                    new int[]{8, 9, 1, 9, 8, 1},
                                    new int[]{18, 20, 19, 20, 18, 19},
                                    new int[]{12, 20, 11, 16, 12, 11},
                                    new int[]{14, 20, 19, 7, 14, 10},
                                    new int[]{1, 8, 21, 8, 1, 21},
                                    new int[]{3, 4, 20, 4, 3, 20},
                                    new int[]{15, 15, 15, 15, 15, 15}};
        SelectedSkinIndex(PlayerPrefs.GetInt("skinIndex"));
    }
    public void SelectedSkinIndex(int index)
    {
        PlayerPrefs.SetInt("skinIndex", index);
        foreach (GameObject chest in chestsInGame)
        {
            //top chest mats
            Material[] materials = chest.transform.Find("Chest_Animated").transform.Find("Chest_Up").GetComponent<Renderer>().materials;
            materials[0] = skinsMaterials[skinsIndixes[index][0]];
            materials[1] = skinsMaterials[skinsIndixes[index][1]];
            materials[2] = skinsMaterials[skinsIndixes[index][2]];
            chest.transform.Find("Chest_Animated").transform.Find("Chest_Up").GetComponent<Renderer>().materials = materials;

            //bottom chest mats
            materials = chest.transform.Find("Chest_Animated").transform.Find("Chest_Bottom").GetComponent<Renderer>().materials;
            materials[0] = skinsMaterials[skinsIndixes[index][3]];
            materials[1] = skinsMaterials[skinsIndixes[index][4]];
            materials[2] = skinsMaterials[skinsIndixes[index][5]];
            chest.transform.Find("Chest_Animated").transform.Find("Chest_Bottom").GetComponent<Renderer>().materials = materials;
        }
    }
}
