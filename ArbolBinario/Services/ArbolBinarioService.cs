using ArbolBinarioBlazor.Models;

namespace ArbolBinarioBlazor.Services
{
    internal class ArbolBinarioService
    {
        public NodoArbol? NodoRaiz { get; set; }
        //public int TotalNodos { get; set; } //
        public string Respuesta { get; set; } = string.Empty;//

        public ArbolBinarioService()
        {
            NodoRaiz = null;
            //TotalNodos = 0;
        }

        public bool EstaVacio()
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

        public void AgregarNodo(string infoNodo, string infoNodoIzquierdo = "", string infoNodoDerecho = "")
        {
            if (EstaVacio())
            {
                NodoRaiz = CrearNodo(infoNodo);
            }
            else
            {
                NodoArbol nodo = BuscarNodo(NodoRaiz, infoNodo);
                if (nodo != null)
                {
                    if (!string.IsNullOrEmpty(infoNodoIzquierdo))
                    {
                        nodo.SubArbolIzquierdo = CrearNodo(infoNodoIzquierdo);
                    }
                    if (!string.IsNullOrEmpty(infoNodoDerecho))
                    {
                        nodo.SubArbolDerecho = CrearNodo(infoNodoDerecho);
                    }
                }
            }
        }

        private NodoArbol? BuscarNodo(NodoArbol? nodoActual, string infoNodo)
        {
            if (nodoActual == null) return null;

            if (nodoActual.Info == infoNodo)
            {
                return nodoActual;
            }

            NodoArbol? nodoEncontrado = BuscarNodo(nodoActual.SubArbolIzquierdo, infoNodo);
            if (nodoEncontrado == null)
            {
                nodoEncontrado = BuscarNodo(nodoActual.SubArbolDerecho, infoNodo);
            }

            return nodoEncontrado;
        }

        public void EliminarNodo(string info)
        {
            NodoRaiz = EliminarNodoRecursivo(NodoRaiz, info);
        }

        private NodoArbol? EliminarNodoRecursivo(NodoArbol? nodo, string info)
        {
            if (nodo == null) return null;

            if (info == nodo.Info)
            {
                if (nodo.SubArbolIzquierdo == null && nodo.SubArbolDerecho == null)
                {

                    return null;
                }

                if (nodo.SubArbolIzquierdo == null)
                {
                    return nodo.SubArbolDerecho;
                }

                if (nodo.SubArbolDerecho == null)
                {
                    return nodo.SubArbolIzquierdo;
                }

                NodoArbol sucesorD = ObtenerMinimo(nodo.SubArbolDerecho);
                nodo.Info = sucesorD.Info;
                nodo.SubArbolDerecho = EliminarNodoRecursivo(nodo.SubArbolDerecho, sucesorD.Info);

                NodoArbol sucesorI = ObtenerMinimo(nodo.SubArbolIzquierdo);
                nodo.Info = sucesorI.Info;
                nodo.SubArbolIzquierdo = EliminarNodoRecursivo(nodo.SubArbolIzquierdo, sucesorI.Info);
            }
            else if (string.Compare(info, nodo.Info) < 0)
            {
                nodo.SubArbolIzquierdo = EliminarNodoRecursivo(nodo.SubArbolIzquierdo, info);
            }
            else
            {
                nodo.SubArbolDerecho = EliminarNodoRecursivo(nodo.SubArbolDerecho, info);
            }

            //if (nodo != null)
            //{
            //    if (nodo.SubArbolIzquierdo != null && nodo.SubArbolDerecho != null &&
            //        nodo.SubArbolIzquierdo.SubArbolDerecho != null)
            //    {
            //        // Reorganizamos el árbol
            //        NodoArbol temp = nodo.SubArbolIzquierdo.SubArbolDerecho;
            //        nodo.SubArbolIzquierdo.SubArbolDerecho = temp.SubArbolIzquierdo;
            //        temp.SubArbolIzquierdo = nodo.SubArbolIzquierdo;
            //        nodo.SubArbolIzquierdo = temp;
            //    }
            //}

            return nodo;
        }

