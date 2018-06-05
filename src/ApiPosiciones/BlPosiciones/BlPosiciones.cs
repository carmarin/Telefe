using System;
using System.Linq;

namespace BlPosiciones
{
    public enum Direccion
    {
        Arriba,
        Abajo,
        Derecha,
        Izquierda,
        IzquierdaAbajo,
        IzquierdaArriba,
        DerechaAbajo,
        DerechaArriba,
        Ninguna
    }
    public class BlPosiciones
    {
        #region Campos
        private string palabra;
        char[,] arreglo;
        private string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };

        int largo = 0;
        int ancho = 0;
        bool encontrado = false;
        int[,] solucion;
        #endregion
        public BlPosiciones()
        {
        }
        
        /// <summary>
        /// Método de entrada y que se expone, devuelve una matriz con la posición donde se 
        /// encuentra la palabra dentro del array, busca sin importar mayusculas ni minusculas
        /// </summary>
        /// <param name="palabra">Palabra a buscar</param>
        /// <returns>Matríz con las posiciones donde se encuentra la palabra</returns>
        public int[,] GetPosiciones(string palabra)
        {
            this.palabra = palabra.ToUpper();
            arreglo = convertirArray(secuencias);
            solucion = new int[palabra.Length, 2];
            BuscarPalabra();
            return solucion;
        }

        /// <summary>
        /// Toma el arreglo dado como parametro y lo convierte en una matriz de
        /// char 
        /// </summary>
        /// <param name="arreglo">Arreglo que se desea convertir</param>
        /// <returns>Matriz de char</returns>
        private char[,] convertirArray(string[] arreglo)
        {
            int contador = 0;
            foreach (var palabra in arreglo)
            {
                if (ancho < palabra.Length)
                {
                    ancho = palabra.Length;
                }
            }
            largo = arreglo.Length;
            char[,] lineArray = new char[largo, ancho];
            Console.WriteLine(arreglo.Length + "x" + ancho);
            foreach (var palabra in arreglo)
            {
                for (int i = 0; i < palabra.Length; i++)
                {
                    lineArray[contador, i] = palabra.ToUpper()[i];
                }

                contador++;
            }

            return lineArray;
        }

