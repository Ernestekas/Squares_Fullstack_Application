import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import Collection from '../Models/Collection.model';
import { CollectionsService } from './collections.service';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  public collections$ = new BehaviorSubject<Collection[]>([]);
  public selectedCollection$ = new BehaviorSubject<Collection>({});

  private collections: Collection[] = [];
  private selectedCollection: Collection = {};

  constructor(private collectionsService: CollectionsService) { }

  public loadAll() {
    this.collectionsService.getAll().subscribe({
      next: (collections) => {
        this.collections = collections;
        this.collections$.next(this.collections);
      },
      error: (response) => console.log(response.error),
      complete: () => console.log("OK")
    });
  }

  public loadSelectedCollection(collection: Collection) {
    this.selectedCollection$.next(collection);
  }

  public createCollection(collection: Collection) {
    this.collectionsService.post(collection).subscribe({
      next: () => {
        this.loadAll();
      },
      error: (response) => {
        console.log(response.error);
      },
      complete: () => {
        console.log("Ok");
      }
    });
  }
}