        private NodoArbol ObtenerMinimo(NodoArbol nodo)
        {
            while (nodo.SubArbolIzquierdo != null)
            {
                nodo = nodo.SubArbolIzquierdo;
            }
            return nodo;
        }

        //private bool AgregarNodoRecursivo(NodoArbol nodoActual, string infoPadre, string infoNodo, bool esIzquierdo)
        //{
        //    if (nodoActual == null) return false;

        //    if (nodoActual.Info == infoPadre)
        //    {
        //        if (esIzquierdo)
        //        {
        //            if (nodoActual.SubArbolIzquierdo == null)
        //                nodoActual.SubArbolIzquierdo = CrearNodo(infoNodo);
        //            else
        //                return false; // Nodo izquierdo ya existe
        //        }
        //        else
        //        {
        //            if (nodoActual.SubArbolDerecho == null)
        //                nodoActual.SubArbolDerecho = CrearNodo(infoNodo);
        //            else
        //                return false; // Nodo derecho ya existe
        //        }
        //        return true;
        //    }

        //    return AgregarNodoRecursivo(nodoActual.SubArbolIzquierdo, infoPadre, infoNodo, esIzquierdo) ||
        //           AgregarNodoRecursivo(nodoActual.SubArbolDerecho, infoPadre, infoNodo, esIzquierdo);
        //}

        //public void PoblarArbol(NodoArbol nodo, string infoIzquierdo, string infoDerecho)
        //{
        //    if (EstaVacio())
        //    {
        //        NodoRaiz = nodo;
        //    }

        //    if (!string.IsNullOrEmpty(infoIzquierdo))
        //    {
        //        nodo.SubArbolIzquierdo = CrearNodo(infoIzquierdo);
        //    }

        //    if (!string.IsNullOrEmpty(infoDerecho))
        //    {
        //        nodo.SubArbolDerecho = CrearNodo(infoDerecho);
        //    }
        //}

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

        public void RecorridoPreordenRecursivo(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            recorrido.Add(nodo.Info);
            RecorridoPreordenRecursivo(nodo.SubArbolIzquierdo, recorrido);
            RecorridoPreordenRecursivo(nodo.SubArbolDerecho, recorrido);
        }

        public void RecorridoInordenRecursivo(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            RecorridoInordenRecursivo(nodo.SubArbolIzquierdo, recorrido);
            recorrido.Add(nodo.Info);
            RecorridoInordenRecursivo(nodo.SubArbolDerecho, recorrido);
        }

        public void RecorridoPostordenRecursivo(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null) return;

            RecorridoPostordenRecursivo(nodo.SubArbolIzquierdo, recorrido);
            RecorridoPostordenRecursivo(nodo.SubArbolDerecho, recorrido);
            recorrido.Add(nodo.Info);
        }

        //public void RecorridoPreordenIterativo(NodoArbol nodo, List<string> recorrido)
        //{
        //    if (nodo == null) return;

        //    Stack<NodoArbol> pila = new Stack<NodoArbol>();
        //    pila.Push(nodo);

        //    while (pila.Count > 0)
        //    {
        //        NodoArbol actual = pila.Pop();
        //        recorrido.Add(actual.Info);

        //        if (actual.SubArbolDerecho != null)
        //        {
        //            pila.Push(actual.SubArbolDerecho);
        //        }

        //        if (actual.SubArbolIzquierdo != null)
        //        {
        //            pila.Push(actual.SubArbolIzquierdo);
        //        }
        //    }
        //}

        //public void RecorridoInordenIterativo(NodoArbol nodo, List<string> recorrido)
        //{
        //    if (nodo == null) return;

        //    Stack<NodoArbol> pila = new Stack<NodoArbol>();
        //    NodoArbol? actual = nodo;

        //    while (actual != null || pila.Count > 0)
        //    {
        //        while (actual != null)
        //        {
        //            pila.Push(actual);
        //            actual = actual.SubArbolIzquierdo;
        //        }

        //        actual = pila.Pop();
        //        recorrido.Add(actual.Info);
        //        actual = actual.SubArbolDerecho;
        //    }
        //}

