using UnityEngine;
using Valve.VR.InteractionSystem;

public class QuitGameButton : UIElement
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        
        Application.Quit();
    }
}
