using AssemblyCSharp.Assets.Scripts.Player;
using AssemblyCSharp.Assets.Scripts.Player.States;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WitchStateBehaviour : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private Witch _player;

    private bool _isCat = false;
    private State _currentState;
    private List<State> _states;

    private void Start()
    {
        _states = new List<State>()
        {
            new HumanoidState(_player, this as IStateSwitcher),
            new FelineState(_player, this as IStateSwitcher),
        };
        _currentState = _states[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            Metamorphose();
    }

    private void Metamorphose()
    {
        if (_isCat)
        {
            SwitchState<HumanoidState>();
            _isCat = false;
        }
        else
        {
            SwitchState<FelineState>();
            _isCat = true;
        }
            

        _currentState.Call();
    }

    public void SwitchState<T>() where T : State
    {
        var state = _states.FirstOrDefault(s => s is T);
        _currentState = state;
    }
}
