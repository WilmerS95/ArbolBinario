namespace ArbolBinarioBlazor.Models
{
    public class NodoArbol
    {
        public NodoArbol? SubArbolIzquierdo { get; set; }
        public NodoArbol? SubArbolDerecho { get; set; }
        public string? Info { get; set; }

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

        public override string ToString()
        {
            return $"/{Info}\\";
        }
    }
}
