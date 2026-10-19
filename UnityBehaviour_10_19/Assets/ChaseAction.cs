using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "Chase [Target] at [Speed]", category: "Enemy", id: "03531c3e5ec742b5b3674a0a9054f583")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Transform self = GameObject.transform;
        Transform Target = this.Target.Value.transform;
        Vector3 toTarget = Target.position - self.position;
        
        self.LookAt(Target);
        self.position += toTarget.normalized * Speed.Value * Time.deltaTime;


        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

