using UnityEngine;

public class LoadMenu : Menu
{
    public Table table;
    string[] savedGames;

    protected override void Start()
    {
        savedGames = SaveSystem.ReadAllSaveGames();
        table.data = savedGames;
        actions = new ButtonAction[] { Back };
        selectedButton = buttons.Length;
        base.Start();
        Highlight();
    }

    void Back()
    {
        ActivateScreen<MainMenu>();
        Activate(false);
    }

    void Highlight()
    {
        HighlightButton();
        table.HighlightRow(selectedButton - buttons.Length);
    }

    override protected void PreviousButton()
    {
        selectedButton -= 1;
        if (selectedButton < 0)
            selectedButton = buttons.Length + savedGames.Length - 1;
        Highlight();
    }

    override protected void NextButton()
    {
        selectedButton += 1;
        if (selectedButton >= buttons.Length + savedGames.Length)
            selectedButton = 0;
        Highlight();
    }

    override protected void SelectButton()
    {
        if (selectedButton < buttons.Length)
        {
            base.SelectButton();
        }
        else
        {
            string playerName = table.GetText(selectedButton - buttons.Length);
            GameMaster.instance.LoadGame(playerName);
            Debug.Log(playerName);
        }
    }
}
