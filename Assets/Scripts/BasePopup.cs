using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePopup : MonoBehaviour
{
    public virtual void Open()
    {
        if (!IsActive())
        {
            gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.LogError(this + ".Open() – trying to open a popup that is already active!");
        }
    }

    virtual public void Close()
    {
        if (IsActive())
        {
            gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
