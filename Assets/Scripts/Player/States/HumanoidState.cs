using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCSharp.Assets.Scripts.Player.States
{
    public class HumanoidState : State
    {
        public HumanoidState(Witch witch, IStateSwitcher stateSwitcher) : base(witch, stateSwitcher)
        {
            Debug.Log("Humanoid state active");
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Call()
        {
            Debug.Log("Humanoid state");
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
