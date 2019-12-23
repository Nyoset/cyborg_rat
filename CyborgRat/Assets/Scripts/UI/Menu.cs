using UnityEngine;

public class Menu : MonoBehaviour
{
    public MenuButton[] buttons;
    protected ButtonAction[] actions;

    int selectedButton;

    protected virtual void Start()
    {
        if (actions.Length != buttons.Length)
        {
            Debug.Log("Buttons badly configured!");
            return;
        }
        
        for (int i = 0; i < actions.Length; ++i)
        {
            buttons[i].SetAction(actions[i]);
        }
        HighlightButton();

        GameMaster.instance.inputHandler.upArrowListener += PreviousButton;
        GameMaster.instance.inputHandler.downArrowListener += NextButton;
        GameMaster.instance.inputHandler.enterListener += SelectButton;
    }

    void SelectButton()
    {
        buttons[selectedButton]?.PerformAction();
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
        GameMaster.instance.inputHandler.upArrowListener -= PreviousButton;
        GameMaster.instance.inputHandler.downArrowListener -= NextButton;
        GameMaster.instance.inputHandler.enterListener -= SelectButton;
    }
}
