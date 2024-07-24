export interface products {
    id: number;
    name: string;
    role: string;
    password: string;
    email: string;
    phone: string;
    avatar: string;
    creationAt: Date;
    updatedAt: Date;
}


export const productos = [
    {   _id: "001",description: "Café arábica de origen único con notas de frutas y chocolate.",
        flavor_profile: ["Frutal", "Chocolate"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 1,image_url: "https://example.com/cafe-arabica.jpg",name: "Café Arábica",
        price: 12.99,region: "Colombia",roast_level: "Medio",weight: "500g"
    },
    {
        _id: "002",description: "Mezcla de café suave y aromático con un toque de caramelo.",
        flavor_profile: ["Caramelo", "Aromático"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 2,image_url: "https://example.com/cafe-caramelo.jpg",name: "Café Caramelo",
        price: 14.99,region: "Brasil",roast_level: "Ligero",weight: "500g"
    },
    {
        _id: "003",description: "Café orgánico de comercio justo con notas de cacao y nuez.",
        flavor_profile: ["Cacao", "Nuez"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 3,image_url: "https://example.com/cafe-organico.jpg",name: "Café Orgánico",
        price: 15.99,region: "Perú",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "004",description: "Té verde premium con un sabor fresco y delicado.",
        flavor_profile: ["Fresco", "Delicado"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 4,image_url: "https://example.com/te-verde.jpg",name: "Té Verde Premium",
        price: 9.99,region: "China",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "005",description: "Té negro fuerte con un toque de bergamota.",
        flavor_profile: ["Fuerte", "Bergamota"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 5,image_url: "https://example.com/te-negro.jpg",name: "Té Negro Earl Grey",
        price: 10.99,region: "India",roast_level: "No aplicable",weight: "200g"
    },
    {
        _id: "006",description: "Café descafeinado con sabor equilibrado y suave.",
        flavor_profile: ["Equilibrado", "Suave"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 6,image_url: "https://example.com/cafe-descafeinado.jpg",name: "Café Descafeinado",
        price: 13.99,region: "México",roast_level: "Medio",weight: "500g"
    },
    {
        _id: "007",description: "Café espresso italiano con un sabor intenso y profundo.",
        flavor_profile: ["Intenso", "Profundo"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 7,image_url: "https://example.com/cafe-espresso.jpg",name: "Café Espresso Italiano",
        price: 16.99,region: "Italia",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "008",description: "Té chai especiado con una mezcla de canela, cardamomo y jengibre.",
        flavor_profile: ["Especiado", "Aromático"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 8,image_url: "https://example.com/te-chai.jpg",name: "Té Chai",
        price: 11.99,region: "India",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "009",description: "Mezcla de café robusta con un sabor fuerte y ahumado.",
        flavor_profile: ["Fuerte", "Ahumado"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 9,image_url: "https://example.com/cafe-robusta.jpg",name: "Café Robusta",
        price: 12.99,region: "Vietnam",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "010",description: "Infusión de hierbas con manzanilla y menta, ideal para relajarse.",
        flavor_profile: ["Manzanilla", "Menta"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 10,image_url: "https://example.com/infusion-hierbas.jpg",name: "Infusión Relajante",
        price: 8.99,region: "Estados Unidos",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "011",description: "Café especial con notas de vainilla y avellana.",
        flavor_profile: ["Vainilla", "Avellana"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 11,image_url: "https://example.com/cafe-vainilla-avellana.jpg",name: "Café Vainilla y Avellana",
        price: 13.99,region: "Guatemala",roast_level: "Medio",weight: "500g"
    }
    ,{
        _id: "012",description: "Café gourmet con un sabor complejo y afrutado.",
        flavor_profile: ["Complejo", "Afrutado"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 12,image_url: "https://example.com/cafe-gourmet.jpg",name: "Café Gourmet",
        price: 17.99,region: "Etiopía",roast_level: "Ligero",weight: "500g"
    }
    ,{
        _id: "013",description: "Té blanco delicado con notas florales.",
        flavor_profile: ["Floral", "Delicado"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 13,image_url: "https://example.com/te-blanco.jpg",name: "Té Blanco",
        price: 12.99,region: "China",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "014",description: "Café de especialidad con un sabor ahumado y robusto.",
        flavor_profile: ["Ahumado", "Robusto"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 14,image_url: "https://example.com/cafe-ahumado.jpg",name: "Café Ahumado",
        price: 14.99,region: "Indonesia",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "015",description: "Mezcla de café balanceado con notas de frutos secos y cacao.",
        flavor_profile: ["Frutos secos", "Cacao"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 15,image_url: "https://example.com/cafe-balanceado.jpg",name: "Café Balanceado",
        price: 13.49,region: "Honduras",roast_level: "Medio",weight: "500g"
    }
    ,{
        _id: "016",description: "Té oolong con un sabor suave y floral.",
        flavor_profile: ["Suave", "Floral"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 16,image_url: "https://example.com/te-oolong.jpg",name: "Té Oolong",
        price: 11.99,region: "Taiwán",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "017",description: "Café de altura con un sabor afrutado y vibrante.",
        flavor_profile: ["Afrutado", "Vibrante"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 17,image_url: "https://example.com/cafe-altura.jpg",name: "Café de Altura",
        price: 15.49,region: "Costa Rica",roast_level: "Ligero",weight: "500g"
    }
    ,
    {
        _id: "018",description: "Infusión de frutas con un toque de hibisco y rosa mosqueta.",
        flavor_profile: ["Hibisco", "Rosa mosqueta"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 18,image_url: "https://example.com/infusion-frutas.jpg",name: "Infusión de Frutas",
        price: 9.49,region: "Estados Unidos",roast_level: "No aplicable",weight: "200g"
    }
    ,
    {
        _id: "019",description: "Café con leche en polvo para una preparación rápida y fácil.",
        flavor_profile: ["Suave", "Cremoso"],
        grind_option: ["Entero", "Molido", "Instantáneo"],
        id: 19,image_url: "https://example.com/cafe-leche.jpg",name: "Café con Leche",
        price: 10.49,region: "Francia",roast_level: "Medio",weight: "400g"
    }
    ,{
        _id: "020",description: "Té matcha en polvo, perfecto para batidos y bebidas saludables.",
        flavor_profile: ["Terroso", "Fresco"],
        grind_option: ["Polvo", "Bolsa", "Hoja entera"],
        id: 20,image_url: "https://example.com/te-matcha.jpg",name: "Té Matcha",
        price: 19.99,region: "Japón",roast_level: "No aplicable",weight: "100g"
    }
    ,{
        _id: "021",description: "Café espresso con un sabor intenso y un toque de cacao.",
        flavor_profile: ["Intenso", "Cacao"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 21,image_url: "https://example.com/cafe-espresso-cacao.jpg",name: "Café Espresso Cacao",
        price: 15.49,region: "Italia",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "022",description: "Infusión de jengibre y limón para un impulso revitalizante.",
        flavor_profile: ["Jengibre", "Limón"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 22,image_url: "https://example.com/infusion-jengibre-limon.jpg",name: "Infusión Revitalizante",
        price: 8.49,region: "India",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "023",description: "Café turco con un sabor fuerte y especiado.",
        flavor_profile: ["Fuerte", "Especiado"],
        grind_option: ["Molido", "Entero", "Espresso"],
        id: 23,image_url: "https://example.com/cafe-turco.jpg",name: "Café Turco",
        price: 14.49,region: "Turquía",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "024",description: "Té rojo con un sabor terroso y profundo.",
        flavor_profile: ["Terroso", "Profundo"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 24,image_url: "https://example.com/te-rojo.jpg",name: "Té Rojo",
        price: 9.99,region: "Sudáfrica",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "025",description: "Café de origen único con notas de miel y almendra.",
        flavor_profile: ["Miel", "Almendra"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 25,image_url: "https://example.com/cafe-miel-almendra.jpg",name: "Café Miel y Almendra",
        price: 16.49,region: "Nicaragua",roast_level: "Medio",weight: "500g"
    }
    ,
    {
        _id: "026",description: "Infusión de frutas rojas con un sabor dulce y refrescante.",
        flavor_profile: ["Dulce", "Refrescante"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 26,image_url: "https://example.com/infusion-frutas-rojas.jpg",name: "Infusión de Frutas Rojas",
        price: 8.99,region: "España",roast_level: "No aplicable",weight: "200g"
    }
    ,
    {
        _id: "027",description: "Café helado instantáneo para una preparación rápida y deliciosa.",
        flavor_profile: ["Suave", "Refrescante"],
        grind_option: ["Molido", "Entero", "Instantáneo"],
        id: 27,image_url: "https://example.com/cafe-helado.jpg",name: "Café Helado",
        price: 11.99,region: "Estados Unidos",roast_level: "Ligero",weight: "400g"
    }
    ,{
        _id: "028",description: "Té verde con jazmín, delicado y fragante.",
        flavor_profile: ["Jazmín", "Delicado"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 28,image_url: "https://example.com/te-verde-jazmin.jpg",name: "Té Verde Jazmín",
        price: 10.49,region: "China",roast_level: "No aplicable",weight: "200g"
    }
    ,{
        _id: "029",description: "Café robusto con un sabor fuerte y cuerpo completo.",
        flavor_profile: ["Fuerte", "Completo"],
        grind_option: ["Entero", "Molido", "Espresso"],
        id: 29,image_url: "https://example.com/cafe-robusto.jpg",name: "Café Robusto Completo",
        price: 14.99,region: "India",roast_level: "Oscuro",weight: "500g"
    }
    ,{
        _id: "030",description: "Té de menta refrescante con un sabor intenso y limpio.",
        flavor_profile: ["Menta", "Refrescante"],
        grind_option: ["Hoja entera", "Molido", "Bolsa"],
        id: 30,image_url: "https://example.com/te-menta.jpg",name: "Té de Menta",
        price: 9.49,region: "Marruecos",roast_level: "No aplicable",weight: "200g"
    }
]