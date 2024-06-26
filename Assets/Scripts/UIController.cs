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

    public PlayerController _outfit;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoldChangeHandler(int newVal)
    {
        //Update Gold UI variable.
        /*element.text = newVal;*/
    }

    public void ToogleShop()
    {
        _shop.visible = !_shop.visible;
    }


    private void OnBuy1Clicked(ClickEvent evt)
    {
        _outfit.ChangeOutfit(0);
    }

    private void OnBuy2Clicked(ClickEvent evt)
    {
        _outfit.ChangeOutfit(1);
    }

    private void OnBuy3Clicked(ClickEvent evt)
    {
        _outfit.ChangeOutfit(2);
    }
}
