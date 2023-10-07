import { Box } from "./Box";

export type BoxOrder = {
    id: number;
    buyer: string;
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