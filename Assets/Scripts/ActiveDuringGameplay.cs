using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    protected virtual void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    protected virtual void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    private void OnGameActive()
    {
        this.enabled = true;
    }

    private void OnGameInactive()
    {
        this.enabled = false;
    }
}
