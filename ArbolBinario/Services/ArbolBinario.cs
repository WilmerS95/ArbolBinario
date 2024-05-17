using ArbolBinarioBlazor.Models;

namespace ArbolBinarioBlazor.Services
{
    public class ArbolBinarioService
    {
        public NodoArbol? NodoRaiz { get; set; }

        public ArbolBinarioService()
        {
            NodoRaiz = null;
        }

        public bool EstaVacio()
        {
            return NodoRaiz == null;
        }

        public NodoArbol CrearNodo(string info)
        {
            return new NodoArbol(info);
        }

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

        public void RecorridoPreorden(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null)
            {
                return;
            }

            recorrido.Add(nodo.Info);
            RecorridoPreorden(nodo.SubArbolIzquierdo, recorrido);
            RecorridoPreorden(nodo.SubArbolDerecho, recorrido);
        }

        public void RecorridoInorden(NodoArbol nodo, List<string> recorrido)
        {
            if (nodo == null)
            {
                return;
            }

            RecorridoInorden(nodo.SubArbolIzquierdo, recorrido);
            recorrido.Add(nodo.Info);
            RecorridoInorden(nodo.SubArbolDerecho, recorrido);
        }
    }
}
