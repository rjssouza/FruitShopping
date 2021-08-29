import { Fruit } from './fruit';

export class CartItem {
  id: string;
  fruitId: string;
  quantity: number;
  cartId: string;
  price: number;

  constructor(id: string, quantity: number, product: Fruit) {
    this.id = id;
    this.fruitId = product.id;
    this.quantity = quantity;
    this.price = product.price;
  }
}
