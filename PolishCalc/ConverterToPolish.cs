using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishCalc
{
    internal class ConverterToPolish
    {
		public event Action<int, int, char> OnResult;

		private Dictionary<char, int> _operations = new Dictionary<char, int>()
		{
			{'+', 1},
			{'-', 1},
			{'*', 2},
			{'/', 2},		// приоритет операторов
			{'(', 0},
			{'~', 4 }
        };

		public string Infiix { get; private set; }
		public string Postfix { get; private set; }

		public void Convert(string expresion)
		{
			Postfix = ToPostfix(expresion);
		}

		private string StringNumber(string expresion, int position) 
		{
			string number = "";

			for (; position < expresion.Length; position++)
			{
				char c = expresion[position];
				if(char.IsDigit(c)) number += c;
			}
			return number;
		}
		private string ToPostfix(string infix)
		{
			string postfix = "";
			Stack<char> stack = new Stack<char>();

			for (int i = 0; i < infix.Length; i++) 
			{
				char c = infix[i];
				if (char.IsDigit(c)) postfix += StringNumber(infix, i) + " ";

				if(c == '(') 
					stack.Push(c);
				else if(c == ')')
				{
					while ((stack.Count > 0) && (stack.Peek() != '('))
						postfix += stack.Pop();

					stack.Pop();
				}
				else if (_operations.ContainsKey(c))
				{
					char op = c;

					if ((op == '-') && (i == 0))
					{
						op = '~';

						while ((stack.Count > 0) && (_operations[stack.Peek()] >= _operations[op]))
							postfix += stack.Pop();

						stack.Push(op);
					}
				}
				foreach (char op in stack)
					postfix += op;

			}
			return postfix;
		}
        private int Execute(char op, int first, int second) => op switch
        {
            '+' => first + second,
            '-' => first - second,
            '*' => first * second,
            '/' => first / second,
            _ => 0  //	возвращает 0, если не был найден подходящий оператор
        };
        public double Calc()
        {
            Stack<int> locals = new();
            int counter = 0;

            for (int i = 0; i < Postfix.Length; i++)
            {
                char c = Postfix[i];

                if (char.IsDigit(c))
                {
                    string number = StringNumber(Postfix, i);
                    locals.Push(int.Parse(number));
                }
                else if (_operations.ContainsKey(c))
                {
                    counter += 1;
                    if (c == '~')
                    {
                        int last = locals.Count > 0 ? locals.Pop() : 0;
						locals.Push(Execute('-', 0, last));
                        continue;
                    }

                    int second = locals.Count > 0 ? locals.Pop() : 0, first = locals.Count > 0 ? locals.Pop() : 0;

                    locals.Push(Execute(c, first, second));
					OnResult?.Invoke(first, second, c);
                }
            }

            return locals.Pop();
        }
    }
}
