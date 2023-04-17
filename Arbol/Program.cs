using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arbol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nodo nodo1 = new Nodo(4);
            Nodo nodo2 = new Nodo(1);
            Nodo nodo3 = new Nodo(5);
            nodo3.NodosHijos.Add(nodo1);
            nodo3.NodosHijos.Add(nodo2);
            Nodo nodo4 = new Nodo(2);
            Nodo nodo5 = new Nodo(3);
            nodo4.NodosHijos.Add(nodo5);
            Nodo nodo6 = new Nodo(1);
            Nodo nodo7 = new Nodo(4);
            nodo7.NodosHijos.Add(nodo6);
            nodo7.NodosHijos.Add(nodo4);
            nodo7.NodosHijos.Add(nodo3);

            int peso = CalcularPesoArbol(nodo7);
            int cantidadNodos = ContarNodos(nodo7, true);
            decimal pesoPromedio = CalcularPesoPromedio(peso, cantidadNodos);
        }

        public static int CalcularPesoArbol(Nodo nodo)
        {
            int peso = nodo.ValorNodo;

            if (nodo.NodosHijos.Any() && nodo.NodosHijos.Count > 0)
            {
                foreach (Nodo item in nodo.NodosHijos)
                {
                    peso += CalcularPesoArbol(item);
                }
            }

            return peso;
        }

        public static int ContarNodos(Nodo nodo, bool raiz)
        {
            int cantidad = nodo.NodosHijos.Count;

            cantidad = raiz ? cantidad += 1 : cantidad;

            if (nodo.NodosHijos.Any() && nodo.NodosHijos.Count > 0)
            {
                foreach (Nodo item in nodo.NodosHijos)
                {
                    cantidad += ContarNodos(item, false);
                }
            }

            return cantidad;
        }

        public static decimal CalcularPesoPromedio(decimal pesoArbol, decimal cantidadNodos)
        {
            return pesoArbol / cantidadNodos;
        }
    }

    public class Nodo
    {
        public int ValorNodo;
        public List<Nodo> NodosHijos;

        public Nodo(int valor)
        {
            ValorNodo = valor;
            NodosHijos = new List<Nodo>();
        }
    }

    public class Arbol
    {
        public Nodo RaizArbol;

        public Arbol(int raiz)
        {
            RaizArbol = new Nodo(raiz);
        }
    }
}
