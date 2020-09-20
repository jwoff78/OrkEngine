using System;
using OrkEngine;

namespace Tests.GameObjects
{
    public class TestObject : GameObject
    {
        public TestObject(string name) : base(name)
        {
            AddComponent<Assets.TestComponent>();
        }
    }
}
