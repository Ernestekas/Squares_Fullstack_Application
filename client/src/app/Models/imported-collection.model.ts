import Point from "./Point.model";

export default interface ImportedCollection{
    importedPoints: Point[],
    failedEntries: string[]
}