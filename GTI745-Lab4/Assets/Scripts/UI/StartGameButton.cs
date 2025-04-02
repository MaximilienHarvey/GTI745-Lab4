using UnityEngine;
using Valve.VR.InteractionSystem;

public class StartGameButton : UIElement
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        
        Debug.Log("Start Game Button Clicked");
        GameManager.Instance.StartGame();
    }
}
