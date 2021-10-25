using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCSharp.Assets.Scripts.Player
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : State;
    }
}
