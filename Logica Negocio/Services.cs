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
        
        //public byte[] defaultValue = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        //ESTOY OBVIANDO EL VALOR DE LA IMAGEN PORQUE POR DEFECTO ESTOY ASISGNANDO 
        public int RegistraCategory(string background_input, string letter_input, bool enjoyed_input, string cstml_input, DateTime cstmd_input) {
            
            CategoriesManager categoriesManager = new CategoriesManager();
            liketable customer_like = new liketable
            {
                backgroundColor = background_input,
                lettersColor = letter_input,
                enjoyed = enjoyed_input,
                customer_location = cstml_input,
                customer_date = cstmd_input
            };
            return categoriesManager.InsertarCategoria(customer_like);
        }
    }
}
