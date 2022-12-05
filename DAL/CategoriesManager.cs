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
        public int InsertarCategoria(liketable Objcustomer_like)
        {
            int maximo = 0;
            
            likedatabaseEntities BD = new likedatabaseEntities();

            try
            {
               maximo = BD.liketable.Max(x => x.id);
            } catch { }


            Objcustomer_like.id = maximo + 1;

            DateTime formated_hour = Convert.ToDateTime(Objcustomer_like.customer_date);
            string sqlFormattedDate = formated_hour.ToString("yyyy-MM-dd HH:mm:ss");
            Objcustomer_like.customer_date = Convert.ToDateTime(sqlFormattedDate);
            BD.liketable.Add(Objcustomer_like); // LO GUARDA EN EL CACHE.
            BD.SaveChanges(); // AQUI SI GUARDA EN LA BASE DE DATOS.

            return Objcustomer_like.id;
        }
    }
}
