import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import Collection from '../Models/Collection.model';
import { CollectionsService } from './collections.service';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  public collections$ = new BehaviorSubject<Collection[]>([]);

  private collections: Collection[] = [];

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

}
