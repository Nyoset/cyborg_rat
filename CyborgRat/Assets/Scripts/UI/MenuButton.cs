using UnityEngine;
using UnityEngine.UI;
using TMPro;

public delegate void ButtonAction();

public class MenuButton : MonoBehaviour
{
	public Button button;
    public TextMeshProUGUI textLabel;
    public Image buttonImage;

    public MenuButtonViewModel viewModel;

    bool _isSelected;
    public bool isSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            _isSelected = value;
            ChangeColor(value);
        }
    }

    public void initializeButton(MenuButtonViewModel viewModel)
    {
        this.viewModel = viewModel;
        button.onClick.AddListener(PerformAction);
        textLabel.text = viewModel.text;
    }

    public void PerformAction()
	{
        viewModel.action();
	}

    void ChangeColor(bool selected)
    {
        buttonImage.color = selected ? Color.red : Color.white;
    }
}

public class MenuButtonViewModel
{
    public string text;
    public ButtonAction action;

    public MenuButtonViewModel(string text, ButtonAction action)
    {
        this.text = text;
        this.action = action;
    }
}
