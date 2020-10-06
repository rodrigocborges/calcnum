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

        // Definição das funções: FuncaoX_Y, Sendo 'X' o exercício e 'Y' a questão; D indica derivada
        static double Funcao1_1(double x)
        {
            return ( Math.Cosh(x) - (2 * Math.Exp(-0.3 * x)) );
        }

        static double Funcao1_1D(double x)
        {
            return ( Math.Sinh(x) + (3/5 * Math.Exp(-0.3 * x)) );
        }

        static double Funcao1_2(double x)
        {
            return ( -2 + 7 * x - 5 * Math.Pow(x, 2) + 6 * Math.Pow(x, 3) );
        }

        static double Funcao1_3(double x)
        {
            return ( (-0.4 * Math.Pow(x, 2)) + (2 * 2 * x) + (4 * 7) );
        }

        static double Funcao1_3D(double x)
        {
            return (4 - (4 * x / 5));
        }

        static double Funcao1_4(double x)
        {
            return ( 0.9 - (0.4 * x) ) / x;
        }

        static double Funcao2(double x)
        {
            return ( (-1 / x) * ( Math.Sinh(-30 * x) - Math.Sinh(15 * x) ) - 120 );
        }

        static double Funcao2D(double x)
        {
            return ( (-Math.Sinh(30 * x) - Math.Sinh(15 * x)) / Math.Pow(x, 2) - (-30 * Math.Cosh(30 * x) - 15 * Math.Cosh(15 * x)) / x);
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
                if((Funcao1_1(a) * Funcao1_1(x)) > 0)
                {
                    a = x;
                }
                else
                {
                    b = x;
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

        static double fa(double x)
        {
            return (Math.Pow(x, 3) - (9 * x) + 5);
        }

        static double fal(double x)
        {
            return (3 * Math.Pow(x, 2) - 9);
        }

        static Resultado NewtonRaphson(double xo, double p)
        {
            int k = 1;
            double x = xo - (Funcao1_3(xo) / Funcao1_3D(xo));
            while(Math.Abs(x - xo) > p)
            {
                ++k;
                xo = x;
                x = xo - (Funcao1_3(xo) / Funcao1_3D(xo));
            }
            return new Resultado { raiz = x, iteracoes = k };
        }

        static void Main(string[] args)
        {
            //ChecarSinais(new int[] { -3, -2, -1, 0, 1, 2 });

            /*Console.WriteLine("Bissecção");
            Resultado b = Bisseccao(-5, 0, 0.001);
            Console.WriteLine("Raiz procurada (x): " + b.raiz);
            Console.WriteLine("Número de iterações (k): " + b.iteracoes);
            
            Console.WriteLine("MIL");
            Resultado m = MIL(0, 1 * Math.Pow(10, -8));
            Console.WriteLine("x = " + m.raiz);
            Console.WriteLine("k = " + m.iteracoes);
            */
            Console.WriteLine("Newton Raphson");
            Resultado n = NewtonRaphson(5, 0.001);
            Console.WriteLine("x = " + n.raiz);
            Console.WriteLine("k = " + n.iteracoes);
            Console.ReadKey();
        }
    }
}
