using UnityEngine;

public abstract class CreatureBaseState
{
    public abstract void EnterState(CreatureStateManager creature);

    public abstract void UpdateState(CreatureStateManager creature);

    public abstract void FixedUpdateState(CreatureStateManager creature);

    public abstract void OnCollisionEnter(CreatureStateManager creature, Collision collision);

    public abstract void OnTriggerEnter(CreatureStateManager creature, Collider other);
}
