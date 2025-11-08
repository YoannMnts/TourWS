namespace TPT.Core.Phases
{
    public interface IPhaseListener{}
    public interface IPhaseListener<in T> : IPhaseListener where T : IPhase
    {
        void OnPhaseBegin(T phase);
        void OnPhaseEnd(T phase);
    }
}