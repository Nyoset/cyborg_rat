using UnityEngine;

public class MainMenu : Menu
{
    override protected void Start()
    {
        buttonsViewModels = new[] { new MenuButtonViewModel("Hello", delegate { }) };
        base.Start();
    }
}