        //public void RecorridoPostordenIterativo(NodoArbol nodo, List<string> recorrido)
        //{
        //    if (nodo == null) return;

        //    Stack<NodoArbol> pila1 = new Stack<NodoArbol>();
        //    Stack<NodoArbol> pila2 = new Stack<NodoArbol>();

        //    pila1.Push(nodo);

        //    while (pila1.Count > 0)
        //    {
        //        NodoArbol actual = pila1.Pop();
        //        pila2.Push(actual);

        //        if (actual.SubArbolIzquierdo != null)
        //        {
        //            pila1.Push(actual.SubArbolIzquierdo);
        //        }

        //        if (actual.SubArbolDerecho != null)
        //        {
        //            pila1.Push(actual.SubArbolDerecho);
        //        }
        //    }

        //    while (pila2.Count > 0)
        //    {
        //        recorrido.Add(pila2.Pop().Info);
        //    }
        //}

        public void RecorridoInordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol? actual = nodo;

            while (actual != null)
            {
                if (actual.SubArbolIzquierdo == null)
                {
                    recorrido.Add(actual.Info);
                    actual = actual.SubArbolDerecho;
                }
                else
                {
                    NodoArbol predecesor = actual.SubArbolIzquierdo;
                    while (predecesor.SubArbolDerecho != null && predecesor.SubArbolDerecho != actual)
                    {
                        predecesor = predecesor.SubArbolDerecho;
                    }

                    if (predecesor.SubArbolDerecho == null)
                    {
                        predecesor.SubArbolDerecho = actual;
                        actual = actual.SubArbolIzquierdo;
                    }
                    else
                    {
                        predecesor.SubArbolDerecho = null;
                        recorrido.Add(actual.Info);
                        actual = actual.SubArbolDerecho;
                    }
                }
            }
        }

        public void RecorridoPreordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol? actual = nodo;

            while (actual != null)
            {
                if (actual.SubArbolIzquierdo == null)
                {
                    recorrido.Add(actual.Info);
                    actual = actual.SubArbolDerecho;
                }
                else
                {
                    NodoArbol predecesor = actual.SubArbolIzquierdo;
                    while (predecesor.SubArbolDerecho != null && predecesor.SubArbolDerecho != actual)
                    {
                        predecesor = predecesor.SubArbolDerecho;
                    }

                    if (predecesor.SubArbolDerecho == null)
                    {
                        predecesor.SubArbolDerecho = actual;
                        recorrido.Add(actual.Info);
                        actual = actual.SubArbolIzquierdo;
                    }
                    else
                    {
                        predecesor.SubArbolDerecho = null;
                        actual = actual.SubArbolDerecho;
                    }
                }
            }
        }

        public void RecorridoPostordenIterativo(NodoArbol nodo, List<string> recorrido)
        {
            NodoArbol nodoTemporal = new NodoArbol { SubArbolIzquierdo = nodo };
            NodoArbol? actual = nodoTemporal;

            while (actual != null)
            {
                if (actual.SubArbolIzquierdo == null)
                {
                    actual = actual.SubArbolDerecho;
                }
                else
                {
                    NodoArbol predecesor = actual.SubArbolIzquierdo;
                    while (predecesor.SubArbolDerecho != null && predecesor.SubArbolDerecho != actual)
                    {
                        predecesor = predecesor.SubArbolDerecho;
                    }

                    if (predecesor.SubArbolDerecho == null)
                    {
                        predecesor.SubArbolDerecho = actual;
                        actual = actual.SubArbolIzquierdo;
                    }
                    else
                    {
                        AddNodesReverse(actual.SubArbolIzquierdo, predecesor, recorrido);
                        predecesor.SubArbolDerecho = null;
                        actual = actual.SubArbolDerecho;
                    }
                }
            }
        }

        private void AddNodesReverse(NodoArbol from, NodoArbol to, List<string> recorrido)
        {
            List<string> temp = new List<string>();
            NodoArbol? current = from;
            while (current != to)
            {
                temp.Add(current.Info);
                current = current.SubArbolDerecho;
            }
            temp.Add(to.Info);
            temp.Reverse();
            recorrido.AddRange(temp);
        }
    }
}
