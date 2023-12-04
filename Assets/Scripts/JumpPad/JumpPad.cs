using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    struct JumpPadTarget
    {
        public float ContactTime;
    }

    [SerializeField] float LaunchDelay = 0.1f;
    [SerializeField] float LaunchForce = 100f;
    [SerializeField] ForceMode LaunchMode = ForceMode.Impulse;

    Dictionary<Rigidbody, JumpPadTarget> Targets = new Dictionary<Rigidbody, JumpPadTarget>();

    List<Rigidbody> TargetsToClear = new List<Rigidbody>();


    private void FixedUpdate()
    {
        List<Rigidbody> targetsToClear = new List<Rigidbody>();
        float thresholdTime = Time.timeSinceLevelLoad - LaunchDelay;
        foreach (var kvp in Targets)
        {
            if (kvp.Value.ContactTime >= thresholdTime)
            {
                Launch(kvp.Key);
                TargetsToClear.Add(kvp.Key);
            }
        }

        foreach(var target in  TargetsToClear)
            Targets.Remove(target);
        targetsToClear.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb;
        
        if (collision.gameObject.TryGetComponent<Rigidbody>(out rb))
        {
            Targets[rb] = new JumpPadTarget() { ContactTime = Time.timeSinceLevelLoad };
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    void Launch(Rigidbody TargetRB)
    {
        TargetRB.AddForce(transform.up * LaunchForce, LaunchMode);
    }

}
