using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReturnToMenuButton : UIElement
{
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        
        GameManager.Instance.BackToMainMenu();
    }
}
