using System;
using OrkEngine;

namespace Tests.Assets
{
    public class TestComponent : Component
    {
        protected override void OnDestroy()
        {
            Console.WriteLine("This object just got destroyed.");
        }

        protected override void OnStart()
        {
            Console.WriteLine("This object got initialized.");
        }

        protected override void OnUpdate(double deltaTime)
        {
            Console.WriteLine("This will be called a lot, until someone exits.");
        }
    }
}
