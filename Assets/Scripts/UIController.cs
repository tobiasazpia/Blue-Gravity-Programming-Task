using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement _shop;

    private Button _buy1;
    private Button _buy2;
    private Button _buy3;

    private Label _goldAmount;

    public OutfitController _outfit;
    public PlayerController _playerController;
    public ShopController _shopController;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _shop = root.Q<VisualElement>("ShopContainer");

        _buy1 = root.Q<Button>("Buy1");
        _buy1.RegisterCallback<ClickEvent>(OnBuy1Clicked);
        _buy2 = root.Q<Button>("Buy2");
        _buy2.RegisterCallback<ClickEvent>(OnBuy2Clicked);
        _buy3 = root.Q<Button>("Buy3");
        _buy3.RegisterCallback<ClickEvent>(OnBuy3Clicked);

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
        ////If not alredy owned,
        if (!_playerController.OwnsOutfit(outfitID))
        {
            _playerController.BoughtOutfit(outfitID);
            //cahnge text to "Equip"
            //spend gold
            _playerController.Gold -= _shopController.prices[outfitID];
            //Sell becomes available
        }
    }
}
