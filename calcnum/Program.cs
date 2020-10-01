using System;
using System.Collections.Generic;

namespace calcnum
{
    public class Program
    {
        public class Resultado
        {
            public double raiz { get; set; }
            public int iteracoes { get; set; }
        }

        //Definição da função
        static double Funcao(double x)
        {
            return ( Math.Pow(x, 2) - Math.Exp(-x) );
        }

        static double FuncaoFI(double x)
        {
            return ( Math.Exp(-x / 2) );
        }

        static double FuncaoL(double x)
        {
            return ( (2 * x) + Math.Exp(-x) );
        }
        
        /*
         Função para analisar quando é trocado o sinal entre os valores para
         poder encontrar o intervalo que contém uma única raiz
        */
        static void ChecarSinais(int[] valores)
        {
            for(int i = 0; i < valores.Length; ++i)
                Console.WriteLine(string.Format("Valor:[{0}]\tSinal:[{1}]", valores[i], Math.Sign(Funcao(valores[i]))));
        }

        /*
        Encontrar intervalo que contém uma única raiz: quando há troca de sinal entre os valores
        f(e) = 0 / 'e' é a raiz de f(x)
        Método da bissecção: onde cruzar o eixo y = 0 é a raiz (e)
        x => raiz procurada
        k => número de iterações
        [a, b] => intervalo que contém uma única 
        p => precisão 
        */
        static Resultado Bisseccao(double a, double b, double p)
        {
            int k = 0;
            double x = 0;
            while(Math.Abs(a - b) > p)
            {
                ++k;
                x = (a + b) / 2;
                if((Funcao(a) * Funcao(x)) > 0)
                {
                    x = a;
                }
                else
                {
                    x = b;
                }
            }
            return new Resultado { raiz = x, iteracoes = k };
        }
        
        /*
        Função de iteração: iguala a função a 0 e isola o x (escolher a raiz positiva)
        Derivar
        xo => aproximação inicial
        */
        static Resultado MIL(double xo, double p)
        {
            int k = 1;
            double x = FuncaoFI(xo);
            while (Math.Abs(x - xo) > p)
            {
                ++k;
                xo = x;
                x = FuncaoFI(xo);
            }
            return new Resultado { raiz = x, iteracoes = k };
        }

        /*
        Derivar duas vezes e que sejam não nulas e preservem o sinal de [a, b]
        xo seja tal que f(xo)*f''(xo) > 0
        */
        static Resultado NewtonRaphson(double xo, double p)
        {
            int k = 1;
            double x = xo - (Funcao(xo) / FuncaoL(xo));
            while(Math.Abs(x - xo) > p)
            {
                ++k;
                xo = x;
                x = xo - (Funcao(xo) / FuncaoL(xo));
            }
            return new Resultado { raiz = x, iteracoes = k };
        }

        static void Main(string[] args)
        {
            //ChecarSinais(new int[] { -3, -2, -1, 0, 1, 2 });

            //Console.WriteLine("Bissecção");
            //Resultado b = Bisseccao(0, 1, 1 * Math.Pow(10, -8));
            //Console.WriteLine("x = " + b.raiz);
            //Console.WriteLine("k = " + b.iteracoes);

            Console.WriteLine("MIL");
            Resultado m = MIL(0, 1 * Math.Pow(10, -8));
            Console.WriteLine("x = " + m.raiz);
            Console.WriteLine("k = " + m.iteracoes);

            Console.WriteLine("Newton Raphson");
            Resultado n = NewtonRaphson(0, 1 * Math.Pow(10, -8));
            Console.WriteLine("x = " + n.raiz);
            Console.WriteLine("k = " + n.iteracoes);
            Console.ReadKey();
        }
    }
}
