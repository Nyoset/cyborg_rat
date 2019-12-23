﻿using UnityEngine;

public class Menu : MonoBehaviour
{
    public MenuButton[] buttons;
    protected ButtonAction[] actions;
    public InputField[] inputs;

    private int selectedButton;
    public bool isActive;

    CanvasGroup canvas;

    protected virtual void Start()
    {
        canvas = gameObject.GetComponent<CanvasGroup>();
        Activate(isActive);

        if (actions?.Length != buttons?.Length)
        {
            Debug.Log("Buttons badly configured!");
            return;
        }
        
        for (int i = 0; i < actions.Length; ++i)
        {
            buttons[i].SetAction(actions[i]);
        }
        HighlightButton();
    }

    void AddListeners()
    {
        GameMaster.instance.inputHandler.upArrowListener += PreviousButton;
        GameMaster.instance.inputHandler.downArrowListener += NextButton;
        GameMaster.instance.inputHandler.enterListener += SelectButton;
    }

    void RemoveListeners()
    {
        GameMaster.instance.inputHandler.upArrowListener -= PreviousButton;
        GameMaster.instance.inputHandler.downArrowListener -= NextButton;
        GameMaster.instance.inputHandler.enterListener -= SelectButton;
    }

    public void Activate(bool active)
    {
        isActive = active;
        if (active) AddListeners();
        else RemoveListeners();
        canvas.alpha = active ? 1f : 0f;
        canvas.blocksRaycasts = active;
    }

    public void ActivateScreen<T>() where T : Menu
    {
        transform.root.GetComponentInChildren<T>().Activate(true);
    }

    void SelectButton()
    {
        if (isActive)
        {
            buttons[selectedButton]?.PerformAction();
        }
    }
 
    void PreviousButton()
    {
        selectedButton -= 1;
        if (selectedButton < 0)
            selectedButton = buttons.Length - 1;
        HighlightButton();
    }

    void NextButton()
    {
        selectedButton += 1;
        if (selectedButton >= buttons.Length)
            selectedButton = 0;
        HighlightButton();
    }

    void HighlightButton()
    {
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].isSelected = (i == selectedButton);
        }
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }
}
