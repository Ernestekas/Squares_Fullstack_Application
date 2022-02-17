import Point from "./Point.model";

export default interface Collection{
    id?: number,
    name?: string,
    pointsCount?: number,
    points?: Point[]
}