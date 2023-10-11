export type BoxOrder = {
    id: number;
    street: string;
    number: string;
    city: string;
    zip: string;
    orderedAt: Date;
    shippedAt: Date;
    Lines: BoxOrderLine[];
}

export type BoxOrderLine = {
    id: number;
    amount: number;
    price: number;
}