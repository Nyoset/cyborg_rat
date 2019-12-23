using UnityEngine;
using UnityEngine.UI;
using TMPro;

public delegate void ButtonAction();

public class MenuButton : MonoBehaviour
{
    public string buttonText = "";
    public Sprite buttonImage;
    ButtonAction action;

    Button button;
    TextMeshProUGUI textLabel;
    Image image;

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

    private void Awake()
    {
        button = gameObject.GetComponentInChildren<Button>();
        image = gameObject.GetComponentInChildren<Image>();
        textLabel = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        textLabel.text = buttonText;
        image.sprite = buttonImage;
    }

    void ChangeColor(bool selected)
    {
        image.color = selected ? Color.red : Color.white;
    }

    public void SetAction(ButtonAction action)
    {
        this.action = action;
    }

    public void PerformAction()
    {
        action?.Invoke();
    }
}
