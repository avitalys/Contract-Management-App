import { Address } from "./address";
import { Contract } from "./contract";

export interface Customer{
    id: string;
    firstName: string;
    lastName: string;
    address: Address;
    contracts?: Contract[];
}