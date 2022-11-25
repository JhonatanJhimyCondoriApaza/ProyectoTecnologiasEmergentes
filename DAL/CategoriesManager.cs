using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesManager
    {
        
        /// <summary>
        /// Registra un objeto Category
        /// </summary>
        /// <param name="ObjCategorie"></param>
        /// <returns>Devuelve el identificador del objeto Category</returns>
        public int InsertarCategoria(Categories ObjCategorie)
        {
            int maximo = 0;
            
            SistemaVentasRopaEntities BD = new SistemaVentasRopaEntities();

            try
            {
               maximo = BD.Categories.Max(x => x.CategoryID);
            } catch { }

            
            ObjCategorie.CategoryID = maximo + 1;
            BD.Categories.Add(ObjCategorie); // LO GUARDA EN EL CACHE.
            BD.SaveChanges(); // AQUI SI GUARDA EN LA BASE DE DATOS.

            return ObjCategorie.CategoryID;
        }
    }
}
