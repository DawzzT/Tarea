using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public class ProductModel
    {
        public ProductModel() { }

        Product[] productos;

        public void Add(Product p)
        {
            if (p == null)
            {
                throw new ArgumentException("Error, producto no puede ser null.");
            }

            if (productos == null)
            {
                productos = new Product[1];
                productos[productos.Length - 1] = p;
                return;
            }

            Product[] tmp = new Product[productos.Length + 1];
            Array.Copy(productos, tmp, productos.Length);
            tmp[tmp.Length - 1] = p;
            productos = tmp;
        }

        public int GetIndex(Product p)
        {
            int index = -1; int i = 0;
            foreach (Product prd in productos)
            {
                if (prd.Id == p.Id)
                {
                    index = i;
                }
                i++;
            }
            
            return index;
        }

        public Product[] GetProductos()
        {
            return productos;
        }

        public bool Delete(Product p)
        {
            bool flag = false;
            int index = GetIndex(p);
            if (index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Id} no existe.");
            }
            Product[] tmp = new Product[productos.Length - 1];
            productos[index] = productos[productos.Length - 1];
            Array.Copy(productos, tmp, productos.Length - 1);
            productos = tmp;

            return !flag;
        }

        public bool Update(Product p)
        {
            bool success = false;
            int index = GetIndex(p);
            if (index < 0)
            {
                throw new ArgumentException($"Error, producto con codigo {p.Id} no existe.");
            }

            productos[index] = p;
            return !success;
        }

        public Product FindById(int id)
        {
            int index = -1;
            for (int i = 0; i < productos.Length; i++)
            {
                if (productos[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            return index < 0 ? null : productos[index];
        }

        public  string Getlist()
        {
            string result = " ";
            foreach(Product m in productos )
            {
                result += m.Id.ToString()+" "+ m.Name.ToString()+" "+m.Quantity.ToString()+" "+m.Price.ToString();
            }
            return result;
        }

        public string GetProductoByUnidadMedida(MeasurementUnit unidad)
        {
            string result = " "; int x = 1;
            if (productos == null)
            {
                throw new ArgumentException($"Error, no ha ingresado ningun producto.");
            }
            
            for(int i =0; i<productos.Length;i++)
            {
                if (productos[i].MeasuUnit == unidad)
                {
                    result += x + ". Codigo: " + productos[i].Id.ToString() + " Nombre: " + productos[i].Name.ToString() +
                               " Cantidad: " + productos[i].Quantity.ToString() + " Precio: " + productos[i].Price.ToString() +
                               " Caducidad " + productos[i].CaducityDate.ToString()+ " Unidad de Medida: "+ productos[i].MeasuUnit.ToString()+"\n";
                    x++;
                }
            }
            
            return result;
        }

        public string GetProductByCaducidad(DateTime caducity)
        {
            string result = " "; int x = 1;
            if (productos == null)
            {
                throw new ArgumentException($"Error, no ha ingresado ningun producto.");
            }

            foreach (Product m in productos)
            {
                if (m.CaducityDate == caducity)
                {
                    result += x + ". Codigo: " + m.Id.ToString() + " Nombre: " + m.Name.ToString() +
                               " Cantidad: " + m.Quantity.ToString() + " Precio: " + m.Price.ToString() +
                               " Caducidad " + m.CaducityDate.ToString() + " Unidad de Medida: " + m.MeasuUnit.ToString() + "\n";
                    x++;
                }
            }

            return result;
        }

        public Product[] OrdenarByPrecio()
        {
            Array.Sort(productos, new Product.ProductPriceComparer());

            return productos;
        }

        public string GetProductAsJson()
        {
            if (productos == null)
            {
                throw new ArgumentException($"Error, no ha ingresado ningun producto.");
            }
            string ObjectJson = "";
            foreach(Product f in productos)
            {
                ObjectJson += JsonConvert.SerializeObject(f);
            }
            return ObjectJson;
        }
    }
}
