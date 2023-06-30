using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasedSkins
{
    public int[] Keys;
}
public class SkinsGridHandler : MonoBehaviour
{
    [SerializeField] private Material[] skinsMaterials;
    [SerializeField] private GameObject[] chestsInGame;
    [SerializeField] private string[] skinNames;
    [SerializeField] private int[] skinPrices;
    [SerializeField] private Text nameTextLabel;
    [SerializeField] private Text priceTextLabel;
    [SerializeField] private Text playerGoldTextLabel;
    [SerializeField] private Button buyButton;
    [SerializeField] private Transform skinsContent;
    private int[][] skinsIndixes;
    private string[] purchasedStates;
    private int lastValidPurchaseIndex;

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

        ValidateSkinPurchaseStates();
        SelectedSkinIndex(PlayerPrefs.GetInt("skinIndex"));


    }


    public void SelectedSkinIndex(int index)
    {
        nameTextLabel.text = skinNames[index];
        playerGoldTextLabel.text = "Your Gold: " + PlayerPrefs.GetInt("gold").ToString();
        priceTextLabel.text = "Cost: " + skinPrices[index].ToString() + " Gold";

        //set skin as current if is already purchased
        if (purchasedStates[index] == "1")
        {
            PlayerPrefs.SetInt("skinIndex", index);
            UpdateChestSkins("all", index);
            priceTextLabel.text = "You own this item";
            buyButton.transform.gameObject.SetActive(false);
            cleanCheckIcon(index);
        }
        else
        {
            buyButton.interactable = false;
            buyButton.transform.gameObject.SetActive(true);
            UpdateChestSkins("first", index);
        }

        if (skinPrices[index] > PlayerPrefs.GetInt("gold"))
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
            lastValidPurchaseIndex = index;
        }
        
    }

    private void ValidateSkinPurchaseStates()
    {
        if (PlayerPrefs.GetString("skinPurchasedStates") == "")
        {
            purchasedStates = new string[skinPrices.Length];
            for (int i = 0; i < purchasedStates.Length; i++)
            {
                if (i == 0)
                {
                    purchasedStates[i] = "1";
                }
                else
                {
                    purchasedStates[i] = "0";
                }
            }
            PlayerPrefs.SetString("skinPurchasedStates", string.Join(',', purchasedStates));
        }
        else
        {
            purchasedStates = PlayerPrefs.GetString("skinPurchasedStates").Split(',');
        }
        //purchasedStates = new string[4] { "0", "0", "0", "0" };
        //string x = string.Join(',', purchasedStates);
        //string[] text = x.Split(',');
    }

    public void UpdateChestSkins(string toChange, int index)
    {
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
            if (toChange == "first") return;
        }
    }

    public void BuySkin()
    {
        purchasedStates[lastValidPurchaseIndex] = "1";
        PlayerPrefs.SetInt("skinIndex", lastValidPurchaseIndex);
        PlayerPrefs.SetString("skinPurchasedStates", string.Join(',', purchasedStates));
        skinsContent.GetChild(lastValidPurchaseIndex).GetChild(0).gameObject.SetActive(false);
        UpdateChestSkins("all", lastValidPurchaseIndex);
        priceTextLabel.text = "You own this item";
        buyButton.transform.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - skinPrices[lastValidPurchaseIndex]);
        playerGoldTextLabel.text = "Your Gold: " + PlayerPrefs.GetInt("gold").ToString();
        cleanCheckIcon(lastValidPurchaseIndex);

    }

    public void RemoveLockIcon()
    {
        for (int i = 0; i < skinPrices.Length; i++)
        {
            if (purchasedStates[i] == "1")
            {
                skinsContent.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
            skinsContent.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        skinsContent.GetChild(PlayerPrefs.GetInt("skinIndex")).GetChild(1).gameObject.SetActive(true);
    }

    private void cleanCheckIcon(int index)
    {
        for (int i = 0; i < skinPrices.Length; i++)
        {
            skinsContent.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        skinsContent.GetChild(index).GetChild(1).gameObject.SetActive(true);
    }
}
