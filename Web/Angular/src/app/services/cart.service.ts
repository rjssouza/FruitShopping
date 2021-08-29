import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CartItem } from '../models/cart-item';
import { cartUrl } from '../config/api';
import { Fruit } from '../models/fruit';

@Injectable({
  providedIn: 'root'
})

export class CartService {

  constructor(private http: HttpClient) { }

  getViewModel(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(cartUrl);
  }

  addProductToCart(product: Fruit): Observable<any> {
    return this.http.post(cartUrl, { product });
  }
}
