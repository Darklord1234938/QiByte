using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiByte
{
    public class StackOne
    {
        public List<int> Stack = new List<int>();

        public StackOne() { }

        public void PUSH(Token _tok) { int.TryParse(_tok.val, out int iOut); Stack.Add(iOut); Console.WriteLine($"PUSH:{Stack[Stack.Count - 1]}"); } // 0x02
        public int POP() { int sOut = Stack[Stack.Count-1]; Stack.RemoveAt(Stack.Count-1); Console.WriteLine($"POP:{sOut}"); return sOut; } // 0x03
        public void DUP() { Token obj = new Token(POP().ToString()); PUSH(obj); PUSH(obj); } // 0x04
        public void SWAP() { Token obj1 = new Token(POP().ToString()); Token obj2 = new Token(POP().ToString()); PUSH(obj1); PUSH(obj2); } // 0x05
        public void OVER() { Token obj1 = new Token(POP().ToString()); Token obj2 = new Token(POP().ToString()); PUSH(obj2); PUSH(obj1); PUSH(obj2); } // 0x06
        // 0x07 Rotate
        public void DROP2() { POP(); POP(); } // 0x08
        // 0x09 DEPTH
        public void ADD() { Token obj1 = new Token(POP().ToString()); Token ansObj = new Token((int.Parse(obj1.val) + POP()).ToString()); PUSH(ansObj); } // 0x10 
        public void SUB() { Token obj1 = new Token(POP().ToString()); Token ansObj = new Token((int.Parse(obj1.val) - POP()).ToString()); PUSH(ansObj); } // 0x11 
        public void MUL() { Token obj1 = new Token(POP().ToString()); Token ansObj = new Token((int.Parse(obj1.val) * POP()).ToString()); PUSH(ansObj); } // 0x12 
        public void DIV() { Token obj1 = new Token(POP().ToString()); Token ansObj = new Token((int.Parse(obj1.val) / POP()).ToString()); PUSH(ansObj); } // 0x13 
        public void MOD() { Token obj1 = new Token(POP().ToString()); Token ansObj = new Token((int.Parse(obj1.val) % POP()).ToString()); PUSH(ansObj); } // 0x14 
        public void NEG() { Token ansObj = new Token((POP() * -1).ToString()); PUSH(ansObj); } // 0x15
        // 0x16 - shiftleft
        // 0x17 - shiftright
        // 0x18 - logic right shift
        // 0x19 - bitwise not


    }
}
