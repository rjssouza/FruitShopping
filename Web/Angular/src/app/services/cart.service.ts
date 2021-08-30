import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CartItem } from '../models/cart-item';
import { Cart } from '../models/cart';
import { cartUrl } from '../config/api';
import { FruitTableViewModel } from '../models/fruit-table-view-model';

@Injectable({
  providedIn: 'root'
})

export class CartService {

  constructor(private http: HttpClient) { }

  getViewModel(): Observable<Cart> {
    return this.http.get<Cart>(cartUrl);
  }

  addProductToCart(fruit: FruitTableViewModel): Observable<any> {
    return this.http.post(cartUrl, fruit);
  }
}
