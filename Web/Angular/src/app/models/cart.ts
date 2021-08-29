import { CartItem } from './cart-item';

export class Cart {
  id: string;
  userId: string;
  items: CartItem[];

  constructor(id: string) {
    this.id = id;
  }
}
