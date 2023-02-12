using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillable : IsKillable
{
    [SerializeField] float deathDelay;

    [SerializeField] AudioSource deathSound;
    public override void Die()
    {
        StartCoroutine(PlayerDeath());
    }

    IEnumerator PlayerDeath()
    {
        deathSound.Play();

        yield return new WaitForSeconds(deathDelay);

        if (OpenScene.onOpenScene != null) OpenScene.onOpenScene();
    }
}
