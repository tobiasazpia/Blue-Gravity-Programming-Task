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

    

    // Start is called before the first frame update
    void Start()
    {
        _sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
