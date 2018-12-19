
/**
 * Parent class for all resouce-based entities
 */
export class Resource {
    /**
     * Primary Id
     */
    id: number

    /**
     * Calls a data service
     * 
     * @example Simply call the function with id and factor values
     * getResult(60) 
     * @param {number} id Primary Id 
     * @param {number} factor factor for multiplying Primary Id
     * @returns Calculated value using Primary Id
     */
    getResult(id: number, factor: number) : number {
        let sum = id + factor;
        return sum;
    }
}
