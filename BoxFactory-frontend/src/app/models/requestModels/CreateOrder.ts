export type CreateOrder = {
    street: string;
    number: string;
    city: string;
    zip: string;
    orderLines: AddOrderLine[];
}

export type AddOrderLine = {
    boxId: number;
    amount: number;
    price: number;
}