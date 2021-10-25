namespace AssemblyCSharp.Assets.Scripts.Player
{
    public abstract class State
    {
        protected readonly Witch _witch;
        protected readonly IStateSwitcher _stateSwitcher;


        protected State(Witch witch, IStateSwitcher stateSwitcher)
        {
            _witch = witch;
            _stateSwitcher = stateSwitcher;
        }

        public abstract void Call();
        public abstract void Attack();
        public abstract void Move();
        public abstract void Interact();
    }
}
