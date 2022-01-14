using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Material selectedSkin;
    [SerializeField] private Text coinsText;
    [SerializeField] private SkinManager skinManager;
    void Update()
    {
        coinsText.text = "Money: " + PlayerPrefs.GetInt("money", 0);
        selectedSkin = skinManager.GetSelectedSkin().material;
    }

    public void LoadMenu() => SceneManager.LoadScene("Menu");
}
