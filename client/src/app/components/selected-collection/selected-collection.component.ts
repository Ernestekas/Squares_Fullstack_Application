import { Component, OnInit } from '@angular/core';
import Collection from 'src/app/Models/Collection.model';
import ImportedCollection from 'src/app/Models/imported-collection.model';
import Point from 'src/app/Models/Point.model';
import { SharedService } from 'src/app/services/shared.service';
import { TextReaderService } from 'src/app/services/text-reader.service';

@Component({
  selector: 'app-selected-collection',
  templateUrl: './selected-collection.component.html',
  styleUrls: ['./selected-collection.component.scss']
})
export class SelectedCollectionComponent implements OnInit {

  public selectedCollectionInput: Collection = {};
  public manualyAdded: Point[] = [];
  public newPoint: Point = {};

  public fileToUpload: File | null = null;
  public importedCollection: ImportedCollection = {importedPoints: [], failedEntries: [], failedValidation: []};
  private importValidation: ImportedCollection = {importedPoints: [], failedEntries: [], failedValidation: []};

  constructor(private sharedService: SharedService, private textReaderService: TextReaderService) { }

  ngOnInit(): void {
    this.sharedService.selectedCollection$.subscribe({
      next: (collectionData) => {
        this.selectedCollectionInput = collectionData;
        this.manualyAdded = [];
        let fileForm: HTMLFormElement = <HTMLFormElement>document.getElementById("fileForm");
        fileForm?.reset();
      },
      error: (response) => {
        console.log(response.error);
      },
      complete: () => {
        console.log("Shared OK.");
      }
    });
  }

  addPoint() {
    let tempPoint: Point = {
      x: this.newPoint.x,
      y: this.newPoint.y
    }

    if (this.validateNewPoint(tempPoint)) {
      this.manualyAdded.push(tempPoint);
    }

    this.newPoint = {};
  }

  addRandomPoint() {
    let randomPoint: Point = {
      x: Math.floor(Math.random() * 10000) - 5000,
      y: Math.floor(Math.random() * 10000) - 5000
    };

    if (this.validateNewPoint(randomPoint)) {
      this.manualyAdded.push(randomPoint);
    }

    this.newPoint = {};
  }

  clearManualyAdded(){
    this.manualyAdded = [];
  }

  removePoint(point: Point) {
    this.selectedCollectionInput.points = this.selectedCollectionInput.points!.filter(p => p.x !== point.x && p.y !== point.y);
  }

  removeManualyAddedPoint(point: Point) {
    this.manualyAdded = this.manualyAdded.filter(p => p.x !== point.x && p.y !== point.y);
    this.importedCollection = {failedEntries: [], importedPoints: [], failedValidation: []};
  }

  saveCollection() {
    this.selectedCollectionInput.points?.push(...this.manualyAdded);
    this.manualyAdded = [];

    this.sharedService.createCollection(this.selectedCollectionInput);
  }

  removeCollection() {
    this.sharedService.removeSelectedCollection();
  }

  onChangeEvent(event: any) {
    let fileReader = new FileReader();
    
    fileReader.readAsText(event.target.files[0]);
    fileReader.onload = () => {
      let lines = (fileReader.result as string).split(/\r?\n/);
      let unvalidatedCollection = this.textReaderService.getImportedCoordinates(lines);
      
      unvalidatedCollection.importedPoints.forEach(p => {

        if(this.validateNewPoint(p)){
          this.manualyAdded.push(p);
        }else{
          unvalidatedCollection.failedValidation.push(...this.importValidation.failedValidation);
          unvalidatedCollection.importedPoints = unvalidatedCollection.importedPoints.filter(point => point.x != p.x && point.y != p.y);

          this.importValidation.failedValidation = [];
        }
      });

      this.importedCollection = unvalidatedCollection;
    }
  }

  private validateNewPoint(point: Point): boolean {

    let validated: boolean = true;

    if (point.x == undefined || point.y == undefined) {
      this.importValidation.failedValidation.push("X or Y undefined. Coordinates: X: " + point.x + " Y: " + point.y);
      return false;
    }

    if (point.x < -5000 || point.x > 5000 || point.y < -5000 || point.y > 5000) {
      this.importValidation.failedValidation.push("X or Y out of bounds valid value interval (-5000, 5000). Coordinates: X: " + point.x + " Y: " + point.y);
      validated = false;
    }

    if (this.selectedCollectionInput.points != null) {
      if (this.selectedCollectionInput.points.length + this.manualyAdded.length > 10000) {
        this.importValidation.failedValidation.push("List limit reached. Maximum 10000 points.");
        validated = false;
      }
    }
    else if (this.manualyAdded.length > 10000) {
      this.importValidation.failedValidation.push("List limit reached. Maximum 10000 points.");
      validated = false;
    }

    if (!this.checkIfPointUnique(point)) {
      this.importValidation.failedValidation.push("This point already exists. Coordinates: X: " + point.x + " Y: " + point.y);
      validated = false;
    }

    if(!validated){
      return false;
    }

    return true;
  }

  private checkIfPointUnique(pointToCheck: Point): boolean {
    if (this.selectedCollectionInput.points != null) {
      for (let i = 0; i < this.selectedCollectionInput.points!.length; i++) {
        let point: Point = this.selectedCollectionInput.points![i];
        if (point.x == pointToCheck.x && point.y == pointToCheck.y) {
          return false;
        }
      }
    }

    for (let i = 0; i < this.manualyAdded.length; i++) {
      let point: Point = this.manualyAdded![i];

      if (point.x == pointToCheck.x && point.y == pointToCheck.y) {
        return false;
      }
    }
    return true;
  }
}
