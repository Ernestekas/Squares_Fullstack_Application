import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Collection from '../Models/Collection.model';

@Injectable({
  providedIn: 'root'
})
export class CollectionsService {
  private url: string = "https://localhost:44340/api/PointsCollection/"
  constructor(private http : HttpClient) { }

  public getAll() : Observable<Collection[]> {
    return this.http.get<Collection[]>(this.url);
  }

  public getById(id: number): Observable<Collection> {
    return this.http.get<Collection>(this.url + id);
  }

  public post(collection : Collection) : Observable<any> {
    return this.http.post(this.url, collection);
  }

  public remove(id : number) : Observable<any> {
    return this.http.delete(this.url + id);
  }
}
