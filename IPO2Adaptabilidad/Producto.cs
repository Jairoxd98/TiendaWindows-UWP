using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPO2_Amazon
{

    public class Producto
    {
        private int id;
        private string nombre;
        private double precio;
        private string imagen;
        private int puntuacion;
        private Boolean pulsado;
        private string descripcion;

        public Producto(int id, string nombre, double precio, string imagen, int puntuacion, Boolean pulsado,string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.imagen = imagen;
            this.puntuacion = puntuacion;
            this.pulsado = pulsado;
            this.descripcion = descripcion;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getPuntuacion()
        {
            return this.puntuacion;
        }

        public void setPuntuacion(int puntuacion)
        {
            this.puntuacion = puntuacion;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setNombre(int id)
        {
            this.id = id;
        }

        public double getPrecio()
        {
            return this.precio;
        }

        public void setPrecio(double precio)
        {
            this.precio = precio;
        }

        public string getImagen()
        {
            return this.imagen;
        }

        public void setImagen(string imagen)
        {
            this.imagen = imagen;
        }

        public Boolean getPulsado()
        {
            return this.pulsado;
        }

        public void setPulsado(Boolean pulsado)
        {
            this.pulsado = pulsado;
        }
        public string getDescripcion()
        {
            return this.descripcion;
        }
        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
