namespace ArbolBinarioBlazor.Models
{
    public class NodoArbol
    {
        public NodoArbol? SubArbolIzquierdo { get; set; }
        public NodoArbol? SubArbolDerecho { get; set; }
        public string Info { get; set; }

        public NodoArbol()
        {
            SubArbolIzquierdo = null;
            SubArbolDerecho = null;
            Info = null;
        }

        public NodoArbol(string info)
        {
            Info = info;
            SubArbolIzquierdo = null;
            SubArbolDerecho = null;
        }

        public NodoArbol(NodoArbol? subArbolIzquierdo, NodoArbol? subArbolDerecho, string? info)
        {
            SubArbolIzquierdo = subArbolIzquierdo;
            SubArbolDerecho = subArbolDerecho;
            Info = info;
        }

        public override string ToString()
        {
            return $"/{Info}\\";
        }
    }
}
