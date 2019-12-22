using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    protected MenuButtonViewModel[] buttonsViewModels;

    protected virtual void Start()
    {
        foreach (MenuButtonViewModel buttonViewModel in buttonsViewModels)
        {
            MenuButton button = PrefabLoader.Load<MenuButton>(Resource.MenuButton);
            button.initializeButton(buttonViewModel);
        }
    }

    void Update()
    {
        
    }
}
