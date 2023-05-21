using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public Rigidbody rigidbody3d;
    public float force = 500f;

    void OnValidate()
    {
        rigidbody3d = GetComponent<Rigidbody>();
        rigidbody3d.isKinematic = true;
    }

    public override void OnStartServer()
    {
        rigidbody3d.isKinematic = false;
    }

    [ServerCallback]
    void Update()
    {
        // only let the local player control the racket.
        // don't control other player's rackets
        if (isLocalPlayer)
        {
            if (Input.anyKeyDown)
            {
                switch (Input.inputString)
                {
                    case "w":
                        rigidbody3d.AddForce(Vector3.forward * force);
                        break;
                    case "a":
                        rigidbody3d.AddForce(Vector3.left * force);
                        break;
                    case "s":
                        rigidbody3d.AddForce(Vector3.back * force);
                        break;
                    case "d":
                        rigidbody3d.AddForce(Vector3.right * force);
                        break;
                    case "space":
                        rigidbody3d.AddForce(Vector3.right * force);
                        break;
                }
            }
        }
    }
}

