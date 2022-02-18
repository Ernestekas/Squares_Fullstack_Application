import { Component, OnInit } from '@angular/core';
import Collection from 'src/app/Models/Collection.model';
import Point from 'src/app/Models/Point.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-selected-collection',
  templateUrl: './selected-collection.component.html',
  styleUrls: ['./selected-collection.component.scss']
})
export class SelectedCollectionComponent implements OnInit {

  public selectedCollectionInput: Collection = {};
  public manualyAdded: Point[] = [];
  public newPoint: Point = {};

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.sharedService.selectedCollection$.subscribe({
      next: (collectionData) => {
        this.selectedCollectionInput = collectionData;
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
    let tempPoint : Point = {
      x: this.newPoint.x,
      y: this.newPoint.y
    }

    if(this.validateNewPoint(tempPoint)){
      this.manualyAdded.push(tempPoint);
    }
    
    this.newPoint = {};
  }

  addRandomPoint() {
    let randomPoint: Point = {
      x: Math.floor(Math.random() * 10000) - 5000,
      y: Math.floor(Math.random() * 10000) - 5000
    };

    if(this.validateNewPoint(randomPoint)){
      this.manualyAdded.push(randomPoint);
    }

    this.newPoint = {};
  }

  removePoint(point: Point) {
    this.selectedCollectionInput.points = this.selectedCollectionInput.points!.filter(p => p.x !== point.x && p.y !== point.y);
  }

  removeManualyAddedPoint(point: Point)
  {
    this.manualyAdded = this.manualyAdded.filter(p => p.x !== point.x && p.y !== point.y);
  }

  saveCollection() {
    this.selectedCollectionInput.points?.push(...this.manualyAdded);
    this.manualyAdded = [];

    this.sharedService.createCollection(this.selectedCollectionInput);
  }



  private validateNewPoint(point: Point): boolean {
    if(point.x == undefined || point.y == undefined){
      return false;
    }

    if(point.x < -5000 || point.x > 5000 || point.y < -5000 || point.y > 5000){
      return false;
    }

    if(this.selectedCollectionInput.points != null){
      if(this.selectedCollectionInput.points.length + this.manualyAdded.length > 10000){
        return false
      }
    }
    else if(this.manualyAdded.length > 10000){
      return false
    }

    if(!this.checkIfPointUnique(point)){
      return false;
    }

    return true;
  }

  private checkIfPointUnique(pointToCheck: Point): boolean {
    if(this.selectedCollectionInput.points != null){
      for(let i = 0; i < this.selectedCollectionInput.points!.length; i++){
        let point: Point = this.selectedCollectionInput.points![i];
        
        if(point.x == pointToCheck.x && point.y == pointToCheck.y){
          return false;
        }
      }
    }
    
    for(let i = 0; i < this.manualyAdded.length; i++){
      let point: Point = this.manualyAdded![i];
      
      if(point.x == pointToCheck.x && point.y == pointToCheck.y){
        return false;
      }
    }
    return true;
  }
}
