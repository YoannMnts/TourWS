using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Core.Phases
{
    public static class PhaseManager
    {
        private static List<IPhaseListener> listeners = new List<IPhaseListener>();

        public static Awaitable Run<T>(this T phase) where T : IPhase
        {
            Awaitable awaitable = RunAsync(phase);
            
            return awaitable;
        }
        
        public static async Awaitable RunAsync<T>(this T phase) where T : IPhase 
        {
            using (ListPool<IPhaseListener<T>>.Get(out var list))
            {
                foreach (var listener in listeners)
                    if (listener is IPhaseListener<T> compatible)
                        list.Add(compatible);
                
                await phase.Begin();
                foreach (var listener in list)
                    listener.OnPhaseBegin(phase);

                await phase.Execute();
                
                foreach (var listener in list)
                    listener.OnPhaseEnd(phase);
                
                await phase.End();
            }
        }

        public static void AddListener<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Add(listener);
        }

        public static void RemoveListener<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Remove(listener);
        }
        
    }
}