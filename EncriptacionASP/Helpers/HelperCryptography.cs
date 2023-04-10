using System.Text;
using System.Security.Cryptography;
namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string Salt { get; set; }
        public static string GenerateSalt()
        {
            Random random = new Random();
            
            for(int i = 1; i<= 50; i++)
            {
                int aleat = random.Next(0, 255);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;

        }

        public static string EncriptarContenido
            (string contenido, bool comparar)
        {
            if(comparar == false)
            {
                //GENERAMOS NUESTRO SALT
                Salt = GenerateSalt();
            }
            //EL SALT LO INCLUIREMOS DONDE DESEEMOS
            //INCLUIMOS EL SALT AL FINAL DEL PASSWORD A CIFRAR
            string contenidosalt = contenido + Salt;
            SHA256Managed sHA256 = new SHA256Managed();

            byte[] salida;
            UnicodeEncoding encoding = new UnicodeEncoding();
            //CONVERTIMOS A BYTES EL CONTENIDO DEL SALT
            salida = encoding.GetBytes(contenidosalt);  
            //DEBEMOS REALIZAR EL CIFRADO SOBRE CIFRADO N VECES
            for(int i = 1; i<= 55; i++) 
            {
                //REALIZAMOS EL CIFRADO
                salida = sHA256.ComputeHash(salida);
                
            }
            //LIMPIAMOS EL SHA256
            sHA256.Clear();
            string resultado = encoding.GetString(salida);
            return resultado;
        }




       
    }
}
