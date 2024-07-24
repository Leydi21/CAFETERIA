export interface users {
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


export const usuarios = [
    {id: 1, name: 'Leydi', role: 'admin', password: '123',email:'coffe@gmail.com',
        phone:'5525453722',avatar:'llllll',creationAt:'2024-07-13T00:50:52.000Z',updatedAt:'2024-07-13T00:50:52.000Z'},
    {id: 2, name: 'Sonia', role: 'vendedor', password: '123',email:'coffe@gmail.com',
        phone:'5525366722',avatar:'llllll',creationAt:'2024-07-13T00:50:52.000Z',updatedAt:'2024-07-13T00:50:52.000Z'},
    {id: 3, name: 'Angel', role: 'vendedor', password: '123',email:'coffe@gmail.com',
        phone:'5525378725',avatar:'llllll',creationAt:'2024-07-13T00:50:52.000Z',updatedAt:'2024-07-13T00:50:52.000Z'},
    {id: 4, name: 'Fer', role: 'vendedor', password: '123',email:'coffe@gmail.com',
        phone:'5525359654',avatar:'llllll',creationAt:'2024-07-13T00:50:52.000Z',updatedAt:'2024-07-13T00:50:52.000Z'},
]