using Godot;
using System;

public partial class player_select : Control
{
    [Export]
    public int playerNo { get; set; }
    [Export]
    public string[] characterImagesFileNames { get; set; }
    [Export]
    public string[] weaponImagesFileNames { get; set; }
    [Export]
    public TextureRect characterImage { get; set; }
    [Export]
    public TextureRect weaponImage { get; set; }
    public int characterIndex;
    public int weaponIndex;

    public override void _Ready()
    {
        characterIndex = 0;
        weaponIndex = 0;
    }

    public override void _Process(double delta)
    {
        if (Visible)
        {
            //Character select
            if (Input.IsActionJustPressed("p" + (playerNo + 1) + "_Left") || Input.IsJoyButtonPressed(playerNo,JoyButton.DpadLeft))
            {
                characterIndex--;
                characterIndex = Mathf.Clamp(characterIndex,0, characterImagesFileNames.Length-1);
            }
            if (Input.IsActionJustPressed("p" + (playerNo + 1) + "_Right") || Input.IsJoyButtonPressed(playerNo, JoyButton.DpadRight))
            {
                characterIndex++;
                characterIndex = Mathf.Clamp(characterIndex, 0, characterImagesFileNames.Length - 1);
            }
            characterImage.Texture = GD.Load<Texture2D>(characterImagesFileNames[characterIndex]);
            //Weapon select
            if (Input.IsActionJustPressed("p" + (playerNo + 1) + "_Forward") || Input.IsJoyButtonPressed(playerNo, JoyButton.DpadUp))
            {
                weaponIndex--;
                weaponIndex = Mathf.Clamp(weaponIndex, 0, weaponImagesFileNames.Length - 1);
            }
            if (Input.IsActionJustPressed("p" + (playerNo + 1) + "_Backward") || Input.IsJoyButtonPressed(playerNo, JoyButton.DpadDown))
            {
                weaponIndex++;
                weaponIndex = Mathf.Clamp(weaponIndex, 0, weaponImagesFileNames.Length - 1);
            }
            weaponImage.Texture = GD.Load<Texture2D>(weaponImagesFileNames[weaponIndex]);
        }
    }
}
