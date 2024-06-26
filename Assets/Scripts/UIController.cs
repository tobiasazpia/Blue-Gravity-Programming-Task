using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement _shop;

    private Button[] _buy = new Button[3];
    private Button[] _sell = new Button[3];


    private Label _goldAmount;

    public OutfitController _outfit;
    public PlayerController _playerController;
    public ShopController _shopController;

    public AudioSource _audio;
    public AudioClip buySound;
    public AudioClip sellSound;
    public AudioClip equipSound;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _shop = root.Q<VisualElement>("ShopContainer");

        for (int i = 0; i < 3; i++)
        {
            _buy[i] = root.Q<Button>("Buy" + (i+1));
        }
        _buy[0].RegisterCallback<ClickEvent>(OnBuy1Clicked);
        _buy[1].RegisterCallback<ClickEvent>(OnBuy2Clicked);
        _buy[2].RegisterCallback<ClickEvent>(OnBuy3Clicked);

        for (int i = 0; i < 3; i++)
        {
            _sell[i] = root.Q<Button>("Sell" + (i+1));
        }
        _sell[0].RegisterCallback<ClickEvent>(OnSell1Clicked);
        _sell[1].RegisterCallback<ClickEvent>(OnSell2Clicked);
        _sell[2].RegisterCallback<ClickEvent>(OnSell3Clicked);

        _goldAmount = root.Q<Label>("GoldAmount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoldChangeHandler(int newVal)
    {
        //Update Gold UI variable.
        _goldAmount.text = newVal.ToString();
    }

    public void ToogleShop()
    {
        _shop.visible = !_shop.visible;
    }


    private void OnBuy1Clicked(ClickEvent evt)
    {
        OutfitLogic(0);
    }

    private void OnBuy2Clicked(ClickEvent evt)
    {
        OutfitLogic(1);
    }

    private void OnBuy3Clicked(ClickEvent evt)
    {
        OutfitLogic(2);
    }

    private void OutfitLogic(int outfitID)
    {
        _outfit.ChangeOutfit(outfitID);
        _audio.clip = equipSound;


        ////If not alredy owned,
        if (!_playerController.OwnsOutfit(outfitID))
        {
            _audio.clip = buySound;
            _playerController.BoughtOutfit(outfitID);
            //cahnge text to "Equip"
            _buy[outfitID].text = "Equip";
            //spend gold
            _playerController.Gold -= _shopController.prices[outfitID];
            //Sell becomes available
            _sell[outfitID].style.display = DisplayStyle.Flex;
        }
        _audio.Play();
    }

    private void OnSell1Clicked(ClickEvent evt)
    {
        OutfitSellLogic(0);
    }

    private void OnSell2Clicked(ClickEvent evt)
    {
        OutfitSellLogic(1);
    }

    private void OnSell3Clicked(ClickEvent evt)
    {
        OutfitSellLogic(2);
    }

    private void OutfitSellLogic(int outfitID)
    {
        _outfit.ChangeOutfit(3);
        //play sound
        _audio.clip = sellSound;
        _audio.Play();

        _playerController.SoldOutfit(outfitID);
            //cahnge text to "Equip"
            _buy[outfitID].text = "Buy";
            //spend gold
            _playerController.Gold += _shopController.prices[outfitID];
        //Sell becomes available
        _sell[outfitID].style.display = DisplayStyle.None;
    }
}
