using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Player.States
{
    public class FelineState : State
    {
        public FelineState(Witch witch, IStateSwitcher stateSwitcher) : base(witch, stateSwitcher)
        {
            Debug.Log("Humanoid state active");
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Call()
        {
            Debug.Log("Feline state");
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
