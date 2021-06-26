using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas
{
   public class RecetasRepository
    {
        public List<Receta> Recetario = new List<Receta>()
        {
            new Receta() {Nombre="Chiles Rellenos",Ingredientes="6 chiles poblanos 1/2 kilos de queso oaxaca 5 huevos1/4 tazas de harina de trigo 1 taza de aceite vegetal, para freír 1 kilo de tomate rojo 1/2 cebollas, chica 2 dientes de ajo 3 tazas de caldo de pollo 1 cucharadita de sal",Procedimiento="Los chiles se asan, se pelan y se abren con mucho cuidado para rellenar, se despepitan, se desvenan, se lavan y se secan. El queso oaxaca se desmenuza y con ésto se rellenan los chiles. Las yemas de huevo se baten muy bien con un poco de sal; las claras se baten a punto de turron y se mezclan con las yemas en forma envolvente.",TiempoCocinar=20},
            new Receta() {Nombre="Crema de calabaza al eneldo", Ingredientes="500 g de calabaza pelada sin semillas, un manojo de eneldo fresco, 400-500 ml de caldo de verduras, nata líquida o queso para servir.", Procedimiento="Pesamos y utilizamos 500 g de calabaza cortada en trozos pequeños. La colocamos en una cacerola amplia y colocamos sobre ella el eneldo, sin los tallos (que desechamos). Regamos con caldo de verduras y llevamos a ebullición el conjunto.",TiempoCocinar=20},
            new Receta(){Nombre="Sopa de miso", Ingredientes="20 g de alga kombu seca, 1 cucharada sopera de katsuobushi (copos de atún o bonito secos), 1 l de agua, 1 cucharada de miso blanco, alga wakame, salsa de soja, 1 cebolla, 50 g de tofu blando.",Procedimiento="Hidratamos una hora el alga kombu en un litro de agua. Después, ponemos ese mismo cazo con el alga y el agua a calentar y apagamos el fuego en cuanto empiece a hervir. Sacamos el alga kombu y añadimos el kasuobushi y dejamos que se infusione 10-15 minutos. Sabremos que está listo cuando los copos de bonito deshidratados se hayan ido al fondo de la cacerola. Colamos y reservamos ese caldo. Disolvemos la pasta de miso en un vaso de nuestro caldo dashi, mientras ponemos el resto del caldo a cocer. Cuando esté disuelto lo integramos con el resto del caldo al que añadiremos el alga wakame y el tofu cortado en pequeños taquitos dejando cocer durante 2 minutos. Servimos la sopa de miso acompañada de cebolla en juliana.",TiempoCocinar=17 },
            new Receta(){Nombre="Sartén de patatas, huevos y aguacate",Ingredientes="350 g de patatas, 2 cucharadas de aceite de oliva virgen extra, 1 pimiento rojo, 1 cebolleta, 1 pimiento rojo picante o chile, 4 huevos camperos, 1 aguacate grande, 2 cucharadas de zumo de lima, cilantro fresco, sal y pimienta negra.", Procedimiento="Cortamos las patatas peladas en dados del mismo tamaño. Ponemos un cazo de agua a hervir y cocemos seis minutos, las escurrimos y reservamos. En una sartén calentamos el aceite, añadimos las patatas, el pimiento rojo, el pimiento largo picante y la cebolleta en trocitos, añadiendo después la sal y la pimienta negra. Cocinamos todo junto, removiendo frecuentemente, sobre unos ocho minutos. Con el borde de una cuchara, hacemos en la mezcla cuatro separaciones.", TiempoCocinar=35},


        };
        public IEnumerable<Receta> Filtrar(string palabra)
        {
            return Recetario.Where(X => X.Nombre.ToUpper().Contains(palabra.ToUpper()));
        }
    }
}
