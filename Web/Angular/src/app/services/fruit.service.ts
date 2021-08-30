import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { fruitUrl } from 'src/app/config/api';
import { Fruit } from 'src/app/models/fruit';
import {FruitListViewModel} from 'src/app/models/fruit-view-model';
import { FruitTableViewModel } from 'src/app/models/fruit-table-view-model'


@Injectable({
  providedIn: 'root'
})
export class FruitService {

  constructor(private http: HttpClient) { }

  getViewModel(): Observable<FruitListViewModel> {
    return this.http.get<FruitListViewModel>(fruitUrl);
  }

  getById(id): Observable<FruitTableViewModel> {
    return this.http.get<FruitTableViewModel>(fruitUrl+'/'+id);
  }
}
