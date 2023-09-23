using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambridgeExam
{
    internal class question
    {
        public int id;
        public string enunt, a, b, c, d, corect, raspuns;
        public question(int pid, string pe, string pa, string pb, string pc, string pd, string cr)
        {
            id = pid;
            enunt = pe;
            a = pa;
            b = pb;
            c = pc;
            d = pd;
            corect = cr;
            raspuns = "";
        }
       
    }
}
