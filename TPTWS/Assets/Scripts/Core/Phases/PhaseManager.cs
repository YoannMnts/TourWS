using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Core.Phases
{
    public static class PhaseManager
    {
        private static AwaitableCompletionSource completedSource = new AwaitableCompletionSource();
        
        private static List<IPhaseListener> listeners = new List<IPhaseListener>();
        public static Awaitable CompletedPhase
        {
            get
            {
                completedSource.SetResult();
                var awaitable = completedSource.Awaitable;
                completedSource.Reset();
                return awaitable;
            }
        }

        static PhaseManager()
        {
        }

        public static Awaitable Run<T>(this T phase) where T : IPhase
        {
            Awaitable awaitable = RunAsync(phase);
            
            return awaitable;
        }
        
        public static async Awaitable RunAsync<T>(this T phase) where T : IPhase 
        {
            try
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
            catch (Exception e)
            {
                Debug.LogException(e);
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