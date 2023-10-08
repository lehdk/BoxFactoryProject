import { Box } from "./Box";

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
    box: Box;
    amount: number;
    price: number;
}