using ArbolBinarioBlazor.Models;

namespace ArbolBinarioBlazor.Services
{
    internal class ArbolBinarioService
    {
        public NodoArbol? NodoRaiz { get; set; }
        public int TotalNodos { get; set; } //
        public string Respuesta = string.Empty;//

        public ArbolBinarioService()
        {
            NodoRaiz = null;
            //TotalNodos = 0;
        }

        bool EstaVacio()
        {
            return NodoRaiz == null;
        }

        public NodoArbol CrearNodo(string info)
        {

            /*
             NodoArbol nuevoNodo = new NodoArbol();
             
            if(EstaVacio())
             {
                Console.WriteLine("Ingrese la información para el Nodo Raíz: ");
                nuevoNodo.Info = Console.ReadLine();

                NodoRaiz = nuevoNodo;
             }
            else 
             {
                Console.WriteLine("Ingrese la información para el nuevo Nodo: ");
                nuevoNodo.Info = Console.ReadLine();
             }
             
            return nuevoNodo;
             
             */

            return new NodoArbol(info);
        }

        //public void PoblarArbol(NodoArbol nodo)
        //{
        //    if (ArbolVacio())
        //    {
        //        nodo = CrearNodo();
        //        NodoRaiz = nodo;
        //    }

        //    Console.WriteLine($"Existe nodo por la izq. de {nodo.Informacion}");
        //    respuesta = Console.ReadLine().ToString().Trim().ToLower();

        //    if (respuesta.Equals("s"))
        //    {
        //        NodoArbol nuevoNodo = new NodoArbol();
        //        nuevoNodo = CrearNodo();

        //        nodo.RamaIzquierda = nuevoNodo;

        //        PoblarArbol(nodo.RamaIzquierda);


        //    }

        //    // rama derecha
        //    Console.WriteLine($"Existe nodo por la der. de {nodo.Informacion}");
        //    respuesta = Console.ReadLine().ToString().Trim().ToLower();

        //    if (respuesta.Equals("s"))
        //    {
        //        NodoArbol nuevoNodo = new NodoArbol();
        //        nuevoNodo = CrearNodo();

        //        nodo.RamaDerecha = nuevoNodo;

        //        PoblarArbol(nodo.RamaDerecha);


        //    }

        //}

        public void PoblarArbol(NodoArbol nodo, string infoIzquierdo, string infoDerecho)
        {
            if (EstaVacio())
            {
                NodoRaiz = nodo;
            }

            if (!string.IsNullOrEmpty(infoIzquierdo))
            {
                nodo.SubArbolIzquierdo = CrearNodo(infoIzquierdo);
            }

            if (!string.IsNullOrEmpty(infoDerecho))
            {
                nodo.SubArbolDerecho = CrearNodo(infoDerecho);
            }
        }

        //public void RecorridoPreorden(NodoArbol nodo, List<string> recorrido)
        //{
        //    if (nodo == null)
        //    {
        //        return;
        //    }

        //    recorrido.Add(nodo.Info);
        //    RecorridoPreorden(nodo.SubArbolIzquierdo, recorrido);
        //    RecorridoPreorden(nodo.SubArbolDerecho, recorrido);
        //}

        //public void RecorridoInorden(NodoArbol nodo, List<string> recorrido)
        //{
        //    if (nodo == null)
        //    {
        //        return;
        //    }

        //    RecorridoInorden(nodo.SubArbolIzquierdo, recorrido);
        //    recorrido.Add(nodo.Info);
        //    RecorridoInorden(nodo.SubArbolDerecho, recorrido);
        //}
    }
}
