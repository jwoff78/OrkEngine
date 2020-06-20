using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class SynchronizationHelperSystem : GameSystem
    {
        private Queue<Action> _activeQueue = new Queue<Action>();
        private Queue<Action> _bufferedQueue = new Queue<Action>();

        public void QueueMainThreadAction(Action a)
        {
            _activeQueue.Enqueue(a);
        }

        protected override void UpdateCore(float deltaSeconds)
        {
            Queue<Action> queue = Interlocked.Exchange(ref _activeQueue, _bufferedQueue);
            while (queue.Count > 0)
            {
                queue.Dequeue()();
            }
        }
    }
}