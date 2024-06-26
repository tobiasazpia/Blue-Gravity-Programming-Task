using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    public PlayerInput _pI;
    public UIController _uI;

    private SpriteRenderer _sp;

    public int[] prices = { 40, 50, 10 };

    // Start is called before the first frame update
    void Start()
    {
        _sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (_pI)
        {
            if (_pI.actions["Shop"].WasPressedThisFrame())
            {
                _uI.ToogleShop();
                _sp.enabled = !_sp.enabled;
            }
        }
    }
}
