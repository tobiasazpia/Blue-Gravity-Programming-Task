using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement _shop;

    private Button _buy;
    public PlayerController _outfit;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _shop = root.Q<VisualElement>("ShopContainer");

        _buy = root.Q<Button>("Buy1");
        _buy.RegisterCallback<ClickEvent>(OnBuyClicked);
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


    private void OnBuyClicked(ClickEvent evt)
    {
        _outfit.ChangeOutfit(1);
    }
}
