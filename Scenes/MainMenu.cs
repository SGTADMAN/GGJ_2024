using Godot;
using System;

public partial class MainMenu : Control
{
    [Export]
    public Node playerContainer { get; set; }
    [Export] 
    CheckBox player1CheckBox { get; set; }
    [Export]
    CheckBox player2CheckBox { get; set; }
    [Export]
    player_select[] player_Selects { get; set; }
    [Export]
    main_game mainGameScript { get; set; }

    public override void _Ready()
    {
        base._Ready();
    }
    public override void _UnhandledInput(InputEvent @event)
    {
        if (Visible)
        {
            if (@event.IsActionPressed("ui_focus_next") || Input.IsJoyButtonPressed(0,JoyButton.Start))
            {
                player1CheckBox.ButtonPressed = !player1CheckBox.ButtonPressed;
            }
            if (@event.IsActionPressed("ui_accept") || Input.IsJoyButtonPressed(1, JoyButton.Start))
            {
                player2CheckBox.ButtonPressed = !player2CheckBox.ButtonPressed;
            }
        }
    }
    public override void _Process(double delta)
    {
        if (player1CheckBox.ButtonPressed && player2CheckBox.ButtonPressed)
        {
            //Call main game script to spawn players with weapon choices.
            mainGameScript.SetUpGame(player_Selects[0].characterIndex, player_Selects[0].weaponIndex,
                player_Selects[1].characterIndex, player_Selects[1].weaponIndex);
            Visible = false;
            ProcessMode = ProcessModeEnum.Disabled;
        }
    }
}
