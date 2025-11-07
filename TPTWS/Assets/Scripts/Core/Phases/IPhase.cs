using UnityEngine;

namespace TPT.Core.Phases
{
    public interface IPhase
    {
        Awaitable Begin();
        Awaitable Execute();
        Awaitable End();
    }
}