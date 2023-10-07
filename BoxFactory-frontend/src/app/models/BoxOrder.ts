import { Box } from "./Box";

export type BoxOrder = {
    id: number;
    buyer: string;
    orderedAt: Date;
    isShipped: boolean;
    Lines: BoxOrderLine[];
}

export type BoxOrderLine = {
    id: number;
    box: Box;
    amount: number;
    price: number;
}