using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private bool destroyOnEvent;

    [SerializeField][Tooltip("Event to register with.")]
    private GameEvent Event;

    [SerializeField][Tooltip("Response to invoke when Event is raised.")]
    private UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
        if (destroyOnEvent)
        {
            Destroy(this);
        }
    }
}
