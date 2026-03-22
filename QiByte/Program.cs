using System.Text.RegularExpressions;

namespace QiByte
{
    public class Program
    {
        static int index = 0;
        static List<Token> tokens = new List<Token>();

        static StackOne stack = new StackOne();

        static Token Peek() { return tokens[index]; }
        static Token Advance() { index++; return Peek(); }

        static void Main(string[] args) {
            tokens = Parse("PUSH 10 PUSH 4 ADD POP");

            while (true) {
                if(Peek().tType == TokenType.ID) {
                    if (Peek().val == "PUSH") {
                        Token t = Advance();
                        if (t.tType == TokenType.NUM) {
                            stack.PUSH(t);
                        }
                    } else  if (Peek().val == "POP") {
                        stack.POP();
                    } else if (Peek().val == "DUP") {
                        stack.DUP();
                    } else if (Peek().val == "SAWP") {
                        stack.SWAP();
                    } else if (Peek().val == "OVER") {
                        stack.OVER();
                    } else if (Peek().val == "DROP2") {
                        stack.DROP2();
                    }
                    else if (Peek().val == "ADD")
                    {
                        stack.ADD();
                    }
                    else if (Peek().val == "DROP2")
                    {
                        stack.DROP2();
                    }
                    else if (Peek().val == "DROP2")
                    {
                        stack.DROP2();
                    }
                    else if (Peek().val == "DROP2")
                    {
                        stack.DROP2();
                    }
                    else if (Peek().val == "DROP2")
                    {
                        stack.DROP2();
                    }
                }

                if (Peek() == null) { break; } else { if (index < tokens.Count - 1) { Advance(); } else { break; } }
            }
        }

        static List<Token> Parse(string _input) {
            List<Token> tList = new List<Token>();
            var regex = new Regex(@"\S+", RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(_input);

            foreach (var m in matches)
            {
                Console.WriteLine(m.ToString());
                tList.Add(new Token(m.ToString()));
            }

            return tList;
        }
    }
}
