using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public interface IMeleeWeapons : IUpgrade, IRepairible
    {
        public int MeleeDamage { get; set; }

        public void MeleeHit();
    }
}
