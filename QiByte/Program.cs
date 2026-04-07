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
                            stack.actionStack.Add(_ => stack.PUSH(t));
                            stack.actionStackP.Add(t);
                        }
                    } else {
                        Token name = new Token("");

                        if (Peek().val == "POP") {
                            stack.actionStack.Add(_ => stack.POP());
                        } else if (Peek().val == "DUP") {
                            stack.actionStack.Add(_ => stack.DUP()); }
                        else if (Peek().val == "SAWP") {
                            stack.actionStack.Add(_ => stack.SWAP());
                        } else if (Peek().val == "OVER") {
                            stack.actionStack.Add(_ => stack.OVER());
                        } else if (Peek().val == "DROP2") {
                            stack.actionStack.Add(_ => stack.DROP2());
                        } else if (Peek().val == "ADD") {
                            stack.actionStack.Add(_ => stack.ADD());
                        } else if (Peek().val == "SUB") {
                            stack.actionStack.Add(_ => stack.SUB());
                        } else if (Peek().val == "MUL") {
                            stack.actionStack.Add(_ => stack.MUL());
                        } else if (Peek().val == "DIV") {
                            stack.actionStack.Add(_ => stack.DIV());
                        } else if (Peek().val == "MOD") {
                            stack.actionStack.Add(_ => stack.MOD());
                        } else if (Peek().val == "NEG") {
                            stack.actionStack.Add(_ => stack.NEG());
                        } else if (Peek().val == "JMP") {
                          //  stack.actionStack.Add(_ => stack.JMP());
                        } else {
                            name = Peek();

                            Advance();

                            if(Peek().val == ":") {  stack.actionStack.Add(_ => stack.SetLabel(name)); }
                        }

                        stack.actionStackP.Add((name != null) ? name : null);
                    }
                }

                if (Peek() == null) { break; } else { if (index < tokens.Count - 1) { Advance(); } else { break; } }
            }

            stack.Start();
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
