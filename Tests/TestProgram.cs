using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main()
        {
            using (var game = new TheGame())
                game.Run();
        }
    }

    public class TheGame : OrkEngine.OrkGame
    {
        protected override void OnStart()
        {
            var go = new GameObjects.TestObject("MyObject");
            AddObject(go);
            var script = go.GetComponent<Assets.TestComponent>();
            if (script is object)
                Console.WriteLine("Found script.");
        }

        protected override void OnUpdate(double deltaTime)
        {
            if (KeyDown(OpenTK.Input.Key.Escape))
                Stop();
        }

        public TheGame() : base("Effing game") { }
    }
}
