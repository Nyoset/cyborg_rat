using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InputField : MonoBehaviour, IPointerClickHandler
{
    public string labelText;

    TMP_InputField input;
    TextMeshProUGUI label;

    private void Awake()
    {
        input = gameObject.GetComponentInChildren<TMP_InputField>();
        label = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        label.text = labelText;
    }

    private void Start()
    {
        input.Select();
        input.ActivateInputField();
    }

    public void OnClickInputField()
    {
        input.Select();
    }

    public void SetLabelText(string newText)
    {
        label.text = newText;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickInputField();
    }
}
