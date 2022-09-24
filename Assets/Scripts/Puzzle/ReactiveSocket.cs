using Architecture;
using UnityEngine;

[RequireComponent(typeof(Socket))]
public class ReactiveSocket : DialogLevelReactive
{
    private Socket _socket;

    public override void Initialize()
    {
        _socket = GetComponent<Socket>();
    }

    protected override void ThresholdReachedReaction()
    {
        _socket.UnlockSocket();
    }

    protected override void UnderThresholdReaction()
    {
        _socket.LockSocket();
    }
}
