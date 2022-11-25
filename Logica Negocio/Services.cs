using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class Services
    {
        /// <summary>
        /// Registra una nueva categoria
        /// </summary>
        /// <param name="CategoryName1"></param>
        /// <param name="Descrition1"></param>
        /// <param name="image1"></param>
        /// <returns>Devulve el identificador de la persona</returns>
        /// 
        public byte[] defaultValue = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        //ESTOY OBVIANDO EL VALOR DE LA IMAGEN PORQUE POR DEFECTO ESTOY ASISGNANDO 
        public int RegistraCategory(string CategoryName1, string Descrition1) {
            CategoriesManager categoriesManager = new CategoriesManager();
            Categories categories = new Categories
            {
                CategoryName = CategoryName1,
                Description = Descrition1,
                Picture = defaultValue
            };
            return categoriesManager.InsertarCategoria(categories);
        }
    }
}
