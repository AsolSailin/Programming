using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shooter shooter = new Shooter();
            Mechanic mechanic = new Mechanic();

            Pistol pistol = new Pistol(120, 100, 15);
            Machinegun machinegun = new Machinegun(150, 100, 30);
            Sword sword = new Sword(70, 100);
            Shuriken shuriken = new Shuriken(100);
            Knife knife = new Knife(50, 110, 100);

            Console.WriteLine("---");

            var pistolShot = Task.Run(() => shooter.SingleShot(pistol));
            var machinegunShot = Task.Run(() => shooter.AutoShot(machinegun));
            Task.WaitAll(pistolShot, machinegunShot);

            Console.WriteLine("---");

            var swordMeleeHit = Task.Run(() => shooter.MeleeHit(sword));
            var knifeMeleeHit = Task.Run(() => shooter.MeleeHit(knife));
            Task.WaitAll(swordMeleeHit, knifeMeleeHit);

            Console.WriteLine("---");

            var shurikenThrowHit = Task.Run(() => shooter.ThrowHit(shuriken));
            var knifeThrowHit = Task.Run(() => shooter.ThrowHit(knife));
            Task.WaitAll(shurikenThrowHit, knifeThrowHit);

            Console.WriteLine("---");

            pistol.Reload();
            machinegun.Reload();

            Console.WriteLine("---");

            mechanic.Upgrade(pistol);
            mechanic.Repair(pistol);
            mechanic.Upgrade(machinegun);
            mechanic.Repair(machinegun);
            mechanic.Upgrade(sword);
            mechanic.Repair(sword);
            mechanic.Upgrade(knife);
            mechanic.Repair(knife);

            Console.WriteLine("---");

            pistolShot= Task.Run(() => shooter.SingleShot(pistol));
            machinegunShot = Task.Run(() => shooter.AutoShot(machinegun));
            Task.WaitAll(pistolShot, machinegunShot);

            Console.WriteLine("---");

            swordMeleeHit = Task.Run(() => shooter.MeleeHit(sword));
            knifeMeleeHit = Task.Run(() => shooter.MeleeHit(knife));
            Task.WaitAll(swordMeleeHit, knifeMeleeHit);

            Console.WriteLine("---");

            shurikenThrowHit = Task.Run(() => shooter.ThrowHit(shuriken));
            knifeThrowHit = Task.Run(() => shooter.ThrowHit(knife));
            Task.WaitAll(shurikenThrowHit, knifeThrowHit);

            /*shooter.SingleShot(pistol);
            shooter.AutoShot(machinegun);
            shooter.MeleeHit(sword);
            shooter.ThrowHit(shuriken);
            shooter.MeleeHit(knife);
            shooter.ThrowHit(knife);

            Console.WriteLine("---");

            pistol.Reload();
            machinegun.Reload();

            Console.WriteLine("---");

            mechanic.Upgrade(pistol);
            mechanic.Repair(pistol);
            mechanic.Upgrade(machinegun);
            mechanic.Repair(machinegun);
            mechanic.Upgrade(sword);
            mechanic.Repair(sword);
            mechanic.Upgrade(knife);
            mechanic.Repair(knife);

            Console.WriteLine("---");

            shooter.SingleShot(pistol);
            shooter.AutoShot(machinegun);
            shooter.MeleeHit(sword);
            shooter.ThrowHit(shuriken);
            shooter.MeleeHit(knife);
            shooter.ThrowHit(knife);*/
        }
    }
}
