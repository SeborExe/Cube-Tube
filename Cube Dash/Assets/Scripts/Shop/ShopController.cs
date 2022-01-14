using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject selectedSkin;
    [SerializeField] private Text coinsText;
    [SerializeField] private SkinManager skinManager;
    void Update()
    {
        coinsText.text = "Money: " + PlayerPrefs.GetInt("money", 0);
        selectedSkin.GetComponent<MeshRenderer>().material = skinManager.GetSelectedSkin().material;
    }

    public void LoadMenu() => SceneManager.LoadScene("Menu");
}
