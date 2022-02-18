import { Injectable } from '@angular/core';
import ImportedCollection from '../Models/imported-collection.model';

@Injectable({
  providedIn: 'root'
})
export class TextReaderService {

  constructor() { }

  public getImportedCoordinates(lines: string[]): ImportedCollection {
    let importedCollection: ImportedCollection = { importedPoints: [], failedEntries: [] };
    for (let i = 0; i < lines.length; i++) {
      let coordinates = lines[i].split(" ");
      let resultModel = this.validateCoordinates(coordinates, i);

      importedCollection.failedEntries.push(...resultModel.failedEntries);

      if (resultModel.failedEntries.length === 0) {
        importedCollection.importedPoints.push({
          x: parseInt(coordinates[0]),
          y: parseInt(coordinates[1])
        });

      }
    }

    return importedCollection
  }

  private validateCoordinates(coordinates: any[], lineNumber: number): ImportedCollection {

    let imported: ImportedCollection = { importedPoints: [], failedEntries: [] };

    if (!this.checkCoordinatesAreNumbers(coordinates)) {
      imported.failedEntries.push("Line: " + lineNumber + " | " + coordinates.join(', ') + " - Wrong coordinates format. Right format: 123 321.");
    }

    if (!this.checkIfOnlyXYCoordinates(coordinates)) {
      imported.failedEntries.push("Line: " + lineNumber + " | " + coordinates.join(', ') + " - Too much coordinates specified. Right format: 123 321.");
    }

    if (!this.coordinatesAreInSpecifiedInterval(coordinates, -5000, 5000)) {
      imported.failedEntries.push("Line: " + lineNumber + " | " + coordinates.join(', ') + " - All coordinates must be between -5000 and 5000.");
    }
    return imported;
  }

  private checkCoordinatesAreNumbers(coordinates: any[]): boolean {
    if (isNaN(coordinates[0]) || isNaN(coordinates[1])) {
      return false;
    }

    return true;
  }

  private checkIfOnlyXYCoordinates(coordinates: any[]): boolean {
    if (coordinates.length !== 2) {
      return false;
    }

    return true;
  }

  private coordinatesAreInSpecifiedInterval(coordinates: any[], coordinatesMin: number, coordinatesMax: number) {
    if (!(parseInt(coordinates[0]) >= coordinatesMin && parseInt(coordinates[0]) <= coordinatesMax
      && parseInt(coordinates[1]) >= coordinatesMin && parseInt(coordinates[1]) <= coordinatesMax)) {
      return false;
    }

    return true;
  }
}
