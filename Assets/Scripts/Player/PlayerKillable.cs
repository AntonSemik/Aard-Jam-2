using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillable : IsKillable
{
    [SerializeField] GameObject loseMenuPanel;

    public override void Die()
    {
        if(OpenScene.onOpenScene != null) OpenScene.onOpenScene();
    }
}
