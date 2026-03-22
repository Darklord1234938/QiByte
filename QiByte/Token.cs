using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiByte
{
    public enum TokenType {
        NONE,
        ID,
        NUM,
    }

    public class Token {
        public string val;
        public TokenType tType;

        public Token(string _str) {
            val = _str;
            tType = (int.TryParse(val, out int i) || float.TryParse(val, out float f )) ? TokenType.NUM : TokenType.ID ;
        }

        public String ToString()
        {
            return $"Val:{val}, Type:{tType}";
        }
    }
}
