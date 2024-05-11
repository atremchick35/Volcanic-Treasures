using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public interface IEffectable
{
    void OnTriggerEnter2D(Collider2D other);

    void OnTriggerExit2D(Collider2D other);

    void KillPlayer();
}