        /// <summary>
        /// Método recursivo que busca en todas las direcciones si algún elemento
        /// cercano cumple las condiciones para continuar con la búsqueda
        /// </summary>
        /// <param name="x">Posición actual x donde se encuentra el arreglo</param>
        /// <param name="y">Posición actual y donde se encuentra actualmente en el arreglo</param>
        /// <param name="letraActual">Indice de la letra actual a buscar.</param>
        /// <param name="posiciones">Posiciones actuales que se han encontrado en la búsqueda</param>
        /// <param name="direccionB">Dirección hacia donde se busca actualmente, ninguno en caso de que se deba buscar en todas las direcciones</param>
        /// <returns>Devuelve un arreglo de posiciones indicando las palabras encontradas</returns>
        private int[,] BuscarElementosCercanos(int x, int y, int letraActual, int[,] posiciones, Direccion direccionB)
        {
            if (letraActual >= palabra.Length)
            {
                return solucion;
            }
            char currentChar = palabra[letraActual];
            if (direccionB == Direccion.Ninguna)
            {
                if (x + 1 < ancho && arreglo[y, x + 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x + 1, y, letraActual, Direccion.Derecha) != null)
                    {
                        return posiciones;
                    }
                }
                if (y + 1 < largo && arreglo[y + 1, x] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x, y + 1, letraActual, Direccion.Abajo) != null)
                    {
                        return posiciones;
                    }
                }
                if (y - 1 > 0 && arreglo[y - 1, x] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x, y - 1, letraActual, Direccion.Arriba) != null)
                    {
                        return posiciones;
                    }
                }
                if (x - 1 > 0 && arreglo[y, x - 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x - 1, y, letraActual, Direccion.Izquierda) != null)
                    {
                        return posiciones;
                    }
                }
                if (x + 1 < ancho && y - 1 > 0 && arreglo[y - 1, x + 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x + 1, y - 1, letraActual, Direccion.DerechaArriba) != null)
                    {
                        return posiciones;
                    }
                }
                if (y + 1 < largo && x + 1 < ancho && arreglo[y + 1, x + 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x + 1, y + 1, letraActual, Direccion.DerechaAbajo) != null)
                    {
                        return posiciones;
                    }
                }
                if (y + 1 > 0 && x - 1 > 0 && arreglo[y + 1, x - 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x - 1, y + 1, letraActual, Direccion.IzquierdaAbajo) != null)
                    {
                        return posiciones;
                    }
                }
                if (x - 1 > 0 && y - 1 > 0 && arreglo[y - 1, x - 1] == currentChar)
                {
                    if (BusquedaPuntual(posiciones, x - 1, y - 1, letraActual, Direccion.IzquierdaArriba) != null)
                    {
                        return posiciones;
                    }
                }
                return null;
            }
            else
            {
                if (Direccion.Derecha == direccionB && x + 1 <= ancho && arreglo[y, x + 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x + 1, y, letraActual, Direccion.Derecha);
                }
                else if (Direccion.Abajo == direccionB && y + 1 < largo && arreglo[y + 1, x] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x, y + 1, letraActual, Direccion.Abajo);
                }
                else if (Direccion.Arriba == direccionB && y - 1 > 0 && arreglo[y - 1, x] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x, y - 1, letraActual, Direccion.Arriba);
                }
                else if (Direccion.Izquierda == direccionB && x - 1 >= 0 && arreglo[y, x - 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x - 1, y, letraActual, Direccion.Izquierda);
                }
                else if (Direccion.DerechaArriba == direccionB && x + 1 <= ancho && y - 1 > 0 && arreglo[y - 1, x + 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x + 1, y - 1, letraActual, Direccion.DerechaArriba);
                }
                else if (Direccion.DerechaAbajo == direccionB && y + 1 < largo && x + 1 <= ancho && arreglo[y + 1, x + 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x + 1, y + 1, letraActual, Direccion.DerechaAbajo);
                }
                else if (Direccion.IzquierdaAbajo == direccionB && y + 1 < largo && x - 1 >= 0 && arreglo[y + 1, x - 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x - 1, y + 1, letraActual, Direccion.IzquierdaAbajo);
                }
                else if (Direccion.IzquierdaArriba == direccionB && x - 1 >= 0 && y - 1 > 0 && arreglo[y - 1, x - 1] == currentChar)
                {
                    return BusquedaPuntual(posiciones, x - 1, y - 1, letraActual, Direccion.IzquierdaArriba);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Función auxiliar que ayuda en la recursividad setea los parametros necesarios para 
        /// el llamado a la función principal.
        /// </summary>
        /// <param name="posiciones">Posiciones actualmente encontradas</param>
        /// <param name="x">Coordenada x donde se encontro coincidencia</param>
        /// <param name="y">Coordenada y donde se encontro coincidencia</param>
        /// <param name="letraActual">Indice de la letra en la palabra que se busca.</param>
        /// <param name="direccion">Dirección hacia donde se busca la palabra</param>
        /// <returns>Un arreglo de posiciones indicando donde se encuentra la palabra</returns>
        private int[,] BusquedaPuntual(int[,] posiciones, int x, int y, int letraActual, Direccion direccion)
        {
            int[,] posicionActual = posiciones;
            posiciones[letraActual, 0] = x + 1;
            posiciones[letraActual, 1] = y + 1;
            letraActual++;
            return BuscarElementosCercanos(x, y, letraActual, posiciones, direccion);
        }

        /// <summary>
        /// Método que hace un recorrido por toda la matriz buscando posibles
        /// coincidencias 
        /// </summary>
        public void BuscarPalabra()
        {
            for (int x = 0; x < ancho; x++)
            {
                for (int y = 0; y < largo; y++)
                {
                    if (encontrado)
                        break;
                    if (arreglo[y, x] == palabra[0])
                    {
                        solucion[0, 0] = x + 1;
                        solucion[0, 1] = y + 1;
                        solucion = BuscarElementosCercanos(x, y, 1, solucion, Direccion.Ninguna);
                        if (solucion == null)
                        {
                            solucion = new int[palabra.Length, 2];
                        }
                        else
                        {
                            encontrado = true;
                        }
                    }
                }
            }

        }
    }
}
