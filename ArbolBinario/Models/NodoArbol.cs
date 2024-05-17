namespace ArbolBinario.Models
{
    internal class NodoArbol
    {
        public NodoArbol? subArbolIzquierdo { get; set; }
        public NodoArbol? subArbolDerecho { get; set; }
        public object? info { get; set; }

        public NodoArbol()
        {
            subArbolIzquierdo = null;
            subArbolDerecho = null;
            info = null;
        }

        public NodoArbol(object? _info)
        {
            info = _info;
            subArbolDerecho=null;
            subArbolIzquierdo=null;
        }

        public NodoArbol(NodoArbol? _subArbolIzquierdo, NodoArbol? _subArbolDerecho, object? _info)
        {
            subArbolIzquierdo = _subArbolIzquierdo;
            subArbolDerecho = _subArbolDerecho;
            info = _info;
        }

        public override string ToString()
        {
            return $"/{info}\\";
        }
    }
}
