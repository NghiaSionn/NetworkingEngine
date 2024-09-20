using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    [SerializeField] private float speed = 5;
    private NetworkCharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if(GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _cc.Move(speed * data.direction * Runner.DeltaTime);
            base.FixedUpdateNetwork();
        }
        
    }
}
